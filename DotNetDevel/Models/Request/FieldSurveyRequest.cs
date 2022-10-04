namespace DotNetDevel.Models.Request
{
    public class FieldSurveyRequest
    {
        public string Name { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string FieldType { get; set; } = null!;
        public string IsRequired { get; set; } = null!;
    }
}
