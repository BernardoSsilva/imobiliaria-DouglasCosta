using ImmobileApp.Comunication.enums;

namespace ImmobileApp.Domain.Entities
{
    public class ImmobileEntity
    {
        public Guid Id { get; set; } = new Guid();
        public string LocalityInfo { get; set; } = string.Empty;
        public string ImmobileType { get; set; } = ImmobileTypeEnum.LAND.ToString();

        public string? LocalLink { get; set; } = string.Empty;

        public string Status { get; set; } = ImomobileStatusEnum.INANALYSIS.ToString();

        public Guid UserCreationId { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdateDate { get; set; }

        public string PostalCode { get; set; } = string.Empty;

        public string State { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;

        public string Neighborhood { get; set; } = string.Empty;

        public bool HasScripture { get; set; } = false;

        public string? ImmobileDescription { get; set; }

        public UserEntity User { get; set; } = null!;
        public ICollection<ImageEnitty> Images { get; } = new List<ImageEnitty>();
        
    }
}
