using System;
using System.Collections.Generic;

class Isikukood
{
    private readonly string _isikukood;

    public Isikukood(string isikukood)
    {
        _isikukood = isikukood;
    }
    public bool Pikkus()
    {
        return _isikukood.Length == 11;
    }

    public string Sugu()
    {
        int firstDigit = int.Parse(_isikukood[0].ToString());

        if (new[] { 1, 3, 5 }.Contains(firstDigit))
        {
            return "mees";
        }
        else if (new[] { 2, 4, 6 }.Contains(firstDigit))
        {
            return "naine";
        }
        else
        {
            return "viga";
        }
    }

    public string Sunnipaev()
    {
        string aastaNumber = _isikukood.Substring(1, 2);
        int kuu;
        int paev;

        if (int.TryParse(_isikukood.Substring(3, 2), out kuu) && int.TryParse(_isikukood.Substring(5, 2), out paev))
        {
            if (kuu > 0 && kuu < 13 && paev > 0 && paev < 32)
            {
                string year = "20";

                if (_isikukood[0] == '1' || _isikukood[0] == '2')
                {
                    year = "18";
                }
                else if (_isikukood[0] == '3' || _isikukood[0] == '4')
                {
                    year = "19";
                }

                string date = $"{paev:D2}.{kuu:D2}.{year}{aastaNumber}";
                return date;
            }
        }

        return "viga";
    }

    public string Sunnikoht()
    {
        string tahed8910 = _isikukood.Substring(7, 3);
        int t = int.Parse(tahed8910);

        if (t > 1 && t < 10)
        {
            return "Kuressaare Haigla";
        }
        else if (t > 11 && t < 19)
        {
            return "Tartu Ülikooli Naistekliinik, Tartumaa, Tartu";
        }
        else if (t > 21 && t < 220)
        {
            return "Ida-Tallinna Keskhaigla, Pelgulinna sünnitusmaja, Hiiumaa, Keila, Rapla haigla, Loksa haigla";
        }
        else if (t > 221 && t < 270)
        {
            return "Ida-Viru Keskhaigla (Kohtla-Järve, endine Jõhvi)";
        }
        else if (t > 271 && t < 370)
        {
            return "Maarjamõisa Kliinikum (Tartu), Jõgeva Haigla";
        }
        else if (t > 371 && t < 420)
        {
            return "Narva Haigla";
        }
        else if (t > 421 && t < 470)
        {
            return "Pärnu Haigla";
        }
        else if (t > 471 && t < 490)
        {
            return "Pelgulinna Sünnitusmaja (Tallinn), Haapsalu haigla";
        }
        else if (t > 491 && t < 520)
        {
            return "Järvamaa Haigla (Paide)";
        }
        else if (t > 521 && t < 570)
        {
            return "Rakvere, Tapa haigla";
        }
        else if (t > 571 && t < 600)
        {
            return "Valga Haigla";
        }
        else if (t > 601 && t < 650)
        {
            return "Viljandi Haigla";
        }
        else if (t > 651 && t < 700)
        {
            return "Lõuna-Eesti Haigla (Võru), Põlva Haigla";
        }
        else
        {
            return "Välismaal";
        }
    }

    public void Lause()
    {
        Console.WriteLine($"See on {Sugu()} ta on sündinud {Sunnipaev()}, tema sünnikoht on {Sunnikoht()}");
    }

    public int Kontrollnr()
    {
        int[] astme1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1 };
        int[] astme2 = { 3, 4, 5, 6, 7, 8, 9, 1, 2, 3 };

        int[] ikList = new int[10];
        for (int i = 0; i < 10; i++)
        {
            ikList[i] = int.Parse(_isikukood[i].ToString());
        }

        int summa = 0;
        for (int i = 0; i < 10; i++)
        {
            summa += ikList[i] * astme1[i];
        }

        int s = (summa / 11) * 11;
        int jaak = summa - s;

        if (jaak == int.Parse(_isikukood[10].ToString()))
        {
            return jaak;
        }
        else if (jaak == 10)
        {
            return jaak;
        }
        else
        {
            summa = 0;
            for (int i = 0; i < 10; i++)
            {
                summa += ikList[i] * astme2[i];
            }

            s = (summa / 11) * 11;
            jaak = summa - s;
            return jaak;
        }
    }

    public void Koodikontroll(List<string> arvud, List<string> ikoodid)
    {
        if (!Pikkus())
        {
            Console.WriteLine("Liiga pikk või lühike isikukood");
            arvud.Add(_isikukood);
        }
        else
        {
            string suguResult = Sugu();
            if (suguResult == "viga")
            {
                Console.WriteLine("Esimene täht ei ole õige");
                arvud.Add(_isikukood);
            }
            else
            {
                string sunnipaevResult = Sunnipaev();
                if (sunnipaevResult == "viga")
                {
                    Console.WriteLine("2-7 tähed on vead");
                    arvud.Add(_isikukood);
                }
                else
                {
                    Lause();
                    ikoodid.Add(_isikukood);
                }
            }
        }
    }

    public void NaisedMehed(List<string> ikoodid)
    {
        List<string> mehed = new List<string>();
        List<string> naised = new List<string>();
        foreach (string kood in ikoodid)
        {
            if (int.Parse(kood[0].ToString()) % 2 == 0)
            {
                naised.Add(kood);
            }
            else
            {
                mehed.Add(kood);
            }
        }

        Console.WriteLine("Mehed: " + string.Join(", ", mehed));
        Console.WriteLine("Naised: " + string.Join(", ", naised));
    }
}

