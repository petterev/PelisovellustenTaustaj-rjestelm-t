using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.IO;

namespace assignment1
{
    class Program
    {
      static async Task Main(string[] args)
      {        

        OfflineBikeDataFetcher offlineBikeDataFetcher = new OfflineBikeDataFetcher();
        RealTimeCityBikeDataFetcher realTimeCityBikeDataFetcher=new RealTimeCityBikeDataFetcher();

        try
        {
          if(args[1]=="offline")
          {
            await offlineBikeDataFetcher.GetBikeCountInStation(args[0]);
          }
          if(args[1]=="realtime")
          {
            await realTimeCityBikeDataFetcher.GetBikeCountInStation(args[0]);
          }  
          if(args[1]!="offline"&& args[1]!="realtime")
          {
            throw new ArgumentException(String.Format(args[1]));
          }


        }
        catch(ArgumentException e)
        {
          Console.WriteLine("Invalid argument: "+e.Message);
        }   

      
      }
    }
}
