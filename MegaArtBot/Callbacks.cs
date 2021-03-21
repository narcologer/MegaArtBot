using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Args;

namespace MegaArtBot
{
    class Callbacks
    {
        public static async void Bot_ReceiveCallback(object sc, CallbackQueryEventArgs ev)
            {
                var message = ev.CallbackQuery.Message;
                if (ev.CallbackQuery.Data == "cathouse")
                {
                    Program.cats = "http://kotomatrix.ru/themes/1/";
                    await Program.botClient.AnswerCallbackQueryAsync(ev.CallbackQuery.Id, Program.cats, true);
                }
                else
                if (ev.CallbackQuery.Data == "doglife")
                {
                    Program.cats = "http://kotomatrix.ru/themes/2/";
                    await Program.botClient.AnswerCallbackQueryAsync(ev.CallbackQuery.Id, Program.cats, true);
                }
                else
                if (ev.CallbackQuery.Data == "work!=wolf")
                {
                    Program.cats = "http://kotomatrix.ru/themes/3/";
                    await Program.botClient.AnswerCallbackQueryAsync(ev.CallbackQuery.Id, Program.cats, true);
                }
                else
                if (ev.CallbackQuery.Data == "mainpage")
                {
                    Program.cats = "http://kotomatrix.ru/";
                    await Program.botClient.AnswerCallbackQueryAsync(ev.CallbackQuery.Id, Program.cats, true);
                }
                else
                {
                    Program.girls = "https://multi.xnxx.com/category/hentai/p-" + ev.CallbackQuery.Data + "/";
                    await Program.botClient.AnswerCallbackQueryAsync(ev.CallbackQuery.Id, Program.girls, true);
                }
        }
    }
}
