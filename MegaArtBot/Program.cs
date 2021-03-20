using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using AngleSharp;
using System.Linq;

namespace MegaArtBot
{
    class Program
    {
        public static ITelegramBotClient botClient;
        static void Main()
        {
            botClient = new TelegramBotClient("1732100535:AAHRWaLdV5QXOlOcqZ_sgJr-P5lxUcCGdxk");

            var me = botClient.GetMeAsync().Result;
            Console.WriteLine(
              $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            );

            botClient.OnMessage += Command.Bot_GenerateRandom;
            botClient.OnMessage += Command.Bot_GiveRandomCat;
            botClient.StartReceiving();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            botClient.StopReceiving();
        }
    }
}