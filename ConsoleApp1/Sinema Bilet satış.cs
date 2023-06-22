using System;

class Sinema
{
    private const int KoltukKapasitesi = 50;
    private int bosKoltukSayisi;
    private int doluKoltukSayisi;
    private double ciro;
    private const double IndirimliBiletFiyati = 30;
    private const double IndirimsizBiletFiyati = 50;

    public Sinema()
    {
        bosKoltukSayisi = KoltukKapasitesi;
        doluKoltukSayisi = 0;
        ciro = 0;
    }

    public void BiletSat(int biletSayisi, bool indirimli)
    {
        if (bosKoltukSayisi >= biletSayisi)
        {
            double biletFiyati = indirimli ? IndirimliBiletFiyati : IndirimsizBiletFiyati;
            ciro += biletFiyati * biletSayisi;
            bosKoltukSayisi -= biletSayisi;
            doluKoltukSayisi += biletSayisi;
            Console.WriteLine("{0} adet {1} bilet satıldı.", biletSayisi, indirimli ? "indirimli" : "indirimsiz");
            Console.WriteLine("Toplam ciro: {0}", ciro);
        }
        else
        {
            Console.WriteLine("Salon dolu! Yeterli boş koltuk bulunmamaktadır.");
        }
    }

    public void BiletIptal(int biletSayisi, bool indirimli)
    {
        if (doluKoltukSayisi >= biletSayisi)
        {
            double biletFiyati = indirimli ? IndirimliBiletFiyati : IndirimsizBiletFiyati;
            ciro -= biletFiyati * biletSayisi;
            bosKoltukSayisi += biletSayisi;
            doluKoltukSayisi -= biletSayisi;
            Console.WriteLine("{0} adet {1} bilet iptal edildi.", biletSayisi, indirimli ? "indirimli" : "indirimsiz");
            Console.WriteLine("Toplam ciro: {0}", ciro);
        }
        else
        {
            Console.WriteLine("İptal edilecek kadar dolu koltuk bulunmamaktadır.");
        }
    }

    public double CiroOgren()
    {
        return ciro;
    }
}

class Program
{
    static void Main()
    {
        Sinema sinemaSalonu = new Sinema();

        Console.WriteLine("Sinema Bilet Satış Programına Hoş Geldiniz!");

        while (true)
        {
            Console.WriteLine("\n1. Bilet Sat\n2. Bilet İptal\n3. Ciro Öğren\n4. Çıkış");
            Console.Write("Seçiminizi yapın (1-4): ");
            string secim = Console.ReadLine();

            if (secim == "1")
            {
                Console.Write("Satılacak bilet sayısını girin: ");
                int biletSayisi;
                while (!int.TryParse(Console.ReadLine(), out biletSayisi) || biletSayisi <= 0)
                {
                    Console.WriteLine("Geçersiz giriş! Lütfen pozitif bir tamsayı girin.");
                    Console.Write("Satılacak bilet sayısını girin: ");
                }

                Console.Write("Bilet türünü girin (indirimli: 1, indirimsiz: 0): ");
                int biletTuru;
                while (!int.TryParse(Console.ReadLine(), out biletTuru) || (biletTuru != 0 && biletTuru != 1))
                {
                    Console.WriteLine("Geçersiz giriş! Lütfen 0 veya 1 değeri girin.");
                    Console.Write("Bilet türünü girin (indirimli: 1, indirimsiz: 0): ");
                }

                bool indirimli = (biletTuru == 1);

                sinemaSalonu.BiletSat(biletSayisi, indirimli);
            }
            else if (secim == "2")
            {
                Console.Write("İptal edilecek bilet sayısını girin: ");
                int biletSayisi;
                while (!int.TryParse(Console.ReadLine(), out biletSayisi) || biletSayisi <= 0)
                {
                    Console.WriteLine("Geçersiz giriş! Lütfen pozitif bir tamsayı girin.");
                    Console.Write("İptal edilecek bilet sayısını girin: ");
                }

                Console.Write("İptal edilecek bilet türünü girin (indirimli: 1, indirimsiz: 0): ");
                int biletTuru;
                while (!int.TryParse(Console.ReadLine(), out biletTuru) || (biletTuru != 0 && biletTuru != 1))
                {
                    Console.WriteLine("Geçersiz giriş! Lütfen 0 veya 1 değeri girin.");
                    Console.Write("İptal edilecek bilet türünü girin (indirimli: 1, indirimsiz: 0): ");
                }

                bool indirimli = (biletTuru == 1);

                sinemaSalonu.BiletIptal(biletSayisi, indirimli);
            }
            else if (secim == "3")
            {
                double ciro = sinemaSalonu.CiroOgren();
                Console.WriteLine("Sinema salonunun toplam cirosu: {0}", ciro);
            }
            else if (secim == "4")
            {
                Console.WriteLine("Çıkış yapılıyor...");
                break;
            }
            else
            {
                Console.WriteLine("Geçersiz seçim! Lütfen 1-4 arasında bir seçim yapın.");
            }
        }
    }
}
