using System.Reflection.Metadata;

namespace ImmobileApp.Domain.Entities
{
    public class ImageEnitty
    {

        public Guid Id { get; set; } = new Guid();
        public string Type { get; set; } = string.Empty;
        public Byte Image { get; set; }
        public float Size { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid ImmobileId { get; set; }

        public ImmobileEntity Immobile { get; set; } = null!;

    }
}
