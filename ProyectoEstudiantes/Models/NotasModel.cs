using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoEstudiantes.Models
{
    public class NotasModel : INotifyPropertyChanged, ICloneable
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        private string psp;
        public string PSP { get { return psp; } set { psp = value; OnPropertyChanged(nameof(PSP)); } }

        private string sge;
        public string SGE { get { return sge; } set { sge = value; OnPropertyChanged( nameof(SGE)); } }
        private string di;
        public string DI { get { return di; } set { di = value; OnPropertyChanged(nameof (DI)); } }
        private string pmdm;
        public string PMDM { get { return pmdm; } set { pmdm = value; OnPropertyChanged(nameof(PMDM));} }
        private string ad;
        public string AD { get { return ad; } set { ad = value; OnPropertyChanged(nameof(AD)); } }
        private string eie;
        public string EIE { get { return eie; } set { eie=value; OnPropertyChanged(nameof(EIE));} }

        public NotasModel()
        {
            psp = "NA";
            sge = "NA";
            di = "10";
            pmdm = "NA";
            ad = "NA";
            eie = "NA";
        }
    }
}
