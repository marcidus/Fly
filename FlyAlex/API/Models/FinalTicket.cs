namespace API.Models
{
    public class FinalTicket
    {
        public int TicketId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FlightNbr { get; set; }
        public double Price { get; set; }

        public int IdFlight { get; set; }
        public int IdPassenger { get; set; }

    }
}
