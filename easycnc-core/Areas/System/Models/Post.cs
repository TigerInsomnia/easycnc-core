using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace easycnc_core.Areas.System.Models;

[Table("post")]
public class Post
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("post_id")]
    public int PostId { get; set; }

    [Column("post_name")]
    public string? PostName { get; set; }

    [Column("post_code")]
    public string? PostCode { get; set; }

}