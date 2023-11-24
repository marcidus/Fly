using Newtonsoft.Json;
using WebAppClient.Models;

namespace WebAppClient.Services
{
    public class FlyServices : IFlyServices
    {
        private readonly HttpClient _client;
        private readonly string _baseURI;

        public FlyServices(HttpClient client)
        {
            _client = client;
            _baseURI = "https://localhost:7025/";
        }

        public async Task<bool> BookFlight(int idPassenger, int idFlight)
        {
            var requestUri = _baseURI + "BookFlight/" + idPassenger + "/" + idFlight;

            var requestBodyJson = JsonConvert.SerializeObject(requestUri);

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(requestUri),
                Content = new StringContent(requestBodyJson,System.Text.Encoding.UTF8, "application/json")
            };

            Console.WriteLine("Request: " + request);

            var response = await client.SendAsync(request);

            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<Models.FinalTicket>> FinalTicket(string destination)
        {
            var uri = _baseURI + "FinalTicket/" + destination;

            var responseJSON = await _client.GetAsync(uri);
            responseJSON.EnsureSuccessStatusCode();

            var data = await responseJSON.Content.ReadAsStringAsync();

            var finalTicket = JsonConvert.DeserializeObject<IEnumerable<Models.FinalTicket>>(data);

            return finalTicket;
        }

        public async Task<double> GetAverageTicketPrice(string destination)
        {
            var uri = _baseURI + "AverageTicketPrice/" + destination;

            var responseJSON = await _client.GetAsync(uri);
            responseJSON.EnsureSuccessStatusCode();

            var data = await responseJSON.Content.ReadAsStringAsync();

            var averagePrice = JsonConvert.DeserializeObject<double>(data);

            return averagePrice;
        }

        public async Task<IEnumerable<WebAppClient.Models.FlightM>> GetFlights()
        {
            var uri = _baseURI + "GetAvailableFlights";

            var responseJSON = await _client.GetAsync(uri);
            responseJSON.EnsureSuccessStatusCode();

            var data = await responseJSON.Content.ReadAsStringAsync();

            var flightList = JsonConvert.DeserializeObject<IEnumerable<WebAppClient.Models.FlightM>>(data);

            return flightList;
        }

        public async Task<double> GetPriceFromFlight(int idFlight)
        {
            var uri = _baseURI + "GetPriceFromFlight/" + idFlight;

            var responseJSON = await _client.GetAsync(uri);
            responseJSON.EnsureSuccessStatusCode();

            var data = await responseJSON.Content.ReadAsStringAsync();

            var flightPrice = JsonConvert.DeserializeObject<double>(data);

            return flightPrice;
        }

        public async Task<double> GetTotalSalePriceOfFlight(int idFlight)
        {
            var uri = _baseURI + "GetTotalSalePriceOfFlight/" + idFlight;

            var responseJSON = await _client.GetAsync(uri);
            responseJSON.EnsureSuccessStatusCode();

            var data = await responseJSON.Content.ReadAsStringAsync();

            var totalFlightPrice = JsonConvert.DeserializeObject<double>(data);

            return totalFlightPrice;
        }
    }
}
