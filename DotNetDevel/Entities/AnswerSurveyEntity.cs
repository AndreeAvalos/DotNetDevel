using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using DotNetDevel.Entities.Base;

namespace DotNetDevel.Entities;
[Table(name: "answer_survey")]
public class AnswerSurveyEntity : BaseEntity
{
    [Column(name: "field_survey_id"), ForeignKey("field_survey_id")] public int FieldSurveyId { get; set; }
    [Column(name: "answer")] public string Answer { get; set; } = null!;
    [JsonIgnore]
    public virtual FieldSurveyEntity FieldSurvey { get; set; } = null!;
}
