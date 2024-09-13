using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace easycnc_core.Areas.System.Models;

[Table("user_role")]
[PrimaryKey(nameof(UserId), nameof(RoleId))]
public class UserRole
{
    [Column("user_id")]
    public int UserId { get; set; }
    [Column("role_id")]
    public int RoleId { get; set; }

}
