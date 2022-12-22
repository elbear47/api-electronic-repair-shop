using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace erTicketingApi.Models
{
	public class Equipment
	{
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EquipmentId { get; set; }
        [Required]
        public string EquipmentName { get; set; }

        //Foreign Key for Area
        //[JsonIgnore]
        public virtual Area Area { get; set; }
        [ForeignKey("Area")]
        public int AreaId { get; set; }
        

    }
}

