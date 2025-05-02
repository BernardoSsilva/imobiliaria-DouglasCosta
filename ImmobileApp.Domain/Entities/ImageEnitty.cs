using System.Reflection.Metadata;

namespace ImmobileApp.Domain.Entities
{
    public class ImageEnitty
    {

        public Guid Id { get; set; } = new Guid();
        public string Type { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public float Size { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid ImmobileId { get; set; }
        public string CloudnaryPublicId { get; set; } = string.Empty;
        public ImmobileEntity Immobile { get; set; } = null!;

    }
}
