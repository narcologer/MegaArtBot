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
        public static async void Bot_GenerateRandom(object sender, MessageEventArgs e)
        {
            try
            {
                if (e.Message.Text.Contains("/generate"))
                {
                    String j = e.Message.Text.Substring(9).ToString();
                    int m = int.Parse(j);
                    await Program.botClient.SendTextMessageAsync(
                      chatId: e.Message.Chat,
                      text: "New random: " + Functions.GetRandom(m).ToString()
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
