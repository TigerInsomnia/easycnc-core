using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using easycnc_core.Areas.System.Models;
using easycnc_core.Models;

namespace easycnc_core.Areas.System.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("username")]
        [MaxLength(50)]
        public string Username { get; set; }=string.Empty;

        [Column("realname")]
        [MaxLength(50)]
        public string Realname { get; set; }=string.Empty;

        [Column("password")]
        public string? Password { get; set; }

        [Column("address_id")]
        [JsonIgnore]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }

        [Column("dept_id")]
        [JsonIgnore]
        public int DeptId { get; set; }
        public Dept? Dept { get; set; }


        public List<Role> Roles { get; } = new List<Role>();
       

    }
}
