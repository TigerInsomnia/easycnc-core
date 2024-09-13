using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using easycnc_core.Areas.System.Models;

namespace easycnc_core.Models
{
    [Table("address")]
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("address_id")]
        public int AddressId { get; set; }

        [Column("province")]
        public string Province { get; set; } = string.Empty;

        [Column("city")]
        public string City { get; set; }=string.Empty;

        [Column("county")]
        public string County { get; set; } = string.Empty;


        [Column("detail")]
        public string Detail { get; set; } = string.Empty;

        [JsonIgnore]
        public User? User { get; set; }

    }
}
