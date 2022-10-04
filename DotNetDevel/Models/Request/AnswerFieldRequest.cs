namespace DotNetDevel.Models.Request
{
    public class AnswerSurveyRequest
    {
        public string Link { get; set; } = null!;
        public List<AnswerSurveyModel> Answers { get; set; } = null!;

    }

    public class AnswerSurveyModel
    {
        public int FieldSurveyId { get; set; }
        public string Answer { get; set; } = null!;
    }
}
