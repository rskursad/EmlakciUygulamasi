using EvLib;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Configuration;

namespace EmlakciUygulamasi
{

    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Emlak Uygulaması");
                Console.WriteLine("\nSeçiniz:\n1-Kiralık Ev(1/k)\n2-satılık Ev(2/s)");
                string cevap1 = Console.ReadLine().ToLower();
                if (cevap1 == "1" || cevap1 == "k")
                {
                    KiralikEvMenu();
                    break;
                }
                else if (cevap1 == "2" || cevap1 == "s")
                {
                    SatilikEvMenu();
                    break;
                }
                else
                {
                    Console.WriteLine("Hatalı Giriş! Tekrar deneyin.");
                }
            }
            
            Console.WriteLine("Çıkmak için 'x' tuşuna,ana menü için 'a' tuşuna basabilirsiniz.");
            var BasılanTus = Console.ReadKey().Key;
            switch (BasılanTus)
            {
                case ConsoleKey.A:
                    Main(args);
                    break;
                case ConsoleKey.X:
                    Environment.Exit(0);
                    break;
            }
        }

        public static void KiralikTxtYaz(List<KiralikEv> list)
        {
            string Txt = "C:\\Kürşad\\Kod\\Programlama Temelleri\\EmlakciUygulaması\\EmlakcıUygulaması\\KiralikEvler.txt";
            using (StreamWriter write = new StreamWriter(Txt,true))
            {
                foreach (var kev in list)
                {
                    write.WriteLine(kev.ToString());
                    write.WriteLine();
                }

            }
        }
        public static void SatilikTxtYaz(List<SatilikEv> list)
        {
            string Txt = "C:\\Kürşad\\Kod\\Programlama Temelleri\\EmlakciUygulaması\\EmlakcıUygulaması\\SatilikEvler.txt";
            using (StreamWriter write = new StreamWriter(Txt,true))
            {
                foreach (var sev in list)
                {
                    write.WriteLine(sev.ToString()); ;
                    write.WriteLine();
                }

            }
        }
        public static void KiralikTxtOku()
        { 
            string Txt = "C:\\Kürşad\\Kod\\Programlama Temelleri\\EmlakciUygulaması\\EmlakcıUygulaması\\KiralikEvler.txt";
            using (StreamReader read = new StreamReader(Txt))
            {
                string veri = read.ReadToEnd();
                Console.WriteLine(veri);
            }
        }
        public static void SatilikTxtOku()
        {
            string Txt = "C:\\Kürşad\\Kod\\Programlama Temelleri\\EmlakciUygulaması\\EmlakcıUygulaması\\SatilikEvler.txt";
            using (StreamReader read = new StreamReader(Txt))
            {
                string veri = read.ReadToEnd();
                Console.WriteLine(veri);
            }
        }
        public static void KiralikEvMenu()
        {

            while (true)
            {
                Console.WriteLine("Bölüm: Kiralık Evler");
                Console.WriteLine("1-Kayıtlı kiralık ev görüntüleme (1/k)\n2-Yeni kiralık ev girişi(2/y)");
                string cevap2 = Console.ReadLine().ToLower();
                if (cevap2 == "1" || cevap2 == "k")
                {
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("Kayıtlı Kiralık Ev Bilgileri:");
                    KiralikTxtOku();
                    break;
                }
                else if (cevap2 == "2" || cevap2 == "y")
                {
                    List<KiralikEv> KiralikEvler = new List<KiralikEv>();
                    string cevapK;
                    KiralikEv.Id = Properties.Settings.Default.kevID;
                    do
                    {
                        var kev = new KiralikEv();
                        Console.WriteLine("Yeni Kiralık Ev Bilgilerini giriniz:\n");
                        Console.WriteLine($"Kiralık Ev {KiralikEv.Id}");
                        Console.WriteLine("Oda Sayısı:");
                        kev.OdaSayisi = byte.Parse(Console.ReadLine());
                        Console.WriteLine("Kat no:");
                        kev.KatNo = byte.Parse(Console.ReadLine());
                        Console.WriteLine("Alan:");
                        kev.Alan = double.Parse(Console.ReadLine());
                        Console.WriteLine("Semt:");
                        kev.Semt = Console.ReadLine();
                        Console.WriteLine("Kira:");
                        kev.Kira = double.Parse(Console.ReadLine());
                        Console.WriteLine("Depozito");
                        kev.Depozito = double.Parse(Console.ReadLine());
                        KiralikEvler.Add(kev);
                        KiralikEvler.Capacity = KiralikEvler.Count;
                        Console.WriteLine("\nYeni kayıt girmeye devam etmek istiyor musunuz? (evet/hayır)");
                        cevapK = Console.ReadLine().ToLower();

                    } while (cevapK == "evet");
                     
                    Properties.Settings.Default.kevID = KiralikEv.Id;
                    Properties.Settings.Default.Save();
                    
                    bool Hata = false;
                    try
                    {
                        KiralikTxtYaz(KiralikEvler);
                    }
                    catch (Exception ex)
                    {
                        Hata = true;
                        Console.WriteLine("Bir hata oluştu:\n" + ex.Message);
                    }
                    if (Hata != true)
                    {
                        Console.WriteLine("Kiralık Ev Verileri başarıyla kaydedildi.");
                    }
                    break;

                }
                else
                {
                    Console.WriteLine("Hatalı Giriş! Tekrar deneyin.");
                }
            }
        }

        public static void SatilikEvMenu()
        {
            while (true)
            {
                Console.WriteLine("Bölüm: Satılık Evler");
                Console.WriteLine("1-Kayıtlı satılık ev görüntüleme (1/k)\n2-Yeni satılık ev girişi(2/y)");
                string cevapS = Console.ReadLine().ToLower();

                if (cevapS == "1" || cevapS == "k")
                {
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("Kayıtlı satılık Ev Bilgileri:\n");
                    SatilikTxtOku();
                    break;
                }
                else if (cevapS == "2" || cevapS == "y")
                {
                    List<SatilikEv> SatilikEvler = new List<SatilikEv>();
                    string cevapK;
                    SatilikEv.Id = Properties.Settings.Default.sevID;
                    do
                    {
                        Console.WriteLine("Yeni Satılık Ev Bilgilerini giriniz:");
                        var sev = new SatilikEv();
                        Console.WriteLine($"Satılık Ev {SatilikEv.Id}");
                        Console.WriteLine("Oda Sayısı:");
                        sev.OdaSayisi = byte.Parse(Console.ReadLine());
                        Console.WriteLine("Kat no:");
                        sev.KatNo = byte.Parse(Console.ReadLine());
                        Console.WriteLine("Alan:");
                        sev.Alan = double.Parse(Console.ReadLine());
                        Console.WriteLine("Semt:");
                        sev.Semt = Console.ReadLine();
                        Console.WriteLine("Fiyat:");
                        sev.Fiyat = double.Parse(Console.ReadLine());
                        SatilikEvler.Add(sev);
                        SatilikEvler.Capacity = SatilikEvler.Count;
                        Console.WriteLine();
                        Console.WriteLine("Yeni kayıt girmeye devam etmek istiyor musunuz? (evet/hayır)");
                        cevapK = Console.ReadLine().ToLower();

                    } while (cevapK == "evet");

                    
                    Properties.Settings.Default.sevID = SatilikEv.Id;
                    Properties.Settings.Default.Save();
                    bool Hata = false;
                    try
                    {
                        SatilikTxtYaz(SatilikEvler);
                    }
                    catch (Exception ex)
                    {
                        Hata = true;
                        Console.WriteLine("Bir hata oluştu:\n" + ex.Message);
                    }
                    if (Hata != true)
                    {
                        Console.WriteLine("Kiralık Ev Verileri başarıyla kaydedildi.");
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Hatalı giriş! Tekrar deneyin.");
                }
            }
        }
    }
}






