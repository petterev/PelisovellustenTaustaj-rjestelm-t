using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.IO;

public class OfflineBikeDataFetcher : ICityBikeDataFetcher
{     public async Task<int> GetBikeCountInStation(string stationName)
     {
         try
         {
            if(stationName.Any(char.IsDigit))
               throw new ArgumentException(String.Format("stationName can't contain a number" ));

            string[] lines = await Task.Run(() => File.ReadAllLines("bikedata.txt"));

            foreach(string line in lines)
            {
               string name = String.Join("", line.Where(char.IsLetter));
               if(name==stationName)
               {
                  string num  = String.Join("", line.Where(char.IsDigit));
                  Console.WriteLine("Bikes available: " + num);
                  return Int32.Parse(num);
               }        


            }       
           throw new NotFoundException(String.Format(stationName));
           
         }
         catch(ArgumentException e)
         {
                
            Console.WriteLine("Invalid argument: " +e.Message);
                
         }
         catch(NotFoundException e)
        {
                
            Console.WriteLine("Not found: " +e.Message);
           
                
        }
      return 0;
         
   }
}




