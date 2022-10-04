using System.ComponentModel.DataAnnotations.Schema;
using DotNetDevel.Entities.Base;

namespace DotNetDevel.Entities;
[Table(name: "survey")]
public class SurveyEntity: BaseEntity
{
    [Column(name: "name")] public string Name { get; set; } = null!;
    [Column(name: "description")] public string Description { get; set; } = null!;
    [Column(name: "link")] public string Link { get; set; } = null!;

    public virtual ICollection<FieldSurveyEntity> FieldSurvey{ get; set; } = null!;
}