namespace PooCSharp_3.Entities;

// herança
public class OutSourcedEmployee : Employee
{
    public double AdditionalCharge { get; set; }

    public OutSourcedEmployee()
    {
        
    }
    
    public OutSourcedEmployee(double additionalCharge, string name, int hours, double valuePerHour) : base(
        name, hours, valuePerHour)
    {
        AdditionalCharge = additionalCharge;
    }

    public sealed override double Payment()
    {
        return base.Payment() + 1.1 * AdditionalCharge;
    }
}