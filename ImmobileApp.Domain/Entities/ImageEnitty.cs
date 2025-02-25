using System.Reflection.Metadata;

namespace ImmobileApp.Domain.Entities
{
    public class ImageEnitty
    {

        private Guid Id { get; set; } = new Guid();
        private string Type { get; set; } = string.Empty;
        private Blob Image { get; set; }
        private float Size { get; set; }
        private string Name { get; set; } = string.Empty;
        private Guid ImmobileId { get; set; }

    }
}
