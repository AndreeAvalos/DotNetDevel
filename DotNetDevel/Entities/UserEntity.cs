using System.ComponentModel.DataAnnotations.Schema;
using DotNetDevel.Entities.Base;

namespace DotNetDevel.Entities;
[Table(name: "user")]
public class UserEntity: BaseEntity
{
    [Column(name: "name")] public string Name { get; set; } = null!;
    [Column(name: "password")] public string Password { get; set; } = null!;
}