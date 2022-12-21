using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace erTicketingApi.Models
{
	public class Ticket
	{
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TicketId { get; set; }

        public int Quantity { get; set; }
        public int Priority { get; set; } = 3; // default to low priority
        public DateTime DateSubmitted { get; set; }
        public DateTime DateCompleted { get; set; }
        public double NewPartCost { get; set; }

        [MaxLength(100)]
        public string? Title { get; set; }

        [MaxLength(300)]
        public string? DefectSymptom { get; set; }

        [MaxLength(50)]
        public string? PartNumber { get; set; }

        [MaxLength(80)]
        public string? Manufacturer { get; set; }

        [MaxLength(300)]
        public string? RequesterComments { get; set; }

        [MaxLength(300)]
        public string? ResolutionNote { get; set; }

        // reference UserId ( handle it in the controller)
        public int UserId { get; set; }

        // reference AreaId ( handle it in the controller)
        public int AreaId { get; set; }

        // reference EquipmentId ( handle it in the controller)
        public int EquipmentId { get; set; }

        // reference PostRepairDispoId ( handle it in the controller)
        public int PostRepairDispoId { get; set; }

        // reference CostCenterId ( handle it in the controller)
        public int CostCenterId { get; set; }

    }
}

