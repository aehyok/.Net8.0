﻿using Ardalis.Specification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sun.Core.Domains.WorkFlow;
using sun.Core.Dtos.WorkFlow;
using sun.Core.Services.WorkFlow;
using sun.EntityFrameworkCore.Repository;
using sun.Infrastructure.Exceptions;
using sun.Infrastructure.Models;
using X.PagedList;

namespace sun.NCDP.Api.Controllers
{
    /// <summary>
    /// 工作流状态定义
    /// </summary>
    public class WorkFlowStateController(IWorkFlowStateService workFlowStateService) : NCDPControllerBase
    {
        /// <summary>
        /// 获取工作流状态定义列表
        /// </summary>
        /// <param name="workFlowId">工作流程定义Id</param>
        /// <returns></returns>
        [HttpGet("list/{workFlowId}")]
        public async Task<List<WorkFlowStateDto>> GetStateListAsync(long workFlowId)
        {
            var spec = Specifications<WorkFlowState>.Create();

            spec.Query.Where(a => a.WorkFlowDefineId == workFlowId);

            spec.Query.OrderBy(item => item.DisplayOrder);

            return await workFlowStateService.GetListAsync<WorkFlowStateDto>(spec);
        }

        /// <summary>
        /// 获取工作流状态定义详情
        /// </summary>
        /// <param name="workFlowStateId">工作流状态Id</param>
        /// <returns></returns>
        [HttpGet("detail/{workFlowStateId}")]
        public async Task<WorkFlowStateDto> GetStateByIdAsync(long workFlowStateId)
        {
            return await workFlowStateService.GetAsync<WorkFlowStateDto>(a => a.Id == workFlowStateId);
        }

        /// <summary>
        /// 添加工作流状态定义
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<long> PostStateAsync(CreateWorkFlowStateDto model)
        {
            var entity = this.Mapper.Map<WorkFlowState>(model);
            await workFlowStateService.InsertAsync(entity);
            return entity.Id;
        }

        /// <summary>
        /// 修改工作流状态定义
        /// </summary>
        /// <param name="workFlowStateId">工作流状态Id</param>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPut]
        public async Task<StatusCodeResult> PutStatusAsync(long workFlowStateId, CreateWorkFlowStateDto model)
        {
            var entity = await workFlowStateService.GetAsync(a => a.Id == workFlowStateId) ?? throw new Exception("修改的数据不存在");

            entity = this.Mapper.Map(model, entity);

            await workFlowStateService.UpdateAsync(entity);
            return Ok();
        }

        /// <summary>
        /// 删除工作流状态定义
        /// </summary>
        /// <param name="workFlowStateId">工作流状态Id</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<StatusCodeResult> DeleteStateAsync(long workFlowStateId)
        {
            await workFlowStateService.DeleteAsync(workFlowStateId);
            return Ok();
        }

        /// <summary>
        /// 启用工作流状态定义
        /// </summary>
        /// <param name="workFlowStateId">工作流状态Id</param>
        /// <returns></returns>
        /// <exception cref="ErrorCodeException"></exception>
        [HttpPut("enable/{id}")]
        public async Task<StatusCodeResult> EnableDefine(long workFlowStateId)
        {
            var entity = await workFlowStateService.GetByIdAsync(workFlowStateId);

            if (entity is null)
            {
                throw new ErrorCodeException(-1, "启用的数据不存在");
            }
            entity.IsEnable = true;

            await workFlowStateService.UpdateAsync(entity);

            return Ok();
        }

        /// <summary>
        /// 禁用工作流状态定义
        /// </summary>
        /// <param name="workFlowStateId">工作流状态Id</param>
        /// <returns></returns>
        /// <exception cref="ErrorCodeException"></exception>
        [HttpPut("disable/{workFlowStateId}")]
        public async Task<StatusCodeResult> DisableDefine(long workFlowStateId)
        {
            var entity = await workFlowStateService.GetByIdAsync(workFlowStateId);

            if (entity is null)
            {
                throw new ErrorCodeException(-1, "禁用的数据不存在");
            }
            entity.IsEnable = false;

            await workFlowStateService.UpdateAsync(entity);

            return Ok();
        }
    }
}
