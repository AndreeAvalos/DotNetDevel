using System.ComponentModel.DataAnnotations.Schema;
using DotNetDevel.Entities.Base;

namespace DotNetDevel.Entities;

public class FieldSurvey: BaseEntity
{
    [Column(name: "name")] public string Name { get; set; } = null!;
    [Column(name: "title")] public string Title { get; set; } = null!;
    [Column(name: "type")] public string FieldType { get; set; } = null!;
    [Column(name: "required")] public string IsRequired { get; set; } = null!;
    [Column(name: "survey_id")] public int SurveyId { get; set; }

    public virtual SurveyEntity Survey { get; set; } = null!;
}