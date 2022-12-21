using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace erTicketingApi.Models
{
	public class Area
	{
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AreaId { get; set; }

        [Required]
        [MaxLength(50)]
        public string AreaName { get; set; }

        [JsonIgnore]
        public virtual List<Equipment> Equipments { get; set; }
        [JsonIgnore]
        public virtual List<CostCenter> CostCenters { get; set; }


    }
}

