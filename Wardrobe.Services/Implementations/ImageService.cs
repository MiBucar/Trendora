using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardrobe.Services.Interfaces;

namespace Wardrobe.Services.Implementations
{
    public class ImageService : IImageService
    {
        public string GetImage(byte[] image)
        {
            if (image != null && image.Length > 0)
            {
                var base64String = Convert.ToBase64String(image);
                return $"data:image/jpeg;base64,{base64String}";
            }
            return "";
        }
    }
}
