using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using AngleSharp;
using System.Linq;

namespace MegaArtBot
{
    class Command
    {

        static Random rnd = new Random();
        static int GetRandom(int m)
        {
            int value = rnd.Next(0, m);
            Console.WriteLine($"New random: {value}.");
            return value;
        }

        public static async void Bot_GenerateRandom(object sender, MessageEventArgs e)
        {
            try
            {
                if (e.Message.Text.Substring(0, 9) == "/generate")
                {
                    String j = e.Message.Text.Substring(9).ToString();
                    int m = int.Parse(j);
                    await Program.botClient.SendTextMessageAsync(
                      chatId: e.Message.Chat,
                      text: "New random: " + GetRandom(m).ToString()
                    );
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Some exception");
            }
        }

        public static async void Bot_GiveRandomCat(object sender, MessageEventArgs e)
        {
            try
            {
                if (e.Message.Text == "/showrndcat")
                {
                    var config = Configuration.Default.WithDefaultLoader();
                    var address = "http://kotomatrix.ru/";
                    var document = await BrowsingContext.New(config).OpenAsync(address);
                    var fileExtensions = new string[] { ".jpg", ".png" };

                    var result = from element in document.All
                                 from attribute in element.Attributes
                                 where fileExtensions.Any(ee => attribute.Value.EndsWith(ee)) && attribute.Value.Contains("http://kotomatrix.ru/images/")
                                 select attribute.Value;
                    var res = result.ToArray();
                    await Program.botClient.SendTextMessageAsync(
                         chatId: e.Message.Chat,
                         text: "Random Image " + result.ElementAt(rnd.Next(0, result.Count()))
                        );
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Some exception");
            }
        }
    }
}
