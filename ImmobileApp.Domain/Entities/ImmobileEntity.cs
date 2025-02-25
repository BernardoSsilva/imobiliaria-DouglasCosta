using ImmobileApp.Domain.enums;

namespace ImmobileApp.Domain.Entities
{
    public class ImmobileEntity
    {
        private Guid Id { get; set; } = new Guid();
        private string LocalityInfo { get; set; } = string.Empty;
        private ImmobileTypeEnum ImmobileType { get; set; } = ImmobileTypeEnum.LAND;

        private string? LocalLink { get; set; } = string.Empty;

        private ImomobileStatusEnum Status { get; set; } = ImomobileStatusEnum.INANALYSIS;

        private Guid UserCreationId { get; set; }
        
        private DateTime CreationDate { get; set; } = DateTime.UtcNow;

        private DateTime? UpdateDate { get; set; }

        private string PostalCode { get; set; } = string.Empty;

        private string State { get; set; } = string.Empty;

        private string City { get; set; } = string.Empty;

        private string Street { get; set; } = string.Empty;

        private string Neighborhood { get; set; } = string.Empty;

        private bool HasScripture { get; set; } = false;

        private string? ImmobileDescription { get; set; }

        
    }
}
