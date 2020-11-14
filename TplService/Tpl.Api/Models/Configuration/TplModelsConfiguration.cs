using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tpl.Api.Models.Db_Models;

namespace Tpl.Api.Models.Configuration
{
    public class TplModelsConfiguration : IEntityTypeConfiguration<TplModel>
    {
        public void Configure(EntityTypeBuilder<TplModel> builder)
        {
            throw new NotImplementedException();
        }
    }
}
