using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace easycnc_core.Areas.System.Models;

[Table("role_permission")]
[PrimaryKey(nameof(RoleId), nameof(PermissionId))]
public class RolePermission
{
    [Column("role_id")]
    public int RoleId { get; set; }

    [Column("permission_id")]
    public int PermissionId { get; set; }
}