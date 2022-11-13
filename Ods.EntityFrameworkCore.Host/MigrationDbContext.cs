using Microsoft.EntityFrameworkCore;
using Ods.Common.Services;
using Ods.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ods.EntityFrameworkCore.Host
{
    public class MigrationDbContext : OdsDbContext
    {
        public MigrationDbContext(DbContextOptions<OdsDbContext> options, ICurrentUserService currentUser) : base(options, currentUser)
        {
        }
    }
}
