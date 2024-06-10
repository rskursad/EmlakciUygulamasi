namespace EvLib
{
    public abstract class Ev
    {
        public byte OdaSayisi { get; set; }

        public byte KatNo { get; set; }

        public double Alan { get; set; }

        public string Semt { get; set; }

        public Ev()
        {
            
        }
        public Ev(byte odasayisi,byte katno,double alan,string semt)
        {
            this.OdaSayisi = odasayisi;
            this.KatNo = katno;
            this.Alan = alan;
            this.Semt= semt;
        }

        public abstract string ToString(); 
    }
}
