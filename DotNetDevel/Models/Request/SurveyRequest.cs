namespace DotNetDevel.Models.Request
{
    public class SurveyRequest
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public List<FieldSurveyRequest> Fields { get; set; } = null!;
        public string? Link { get; set; }
    }
}
