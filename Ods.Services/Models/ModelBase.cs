using AutoMapper;
using Ods.Common.Components.Mapper.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ods.Services.Models
{
    public abstract class ModelBase : IConfigureMapper
    {
        public virtual void ConfigureMapper(Profile profile)
        {
        }
    }
}
