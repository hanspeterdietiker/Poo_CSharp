using System;

namespace PooCSharp_2.Entities;

public class HourContract
{
    public DateTime Date { get; set; }
    public double ValuePerHour { get; set; }
    public int Hours { get; set; }

    public HourContract()
    {
        
    }

    public HourContract(DateTime date, double valuePerHour, int type)
    {
        Date = date;
        ValuePerHour = valuePerHour;
        Hours = type;
    }

    public double TotalValue()
    {
        return ValuePerHour *= Hours;
    }
    
}