using FinalProjectDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectModels.Models
{
    public class FinalProjectEntity : DbContext
    {
        public virtual DbSet<البضاعه> البضاعه { get; set; }
        public virtual DbSet<الحسابات> الحسابات { get; set; }
        public virtual DbSet<الخزنه> الخزنه { get; set; }
        public virtual DbSet<الفواتير> الفواتير { get; set; }
        public virtual DbSet<بيع> بيع { get; set; }
        public virtual DbSet<شراء> شراء { get; set; }
        public virtual DbSet<مرتجع_بيع> مرتجع_بيع { get; set; }
        public virtual DbSet<مرتجع_شراء> مرتجع_شراء { get; set; }

        public FinalProjectEntity()
        {

        }

        public FinalProjectEntity(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // You don't actually ever need to call this
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                "Data Source=.;Initial Catalog=FinalProjectDB;Integrated Security=True;");
            }
        }
    }
}
