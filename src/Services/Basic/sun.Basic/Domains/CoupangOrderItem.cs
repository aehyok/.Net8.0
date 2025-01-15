using sun.EntityFrameworkCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sun.Basic.Domains
{
    /// <summary>
    /// 电商平台订单明细
    /// </summary>
    public class CoupangOrderItem: AuditedEntity
    {
        /// <summary>
        /// vendorItemPackageId数值
        /// vendorItemPackageId
        /// 未使用/不存在则返回0
        /// </summary>
        public int VendorItemPackageId { get; set; }

        /// <summary>
        /// vendorItemPackageName字符串
        /// vendorItemPackageName
        /// </summary>
        public string VendorItemPackageName { get; set; }

        /// <summary>
        /// productId数值
        /// 产品ID
        /// 未使用/不存在则返回0
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// vendorItemId数值
        /// 产品单项ID/OptionID
        /// </summary>
        public int VendorItemId { get; set; }

        /// <summary>
        /// vendorItemName字符串
        /// 产品显示名称
        /// </summary>
        public string VendorItemName { get; set; }

        /// <summary>
        /// shippingCount数值
        /// shippingCount = 订购时的产品数量
        /// holdCountForCancel = 被取消待退款的产品数量
        /// cancelCount = 已经确认要被取消的产品数量
        /// 可配送产品数量 = shippingCount - (holdCountForCancel + cancelCount )
        /// </summary>
        public int ShippingCount { get; set; }

        /// <summary>
        /// holdCountForCancel数值
        /// 被取消待退款的产品数量
        /// </summary>
        public int HoldCountForCancel { get; set; }

        /// <summary>
        /// cancelCount数值
        /// 已经确认要被取消的产品数量
        /// </summary>
        public int CancelCount { get; set; }

        /// <summary>
        /// 计算可配送产品数量
        /// </summary>
        public int AvailableShippingCount => ShippingCount - (HoldCountForCancel + CancelCount);

        /// <summary>
        /// salesPrice数值
        /// 产品单项的价格
        /// </summary>
        public decimal SalesPrice { get; set; }

        /// <summary>
        /// orderPrice数值
        /// 付款金额: salesPrice*shippingCount
        /// </summary>
        public decimal OrderPrice => SalesPrice * ShippingCount;

        /// <summary>
        /// discountPrice数值
        /// 打折金额总和, discountPrice(打折金额总和) = instantCouponDiscount(立减优惠券) + downloadableCoupon(下载优惠券) + coupangDiscount(Coupang 专享优惠)
        /// </summary>
        public decimal DiscountPrice { get; set; }

        /// <summary>
        /// instantCouponDiscount数值
        /// 立减优惠券数额
        /// </summary>
        public decimal InstantCouponDiscount { get; set; }

        /// <summary>
        /// downloadableCouponDiscount数值
        /// 下载优惠券数额
        /// </summary>
        public decimal DownloadableCouponDiscount { get; set; }

        /// <summary>
        /// coupangDiscount数值
        /// Coupang 专享优惠
        /// 酷澎专享购物车/品类折扣等金额
        /// </summary>
        public decimal CoupangDiscount { get; set; }

        /// <summary>
        /// externalVendorSkuCode字符串
        /// 卖家产品 SKU 代码
        /// </summary>
        public string ExternalVendorSkuCode { get; set; }

        /// <summary>
        /// etcInfoHeader字符串
        /// 各商品单项输入项
        /// 可选输入
        /// </summary>
        public string EtcInfoHeader { get; set; }

        /// <summary>
        /// etcInfoValue字符串
        /// 各商品单项输入项的用户输入值
        /// 可选输入
        /// 此字段存在，但是没有任何值. 如果需要，请使用以下 etcInfoValues.
        /// </summary>
        public string EtcInfoValue { get; set; }

        /// <summary>
        /// etcInfoValues数组
        /// 用户产品单项各属性输入值列表
        /// 可选输入
        /// </summary>
        public List<string> EtcInfoValues { get; set; }

        /// <summary>
        /// sellerProductId数值
        /// 卖家产品ID
        /// </summary>
        public int SellerProductId { get; set; }

        /// <summary>
        /// sellerProductName字符串
        /// 注册产品名称
        /// </summary>
        public string SellerProductName { get; set; }

        /// <summary>
        /// sellerProductItemName字符串
        /// 产品单项名称
        /// </summary>
        public string SellerProductItemName { get; set; }

        /// <summary>
        /// firstSellerProductItemName字符串
        /// 原始注册产品单项名称
        /// </summary>
        public string FirstSellerProductItemName { get; set; }

        /// <summary>
        /// estimatedShippingDate字符串
        /// 收到订单后预计发货日期
        /// yyyy-MM-dd
        /// </summary>
        public string EstimatedShippingDate { get; set; }

        /// <summary>
        /// plannedShippingDate字符串
        /// 计划发货日期(拆分发货订单)
        /// yyyy-MM-dd
        /// </summary>
        public string PlannedShippingDate { get; set; }

        /// <summary>
        /// invoiceNumberUploadDate字符串
        /// 运单号上传日期
        /// yyyy-MM-dd'T'HH:mm:ss
        /// </summary>
        public string InvoiceNumberUploadDate { get; set; }

        /// <summary>
        /// extraProperties对象
        /// 卖家商品属性的其它信息
        /// key:value 类型
        /// </summary>
        public string ExtraProperties { get; set; }

        /// <summary>
        /// pricingBadge布尔
        /// 是否为最低价
        /// true/false
        /// </summary>
        public bool PricingBadge { get; set; }

        /// <summary>
        /// usedProduct布尔
        /// 是否为二手货
        /// true/false
        /// </summary>
        public bool UsedProduct { get; set; }

        /// <summary>
        /// confirmDate字符串
        /// 确认收货日期时间
        /// yyyy-MM-dd HH:mm:ss
        /// </summary>
        public string ConfirmDate { get; set; }

        /// <summary>
        /// deliveryChargeTypeName字符串
        /// 配送收费类型
        /// not-free, free
        /// </summary>
        public string DeliveryChargeTypeName { get; set; }

        /// <summary>
        /// canceled布尔
        /// 订单是否被取消
        /// true/false
        /// </summary>
        public bool Canceled { get; set; }
    }
}
