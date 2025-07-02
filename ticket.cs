using System;
class TicketBooking
{
    public double totalFare = 0;
    public void BookTicket(string passengerName, int age, int quantity, double pricePerTicket)
    {
        if (quantity <= 0 || pricePerTicket < 0)
        {
            Console.WriteLine("Invalid quantity or price."); return;
        }
        if (age < 0)
        {
            Console.WriteLine("Invalid age.");
            return;

        }

        double discount = 0;
        if (age < 5)
            discount = 0.5;
        else if (age >= 60)
            discount = 0.3;
        double finalPrice = quantity * pricePerTicket * (1 - discount);
        totalFare += finalPrice;
        Console.WriteLine(passengerName + " booked " + quantity + " tickets. Total fare: " + totalFare);

    }

}
class Program
{
    static void Main()
    {
        try
        {
            TicketBooking booking = new TicketBooking();
            booking.BookTicket("Alice", 3, 2, 100);
            booking.BookTicket("Bob", -1, 1, 150); // Invalid age 
            booking.BookTicket("Charlie", 30, 0, 200); // Invalid quantity 
        }

        catch (NullReferenceException ex)
        {
            Console.WriteLine("NullReferenceException caught: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("DivByZero Exception: " + ex.Message);
        }
    }

}