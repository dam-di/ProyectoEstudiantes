using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstudiantes.Models
{
    public class ResponseModel
    {
        public object data { set; get; }
        public bool resultOk { set; get; }

        public ResponseModel()
        {
            data = "Error consulta";
            resultOk = false;
        }
    }
}
