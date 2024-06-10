using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvLib
{
    public class SatilikEv:Ev
    {
        public static int Id;
        public double Fiyat { get; set; }
       
        public SatilikEv()
        {
            Id++;
        }
        public SatilikEv(byte odasayisi,byte katno,double alan,string semt,double fiyat):base(odasayisi,katno,alan,semt)
        {
            Id++;
            this.Fiyat = fiyat;  
        }
        public override string ToString()
        {
            return $"Satılık Ev:{Id}\nOda sayısı:{this.OdaSayisi}\nKat no:{this.KatNo}\nAlan(m2):{this.Alan}\nSemt:{this.Semt}\nFiyat:{this.Fiyat}\n";
        }
    }
    
}
