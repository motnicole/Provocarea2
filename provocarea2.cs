using System;
using System.Collections.Generic;

public class TemperatureSensor
{
    private double min;
    private double max;
    private readonly List<double> istCitiri = new List<double>();

    public TemperatureSensor(string id, double minim, double maxim)
    {
        ErrorCount = 0;

        if (string.IsNullOrWhiteSpace(id))
        {
            Id = "SENZOR_FARA_ID";
            ErrorCount++;
        }
        else
        {
            Id = id;
        }

        if (minim >= maxim)
        {
            min = 0;
            max = 100;
            ErrorCount++;
        }
        else
        {
            min = minim;
            max = maxim;
        }
    }

    public string Id { get; }

    public int ErrorCount { get; private set; }

    public IReadOnlyList<double> History => istCitiri.AsReadOnly();

    public void AddReading(double valoare)
    {
        if (double.IsNaN(valoare) || valoare < -273.15)
        {
            ErrorCount++;
            return;
        }

        istCitiri.Add(valoare);
    }

    public void SetThresholds(double minimNou, double maximNou)
    {
        if (minimNou >= maximNou)
        {
            ErrorCount++;
            return;
        }

        min = minimNou;
        max = maximNou;
    }

    public double GetLastReading(char unitate = 'C')
    {
        if (istCitiri.Count == 0)
        {
            return 0.0;
        }

        double ultimaCitire = istCitiri[istCitiri.Count - 1];

        if (unitate == 'F' || unitate == 'f')
        {
            return (ultimaCitire * 9.0 / 5.0) + 32.0;
        }

        return ultimaCitire;
    }
}