﻿using sun.Core.Domains;
using sun.Core.Dtos.Create;
using AutoMapper;
using sun.Core.Dtos.WorkFlow;
using sun.Core.Domains.WorkFlow;

namespace sun.Core.MapProfiles
{
    /// <summary>
    /// 新增和修改数据的映射文件
    /// </summary>
    public class AutoMapperCreateProfile: Profile
    {
        public AutoMapperCreateProfile()
        {
            CreateMap<CreateMenuDto, Menu>();

            CreateMap<CreateRoleDto, Role>();

            CreateMap<CreateRegionDto,  Region>();

            CreateMap<CreateUserDto, User>();

            CreateMap<CreateUserRoleDto, UserRole>();

            CreateMap<CreateWorkFlowDefineDto, WorkFlowDefine>();

            CreateMap<CreateWorkFlowStateDto, WorkFlowState>()
                 .ForMember(a => a.WorkFlowDefineId, a => a.MapFrom(c => c.WorkFlowId));

            CreateMap<CreateWorkFlowActionDto, WorkFlowAction>();

            CreateMap<CreateWorkFlowStateConfigDto, WorkFlowStateConfig>();

            CreateMap<CreateWorkFlowActionConfigDto, WorkFlowActionConfig>();
        }
    }
}
