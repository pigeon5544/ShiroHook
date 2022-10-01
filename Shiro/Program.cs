using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Shiro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromMinutes(30);

            Console.WriteLine("Started ShiroHook\n");
            var timer = new System.Threading.Timer((e) =>
            {
                discord.Send("<@868507165730676757>");
            }, null, startTimeSpan, periodTimeSpan);
            Console.ReadLine();
        }
    }
    public static class discord
    {
        public static class Http
        {
            public static byte[] Post(string url, NameValueCollection pairs)
            {
                using (WebClient webClient = new WebClient())
                    return webClient.UploadValues(url, pairs);
            }
        }
        public static void Send(string content)
        {
            Console.WriteLine("Sent Ping: " + DateTime.Now);
            string webHookUrl = File.ReadAllText("config");
            Http.Post(webHookUrl, new NameValueCollection()
            {
                {
                    "content", content
                },

                {
                    "username", "ShiroHook"
                },

                {
                    "avatar_url", "https://steamuserimages-a.akamaihd.net/ugc/1808779657407939622/0163A125DE2A4A805915E6F24712756AA14D1E49/?imw=5000&imh=5000&ima=fit&impolicy=Letterbox&imcolor=%23000000&letterbox=false"
                }

            });
        }
    }
}
