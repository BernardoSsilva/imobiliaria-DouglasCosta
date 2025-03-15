using ImmobileApp.Comunication.enums;

namespace ImmobileApp.Comunication.Responses.LongResponses
{
    public class ImmobileLongResponseJson
    {
        public Guid Id { get; set; } = new Guid();
        public string? LocalityInfo { get; set; }
        public ImmobileTypeEnum ImmobileType { get; set; }

        public string? LocalLink { get; set; }
        public ImmobileStatusEnum Status { get; set; }

        public Guid UserCreationId { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public string? PostalCode { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Neighborhood { get; set; }
        public bool HasScripture { get; set; }
        public string? ImmobileDescription { get; set; }

    }
}