using Microsoft.EntityFrameworkCore;
using one.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace one.EntityFrameworkCore
{
    public static class OneDbContextModelCreatingExtensions
    {
        public static void ConfigurePersonTable(this ModelBuilder builder)
        {
            builder.Entity<Person>(entity =>
            {
                entity.ToTable("person");

                entity.HasIndex(e => e.Id).IsUnique();
            });
        }
    }
}