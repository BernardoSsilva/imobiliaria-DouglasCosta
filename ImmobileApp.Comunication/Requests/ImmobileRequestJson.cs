using ImmobileApp.Comunication.enums;

namespace ImmobileApp.Comunication.Requests
{
    public class ImmobileRequestJson
    {
        public string? LocalityInfo { get; set; }
        public ImmobileTypeEnum? ImmobileType { get; set; }

        public string? LocalLink { get; set; }

        public double Value { get; set; }

        public string? PostalCode { get; set; }
        public BrazilianState? State { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Neighborhood { get; set; }
        public bool? HasScripture { get; set; } = false;

        public string? ImmobileDescription { get; set; }
    }
}