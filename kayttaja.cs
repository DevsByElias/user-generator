namespace salasanakayttajaharjoitus;


public class Kayttaja
{

    protected string kayttajatunnus = "";
    protected string salasana = "";



    public override string ToString()
    {
        return $"{this.kayttajatunnus}";
    }

    protected static readonly IEnumerable<object> kayttajat;

    protected void Luo(string _kayttajatunnus, string _salasana)
    {
        kayttajatunnus = _kayttajatunnus;
        salasana = _salasana;
        Console.WriteLine("käyttäjä: {0} luotu", kayttajatunnus);
    }

    protected void Ohje()
    {
        Console.WriteLine("ohjeet tulossa....");

    }

    protected virtual void NaytaKayttaja()
    {
        string kayttajatunnusVain3 = kayttajatunnus.Substring(kayttajatunnus.Length - 3);
        Console.WriteLine("--Käyttäja--");
        Console.WriteLine($"Käyttäjänimi loppuu: {kayttajatunnusVain3}");
        Console.WriteLine("Salasana: ********************");

    }
    protected bool Testaa(string kt, string ss, bool admin = false)
    {
        if (kt == kayttajatunnus && ss == salasana)
        {
            if (admin) NaytaKayttaja();
            return true;
        }
        else
        {
            return false;
        }

    }

}

class PerusPertti : Kayttaja
{
    public PerusPertti(string k, string s)
    {
        Luo(k, s);
    }

    public bool Kirjaudu(string k, string s)
    {
        if (Testaa(k, s))
        {
            Console.WriteLine("Kirjautuminen onnistui");
            Ohje();
            return true;
        }
        else
        {
            return false;
        }

    }

}

class Admin : Kayttaja
{
    private bool kayttaja;

    public override string ToString()
    {
        return $"{this.kayttajatunnus}";
    }

    public Admin(string k, string s)
    {
        Luo(k, s);
    }

    protected override void NaytaKayttaja()
    {
        Console.WriteLine("--Vain admin juttuja--");
        Console.WriteLine($"Käyttäjänimi: {kayttajatunnus}");
        Console.WriteLine($"Salasana: {salasana}");
    }


    public bool Kirjaudu(string k, string s, List<Kayttaja> kayttajat)
    {
        if (Testaa(k, s, false))
        {
            Console.WriteLine("[Admin] onnistui!");
            Console.Write("Mitä haluat tehdä?\n1. Listaa käyttäjä\n2. Lisää käyttäjät\nLopeta (Enter)");
            int arvo = Convert.ToInt32(Console.ReadLine());
            if (arvo == 1)
            {
                Console.WriteLine("Käyttäjä valitsi 1");
                Console.WriteLine("--- Perus ---");
                foreach (var kayttaja in kayttajat)
                {
                    if (kayttaja is Admin)
                    {
                        continue;
                    }
                    Console.WriteLine(kayttaja);
                }
                Console.WriteLine("--- Admin ---");
                foreach (var kayttaja in kayttajat)
                {
                    if (kayttaja is not Admin)
                    {
                        continue;
                    }
                    Console.WriteLine(kayttaja);
                }
            }
            else if (arvo == 2)
            {
                Console.WriteLine("Käyttäjä valitsi 2");
                Console.WriteLine("Anna käyttäjätunnus:");
                string kt = Console.ReadLine();
                Console.WriteLine("Anna salasana");
                string ss = Console.ReadLine();
                Console.WriteLine("Annetaan admin-oikeudet Kyllä (K) / Ei (Enter)");
                string Oikeudet = Console.ReadLine();
                string AdminOikeudet;

                if (Oikeudet == "k" || Oikeudet == "K")
                {
                    Console.WriteLine("annetaan admin oikeudet");
                    AdminOikeudet = k;
                    kayttajat.Add(new Admin(kt, ss));
                    Console.Write("Mitä haluat tehdä?\n1. Listaa käyttäjä\n2. Lisää käyttäjät\nLopeta (Enter)");
                    int num = Convert.ToInt32(Console.ReadLine());
                    if (num == 1)
                    {
                        Console.WriteLine("Käyttäjä valitsi 1");
                        Console.WriteLine("--- Perus ---");
                        foreach (var kayttaja in kayttajat)
                        {
                            if (kayttaja is Admin)
                            {
                                continue;
                            }
                            Console.WriteLine(kayttaja);
                        }
                        Console.WriteLine("--- Admin ---");
                        foreach (var kayttaja in kayttajat)
                        {
                            if (kayttaja is not Admin)
                            {
                                continue;
                            }
                            Console.WriteLine(kayttaja);
                        }
                    }
                }

                else
                {
                    AdminOikeudet = "e";
                    kayttajat.Add(new PerusPertti(kt, ss));
                    return true;
                }

            }
            else
            {
                Console.WriteLine("Virheellinen valinta");
            }
            return true;
        }
        else
        {
            return false;
        }


    }
}
