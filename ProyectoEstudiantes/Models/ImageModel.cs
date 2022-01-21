using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstudiantes.Models
{
    class ImageModel
    {
        public string _id { set; get;}
        public Dictionary<string, byte[]> imagenes { set; get;}

        public ImageModel()
        {
            imagenes = new Dictionary<string, byte[]>();
        }
    }
}
