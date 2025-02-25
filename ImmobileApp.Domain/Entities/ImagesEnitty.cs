using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ImmobileApp.Domain.Entities
{
    public class ImagesEnitty
    {

        private Guid Id { get; set; } = new Guid();
        private string Type { get; set; } = string.Empty;
        private Blob Image { get; set; }
        private float Size { get; set; }
        private string Name { get; set; } = string.Empty;
private Guid ImmobileId { get; set; }
    }
}
