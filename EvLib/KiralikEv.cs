using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvLib
{
    public class KiralikEv : Ev
    {
        public static int Id ;
        public double Kira { get; set; }

        public double Depozito  { get; set; }
        
        public KiralikEv()
        {
            Id++;
        }
        public KiralikEv(byte odasayisi,byte katno, double alan, string semt,double kira,double depozito):base(odasayisi,katno,alan,semt)
        {
            Id++;
            this.Kira = kira;
            this.Depozito = depozito;
        }
        public override string ToString()
        {
            return $"Kiralık Ev:{Id}\nOda sayısı:{this.OdaSayisi}\nKat no:{this.KatNo}\nAlan(m2):{this.Alan}\nSemt:{this.Semt}\nKira:{this.Kira}\nDepozito:{this.Depozito}\n";
        }
    }   
}
    
