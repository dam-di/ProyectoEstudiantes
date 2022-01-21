using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstudiantes.Models
{
    class ImagesListModel
    {
        public string _id { set; get; }
        public ObservableCollection<Dictionary<string,byte[]>> imagenes { set; get; }

        public ImagesListModel()
        {
            imagenes = new ObservableCollection<Dictionary<string, byte[]>>();
        }
        
    }
}
