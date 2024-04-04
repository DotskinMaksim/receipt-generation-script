using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Ostutšeki loomine
        string[] tooted = { "Toode 1", "Toode 2", "Toode 3" };
        double[] hinnad = { 10.50, 20.25, 5.75 };
        double kokku = 0;

        // Ostutšeki väljastamine ja kogusumma arvutamine
        Console.WriteLine("=====================================");
        Console.WriteLine("|           Ostutšekk               |");
        Console.WriteLine("=====================================");
        Console.WriteLine("| Toode        |      Hind       |");
        Console.WriteLine("|--------------|-----------------|");
        for (int i = 0; i < tooted.Length; i++)
        {
            Console.WriteLine($"| {tooted[i],-12} | {hinnad[i],14:f2} |");
            kokku += hinnad[i];
        }
        Console.WriteLine("=====================================");
        Console.WriteLine($"|{"Kokku:",-12} | {kokku,14:f2} |");
        Console.WriteLine("=====================================");

        // Ostutšeki salvestamine faili
        string kaustatee = @"/Users/maksimdockin/Projects/kvitung/kvitung/arved"; // Kausta tee, kuhu fail salvestatakse
        string failiNime = $"Check_{DateTime.Now:yyyyMMddHHmmss}.txt";
        string failiTee = Path.Combine(kaustatee, failiNime);

        try
        {
            // Kausta loomine, kui seda ei eksisteeri
            if (!Directory.Exists(kaustatee))
            {
                Directory.CreateDirectory(kaustatee);
            }

            // Ostutšeki kirjutamine faili
            using (StreamWriter kirjutaja = new StreamWriter(failiTee))
            {
                kirjutaja.WriteLine("=====================================");
                kirjutaja.WriteLine("|           Ostutšekk               |");
                kirjutaja.WriteLine("=====================================");
                kirjutaja.WriteLine("| Toode        |      Hind       |");
                kirjutaja.WriteLine("|--------------|-----------------|");
                for (int i = 0; i < tooted.Length; i++)
                {
                    kirjutaja.WriteLine($"| {tooted[i],-12} | {hinnad[i],14:f2} |");
                }
                kirjutaja.WriteLine("=====================================");
                kirjutaja.WriteLine($"|{"Kokku:",-12} | {kokku,14:f2} |");
                kirjutaja.WriteLine("=====================================");
            }

            Console.WriteLine($"Ostutšekk edukalt salvestatud faili: {failiTee}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Viga: {ex.Message}");
        }
    }
}
