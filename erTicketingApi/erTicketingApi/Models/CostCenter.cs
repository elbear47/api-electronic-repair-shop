using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace erTicketingApi.Models
{
	public class CostCenter
	{
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CostCenterId { get; set; }

        [Required]
        [MaxLength(100)]
        public string CostCenterName { get; set; }

        //Foreign Key for Area
        [JsonIgnore]
        public virtual Area Area { get; set; }
        public int AreaId { get; set; }
        
    }
}

