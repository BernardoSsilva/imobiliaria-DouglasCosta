using ImmobileApp.Comunication.enums;

namespace ImmobileApp.Comunication.Responses.ShortResponses
{
    public class ImmobileShortResponseJson
    {
        public Guid Id { get; set; }
        public required string LocalityInfo { get; set; }
        public ImmobileTypeEnum ImmobileType { get; set; }
        public ImmobileStatusEnum Status { get; set; }
        public string PostalCode { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;
    }
}