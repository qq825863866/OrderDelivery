using AutoMapper;
using Ods.Common.Components.Mapper.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ods.Services
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // System
            // Organization
            //CreateMap<SysOrganization, TreeNode>();

            // Menu
            //CreateMap<SysMenu, TreeNode>();

            // 专有配置
            this.ConfigureMapper();
        }
    }
}
