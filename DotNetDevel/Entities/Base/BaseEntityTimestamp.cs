using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetDevel.Entities.Base;

public class BaseEntityTimestamp
{
    
    [Column(name: "created_at")]
    public DateTime CreatedAt { get; set; }
        
    [Column(name: "updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Column(name: "active")]
    [Required]
    public bool Active { get; set; } = true;

    [Column(name: "deleted_at")]
    public DateTime? DeletedAt { get; set; }
}