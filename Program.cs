using System;

class Program
{
    static void Main()
    {
        
        TemperatureSensor s = new TemperatureSensor("SENZOR_01", 10.0, 50.0);
        s.AddReading(25.0);

        Console.WriteLine("Senzor creat: " + s.Id);
        Console.WriteLine("Temperatura init: " + s.GetLastReading('C') + " C");
        Console.WriteLine("\nATACURI");

        // s.Min = 100; s.Max = -20; 
        //  NU MAI COMPILEAZA 
        s.SetThresholds(100, -20); 
        Console.WriteLine("atacul 1 respins. nr erori: " + s.ErrorCount);

        //s.Value = -500; 
        // NU MAI COMPILEAZA
        s.AddReading(-500); 
        Console.WriteLine("atacul 2 respins. nr erori: " + s.ErrorCount);

        // s.Unit = "F"
        //  cerem doar afisarea in F
        Console.WriteLine("atacul 3 neutralizat. Valoare in F: " + s.GetLastReading('F') + " F");

        // s.History.Clear(); 
        // NU MAI COMPILEAZA 
        Console.WriteLine("atacul 4 blocat la compilare .");

        // s.History.Add(9999);
        // NU MAI COMPILEAZA 
        Console.WriteLine("aatacul 5 blocat la compilare .");

        // s.ErrorCount = 0; 
        // NU MAI COMPILEAZA 
        Console.WriteLine("atacul 6 blocat la compilare .");

        // s.Id = ""; 
        // NU MAI COMPILEAZA 
        TemperatureSensor sGresit = new TemperatureSensor("", 10, 50);
        Console.WriteLine("atacul 7 respins in constructor.");

        Console.WriteLine("\n REZULTAT");
        Console.WriteLine("\n toate atacurile au fost respinse si eliminate");
        Console.WriteLine("Nr decitiri valide ramase in istoric: " + s.History.Count);
        Console.WriteLine("Total erori numarate: " + s.ErrorCount);
    }
}