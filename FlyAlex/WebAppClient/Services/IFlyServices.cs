namespace WebAppClient.Services
{
    public interface IFlyServices
    {
        public Task<IEnumerable<WebAppClient.Models.FlightM>> GetFlights();
        public Task<IEnumerable<WebAppClient.Models.FinalTicket>> FinalTicket(string destination);
        public Task<double> GetPriceFromFlight(int idFlight);
        public Task<bool> BookFlight(int idPassenger, int idFlight);
        public Task<double> GetTotalSalePriceOfFlight(int idFlight);
        public Task<double> GetAverageTicketPrice(string destination);

    }
}
