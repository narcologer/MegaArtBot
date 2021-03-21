using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using AngleSharp;
using System.Linq;
using System.IO;

namespace MegaArtBot
{
    class Program
    {
        public static ITelegramBotClient botClient;
        static void Main()
        {
            botClient = new TelegramBotClient(new StreamReader("APIKEY.txt").ReadLine());

            var me = botClient.GetMeAsync().Result;
            Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");

            botClient.OnMessage += Commands.Bot_GenerateRandom;
            botClient.OnMessage += Commands.Bot_GiveRandomCat;
            botClient.OnMessage += Commands.Bot_GiveRandomGirl;
            botClient.StartReceiving();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            botClient.StopReceiving();
        }
    }
}