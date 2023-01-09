namespace API.Models
{
    public class FlightM
    {
       
        public int FlightId { get; set; }
        public DateTime Date { get; set; }
        public string Depart { get; set; }
        public string Destination { get; set; }
        public int FlightNo { get; set; }
        public int FreeSeats { get; set; }
        public double Price { get; set; }
        public int NbrSeats { get; set; }
        public double Occupation { get; set; }
    }
}
