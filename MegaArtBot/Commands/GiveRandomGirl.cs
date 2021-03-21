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
        public static async void Bot_GiveRandomGirl(object sender, MessageEventArgs e)
        {
            var config = Configuration.Default.WithDefaultLoader();
            try
            {
                if (e.Message.Text == "/showrndgirl")
                {
                    var document = await BrowsingContext.New(config).OpenAsync(Program.girls);
                    IEnumerable<string> imgcol = Functions.ImgParser(document, ".jpg");
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
