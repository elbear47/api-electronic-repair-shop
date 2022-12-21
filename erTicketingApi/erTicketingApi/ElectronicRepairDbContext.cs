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


    }
}

