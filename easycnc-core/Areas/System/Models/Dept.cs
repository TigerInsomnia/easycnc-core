using easycnc_core.Areas.System.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace easycnc_core.Areas.System.Models;

[Table("dept")]
public class Dept
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("dept_id")]
    public int DeptId { get; set; }

    [Column("dept_name")]
    public string? DeptName { get; set; }

    [Column("dept_code")]
    public string? DeptCode { get; set; }

    [Column("parent_id")]
    public int ParentId { get; set; }


    [JsonIgnore]
    public List<User> Users { get; } = new List<User>();

}