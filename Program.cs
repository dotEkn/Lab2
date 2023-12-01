
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

class Program
{

    // Jag har tagit hjälp av YouTube, ChatGPT och läroboken, samt exempelkoden för Labb2 för att skapa detta program.
    // Youtubekanal: P R O X I M I T Y
    // Pro C# with .NET 6 - Andrew Troelsen
    // ChatGPT. - Läs reflektion för att se vad den har använts till.
    // Skapad av: William Ekengren - HDu, IT-Säk & Mjukvarutest.

    static void Main()
    {
        int MaxAntal = 1000;
        string[] namn = new string[MaxAntal];
        int[] ålder = new int[MaxAntal];
        int antalmedlemmar = 0;


        while (true)
        {
            // Menyval anges i terminalen, där man får navigera med hjälp av siffror -

            Console.Clear();

            Console.WriteLine("Välkommen till detta program!");
            Console.WriteLine("Navigera med hjälp av siffror!");
            Console.WriteLine("1: Skriv in dina familjemedlemmar");
            Console.WriteLine("2: Visa Familjemedlemmar");
            Console.WriteLine("3: Summa & medelålder på medlemmar");
            Console.WriteLine("4: Avsluta programmet!");


            string alternativ = Console.ReadLine();

            switch (alternativ)
            {
                case "1":
                    antalmedlemmar = Medlemmar(namn, ålder);
                    break;

                case "2":
                    UtskriftMedlemmar(namn, ålder, antalmedlemmar);
                    break;

                case "3":
                    Summaålder(namn, ålder, antalmedlemmar);
                    break;

                case "4":
                    Environment.Exit(0);
                    break;


            }
            Console.WriteLine("\nTryck på en tangent för att fortsätta!");
            Console.ReadKey();
        }

        static int Medlemmar(string[]namn, int[] ålder)
        {
            // Funktion som berättar för användaren vad den ska göra, i detta fall, hur många familjemedlemmar har du?
            // Den lagrar hur många familjemedlemmar man har, sedan frågar programmet hur gammal den personen man skrivit in är.

            Console.WriteLine("Hur många familjemedlemmar har du?");
            if (int.TryParse(Console.ReadLine(), out int antalmedlemmar) && antalmedlemmar > 0)
            {
                for (int i = 0; i < antalmedlemmar; i++)
                {
                    Console.WriteLine("Ange namn för familjemedlem: " + i);
                    namn[i] = Console.ReadLine();

                    Console.WriteLine("Ange ålder för: " + namn[i]);
                    if (int.TryParse(Console.ReadLine(), out ålder[i]))
                    {
                        Console.WriteLine($"Medlem {namn[i]} är tillagd");
                    }
                    else
                    {
                        // Ingen siffra angiven - skickas tillbaka för att försöka igen på samma medlem som är angiven.
                        Console.WriteLine("Ogiltig ålder, försök igen!");
                        i--;
                    }
                }
                return antalmedlemmar;
                
            }
            else
            {
                Console.WriteLine("Ogiltigt antal personer, försök igen!");
               

            }
            return 0;
        }


        // Funktion som skriver ut alla medlemmar angivna, samt deras ålder.

        static void UtskriftMedlemmar(string[]namn, int[] ålder, int antalmedlemmar)
        {
            Console.WriteLine("Skriver ut alla medlemmar angivna!");

            for(int i = 0; i < antalmedlemmar; i++) 
            {
                Console.WriteLine($"Namn: {namn[i]}, Ålder: {ålder[i]}");
            }
        }

        // Funktion som räknar ut summan av alla åldrar på angivna medlemmar samt medelåldern.

        static void Summaålder(string[] namn, int[] ålder, int antalmedlemmar)
        {
            {

                if (antalmedlemmar > 0)
                {
                    // Summan av åldrarna beräknas här.

                    int summaålder = 0;
                        for(int i = 0;i < antalmedlemmar;i++)
                    {
                        summaålder += ålder[i];
                    }
                    Console.WriteLine($"Summan av åldrarna är: {summaålder}");

                    // Medelåldern beräknas här.

                    double mellanålder = ålder.Take(antalmedlemmar).Average();

                    Console.WriteLine($"Mellanåldern för familjemedlemmarna är: {mellanålder:F2}");
                }
                else
                {
                    // Skriver du en bokstav eller annat tecken som inte är en siffra, så skickas man tillbaka till meny.
                    Console.WriteLine("Inga familjemedlemmar har angetts än!");
                }
            }
        }
    }
}

