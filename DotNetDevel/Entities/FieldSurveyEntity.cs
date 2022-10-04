using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using DotNetDevel.Entities.Base;

namespace DotNetDevel.Entities;
[Table(name: "field_survey")]
public class FieldSurveyEntity: BaseEntity
{
    [Column(name: "name")] public string Name { get; set; } = null!;
    [Column(name: "title")] public string Title { get; set; } = null!;
    [Column(name: "type")] public string FieldType { get; set; } = null!;
    [Column(name: "required")] public string IsRequired { get; set; } = null!;
    [Column(name: "survey_id"), ForeignKey(name: "survey_id")] public int SurveyId { get; set; }
    [JsonIgnore]
    public virtual SurveyEntity Survey { get; set; } = null!;
    public virtual ICollection<AnswerSurveyEntity> AnswerSurvey { get; set; } = null!;
}