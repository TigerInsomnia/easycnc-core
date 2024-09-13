using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace easycnc_core.Areas.System.Models;

[Table("permission")]
public class Permission
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("permission_id")]
    public int PermissionId { get; set; }

    [Required]
    [Column("permission_name")]
    public string? PermissionName { get; set; }


    [Column("permission_code")]
    public string? PermissionCode { get; set; }

    [JsonIgnore]
    public List<Role> Roles { get; }=new List<Role>();
}