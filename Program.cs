using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace GithubProfileViewsIncrement
{
    class Program
    {
        /// <summary>
        /// main program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Title = "Github Profile Views Increase";
            Console.Write("Insert Link : ");
            string link = Console.ReadLine();
            while (true)
            {
                Task.Delay(TimeSpan.FromSeconds(new Random().Next(1,10))).Wait();
                RequestToProfileLink(link).Wait();
            }
        }
        /// <summary>
        /// send request async
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static async Task RequestToProfileLink(string link)
        {
            Logger.Write("Sending Request...", TypeMessage.Info);
            HttpClient http = new HttpClient();
            http.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (compatible; Googlebot/2.1; +http://www.google.com/bot.html)");
            try
            {
                string response = http.GetAsync(link).Result.Content.ReadAsStringAsync().Result;
                var matches = Regex.Matches(response, "fill-opacity=\".3\">(.*?)</text>"); //get count view from raw response
                string countview = matches[1].Groups[1].Value;
                Logger.Write($"Success ! : Count Views ---> {countview}", TypeMessage.Done);
                response = null;
                matches = null;
            }
            catch(Exception ex)
            {
                Logger.Write("Error : " + ex.Message, TypeMessage.Error);
            }
            finally
            {
                http.Dispose();
            }
        }
    }
}
