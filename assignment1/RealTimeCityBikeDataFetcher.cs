using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.IO;


public class RealTimeCityBikeDataFetcher : ICityBikeDataFetcher
{
    private const string URL = "http://api.digitransit.fi/routing/v1/routers/hsl/bike_rental";


     public async Task<int> GetBikeCountInStation(string stationName)
     {         
      
        try
        {
        if(stationName.Any(char.IsDigit))
          throw new ArgumentException(String.Format("stationName can't contain a number" ));

        HttpClient client = new System.Net.Http.HttpClient();

       // HttpResponseMessage response1 = await client.GetAsync(URL);

        string response = await client.GetStringAsync(URL);

        BikeRentalStationList list = JsonConvert.DeserializeObject<BikeRentalStationList>(response);
         
            foreach (Station station in list.stations)
            {
                if (stationName == station.name)
                {
                    Console.WriteLine("Bikes available: " + station.bikesAvailable);
                    return station.bikesAvailable;
                }
            }
            throw new NotFoundException(String.Format(stationName ));
              
        }    
        catch(ArgumentException e)
        {                
            Console.WriteLine("Invalid argument: "+e.Message);                
        }

       catch(NotFoundException e)
        {                
            Console.WriteLine("Not found: " +e.Message);                
        }
    return 0;
    }
}
    
      
    
        

  
        
    

  






   


