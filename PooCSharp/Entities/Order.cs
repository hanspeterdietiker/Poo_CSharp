using System;
using System.Globalization;
using System.Text;
using PooCSharp.Entities.enums;

namespace PooCSharp.Entities;

public class Order
{
    public DateTime Moment { get; set; }
    public OrderStatus Status { get; set; }
    public Client Client { get; set; }
    public List<OrderItem> Item { get; set; } = new List<OrderItem>();

    public Order()
    {
        
    }
    public Order(Client client, DateTime moment, OrderStatus status)
    {
        Client = client;
        Moment = moment;
        Status = status;
    }

    public void AddItem(OrderItem addItem)
    {
        Item.Add(addItem);
    }

    public void RemoveItem(OrderItem removeItem)
    {
        Item.Remove(removeItem);
    }

    public double Total()
    {
        double sum = 0.0;
        foreach (OrderItem item in Item)
        {
            sum += item.SubTotal();
        }

        return sum;
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Order moment: " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
        sb.AppendLine("Order status: " + Status);
        sb.AppendLine("Client: " + Client);
        sb.AppendLine("Order items:");
        foreach (OrderItem item in Item)
        {
            sb.AppendLine(item.ToString());
        }
        sb.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));
        return sb.ToString();
    }
}
