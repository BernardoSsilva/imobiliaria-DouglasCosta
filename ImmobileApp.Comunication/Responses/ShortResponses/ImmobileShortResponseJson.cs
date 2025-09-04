using ImmobileApp.Comunication.enums;

namespace ImmobileApp.Comunication.Responses.ShortResponses
{
    public class ImmobileShortResponseJson
    {
        public Guid Id { get; set; }
        public required string LocalityInfo { get; set; }
        public ImmobileTypeEnum ImmobileType { get; set; }
        public double Value { get; set; }
        public string PostalCode { get; set; } = string.Empty;
        public BrazilianState State { get; set; }

        public string City { get; set; } = string.Empty;

        public string LocalLink { get; set; } = string.Empty;
    }
}