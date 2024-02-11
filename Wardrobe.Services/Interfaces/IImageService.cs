using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardrobe.Services.Interfaces
{
    public interface IImageService
    {
        public string GetImage(byte[] image);
    }
}
