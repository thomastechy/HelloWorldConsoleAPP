using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Configuration;

namespace HelloWorldConsoleAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            //call the api
            //Web API is running on IIS express on port 4883 and end point for getmessage service is below
            //http://localhost:4883/api/messaging/getmessage
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:4883");
            client.DefaultRequestHeaders.Accept.Clear();
         
            MyAPIGet(client).Wait();

        }
        static async Task MyAPIGet(HttpClient cons)
        {
            using (cons)
            {
                HttpResponseMessage res = await cons.GetAsync("api/messaging/getmessage");
                res.EnsureSuccessStatusCode();
                if (res.IsSuccessStatusCode)
                {
                    string str = await res.Content.ReadAsStringAsync();
                    if (ConfigurationSettings.AppSettings["SendOutputTo"] == "Console")
                    {
                        OutputWriterToConsole or = new OutputWriterToConsole();
                        or.WriteMessage(str);
                    }
                    else
                    {
                        OutputWriterToDB or = new OutputWriterToDB();
                        or.WriteMessage(str);
                    }
                }
            }
            
        }
     
    }
 
}
