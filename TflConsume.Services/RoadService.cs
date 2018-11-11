using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TflConsume.Models;

namespace TflConsume.Services
{
    public static class RoadService
    {
        static HttpClient httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://api.tfl.gov.uk/Road/")
        };

        public static RoadRequestResponse GetRoadStatus(string roadName, string appId, string developerKey)
        {
            var result = httpClient.GetAsync($"{roadName}?app_id={appId}&app_key={developerKey}").Result;

            try
            {


                if (result.IsSuccessStatusCode)
                {
                    var formattedJson = RoadRequestResponse.FromJson(result.Content.ReadAsStringAsync().Result);

                    return formattedJson[0];
                }
                else
                {
                    var ex = RoadRequestException.FromJson(result.Content.ReadAsStringAsync().Result);
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw new RoadRequestException()
                {
                    Message = "There was an error processing your request. Please check your settings and try again."
                };
            }
        }
    }
}
