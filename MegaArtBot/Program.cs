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

        public static String cats = "http://kotomatrix.ru/";
        public static String girls = "https://multi.xnxx.com/category/hentai/p-1/";
        public static ITelegramBotClient botClient;
        static void Main()
        {
            botClient = new TelegramBotClient(new StreamReader("APIKEY.txt").ReadLine());

            var me = botClient.GetMeAsync().Result;
            Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");
            botClient.OnMessage += Commands.Bot_GenerateRandom;
            botClient.OnMessage += Commands.Bot_GiveRandomCat;
            botClient.OnMessage += Commands.Bot_GiveRandomGirl;
            botClient.OnMessage += Commands.Bot_SetCatPage;
            botClient.OnMessage += Commands.Bot_SetGirlPage;
            botClient.OnCallbackQuery += Callbacks.Bot_ReceiveCallback;
            botClient.StartReceiving();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();

            botClient.StopReceiving();
        }
    }
}