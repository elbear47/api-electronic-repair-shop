using System;
using erTicketingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace erTicketingApi.Controllers
{
	public class ElectronicRepairDbContext: DbContext
	{

        public ElectronicRepairDbContext(DbContextOptions<ElectronicRepairDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<CostCenter> CostCenters { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<PostRepairDispo> PostRepairDispos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Area>().ToTable("areas");
            modelBuilder.Entity<Equipment>().ToTable("equipments");
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<CostCenter>().ToTable("costCenters");
            modelBuilder.Entity<Ticket>().ToTable("tickets");
            modelBuilder.Entity<PostRepairDispo>().ToTable("postRepairDispos");
        }

    }
}

