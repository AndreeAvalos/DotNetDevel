namespace DotNetDevel.Models
{
    public class AnswerResponse
    {
        public string Link { get; set; } = null!;
        public List<AnswerModel> Answers { get; set; } = null!;
    }

    public class AnswerModel
    {
        public string Question { get; set; } = null!;
        public List<string> Answers { get; set; } = null!;
    }
}
