using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmobileApp.Comunication.Responses.ShortResponses
{
    public class ImageShortResponseJson
    {
        public Guid Id { get; set; } = new Guid();
        public string ImageUrl { get; set; } = string.Empty;
        public Guid ImmobileId { get; set; }

    }
}
