namespace salasanakayttajaharjoitus;
public class program
{


    public static List<Kayttaja> kayttajat = new List<Kayttaja>();  
    static void Main(string[] args)
    {

        kayttajat.Add(new PerusPertti("qwerty", "asdasd")); 
        kayttajat.Add(new PerusPertti("asdfg", "password1"));
        kayttajat.Add(new Admin("admin", "admin"));
        kayttajat.Add(new Admin("zxcvb", "admin"));

        LisääKäyttäjä();                                    

        Console.WriteLine("Anna käyttäjätunnus:");
        string kt = Console.ReadLine();
        Console.WriteLine("Anna salasana");
        string ss = Console.ReadLine();
        bool pääsysallitty = false;




        foreach (PerusPertti kayttaja in kayttajat.OfType<PerusPertti>())   
        {
            if (kayttaja.Kirjaudu(kt, ss))                                  
            {
                return;
            }
        }


        foreach (Admin kayttaja in kayttajat.OfType<Admin>())
        {
            if (kayttaja.Kirjaudu(kt, ss, kayttajat))
            {
                pääsysallitty = true;
                break;
            }
            if (pääsysallitty)
            {
                Console.WriteLine("Kirjautuminen onnistui!");
            }
            else
            {
                Console.WriteLine("Kirjautuminen epäonnistui!");
                break;
            }
        }


    }
    static void LisääKäyttäjä()
    {
        Console.WriteLine("Lisätään uusi käyttäjä... Luodaanko peruskäyttäjä vaiko admin käyttäjä? (perus/admin)");
        string valinta = Console.ReadLine().ToLower();

        if (valinta == "perus")
        {
            Console.WriteLine("Anna käyttäjätunnus:");
            string kt = Console.ReadLine();
            Console.WriteLine("Anna salasana:");
            string ss = Console.ReadLine();

            kayttajat.Add(new PerusPertti(kt, ss));

            Console.WriteLine("Peruskäyttäjä lisätty.");
        }
        else if (valinta == "admin")
        {
            Console.WriteLine("Anna käyttäjätunnus:");
            string kt = Console.ReadLine();
            Console.WriteLine("Anna salasana:");
            string ss = Console.ReadLine();

            kayttajat.Add(new Admin(kt, ss));

            Console.WriteLine("Admin käyttäjä lisätty.");
        }
        else
        {

        }
    }

}









