using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace easycnc_core.Areas.System.Models;

[Table("role")]
public class Role
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("role_id")]
    public int RoleId { get; set; }

    [Column("role_name")]
    public string? RoleName { get; set; }

    [Column("role_code")]
    public string? RoleCode { get; set; }

    [JsonIgnore]
    public List<User> Users { get; } = new List<User>();
    public List<Permission> Permissions { get;  }=new List<Permission>();
    

}