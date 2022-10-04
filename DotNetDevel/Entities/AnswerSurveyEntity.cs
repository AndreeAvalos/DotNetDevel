using System.ComponentModel.DataAnnotations.Schema;
using DotNetDevel.Entities.Base;

namespace DotNetDevel.Entities;

public class AnswerSurvey : BaseEntityTimestamp
{
    [Column(name: "survey_id")] public int SurveyId { get; set; }
    [Column(name: "field_survey_id")] public int FieldSurveyId { get; set; }
    [Column(name: "answer")] public string Answer { get; set; } = null!;
}