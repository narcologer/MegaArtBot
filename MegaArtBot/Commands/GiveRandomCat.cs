using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using AngleSharp;
using System.Linq;
using System.Collections.Generic;

namespace MegaArtBot
{
    partial class Commands
    {
        public static async void Bot_GiveRandomCat(object sender, MessageEventArgs e)
        {
            var config = Configuration.Default.WithDefaultLoader();
            try
            {
                if (e.Message.Text == "/showrndcat")
                {
                    var document = await BrowsingContext.New(config).OpenAsync("http://kotomatrix.ru/");
                    IEnumerable<string> imgcol = Functions.ImgParser(document, "http://kotomatrix.ru/images");
                    await Program.botClient.SendTextMessageAsync(
                         chatId: e.Message.Chat,
                         text: "Random Image " + imgcol.ElementAt(Functions.GetRandom(imgcol.Count()))
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
