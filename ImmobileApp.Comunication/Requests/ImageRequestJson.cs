using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ImmobileApp.Comunication.Requests
{
    public class ImageRequestJson
    {
        public IFormFile File { get; set; }
    }
}
