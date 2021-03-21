using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using AngleSharp;
using System.Linq;
using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.InlineQueryResults;

namespace MegaArtBot
{
    partial class Commands
    {
        public static async void Bot_SetCatPage(object sender, MessageEventArgs e)
        {
            try
            {
                if (e.Message.Text == "/setcatpage")
                {
                    var inlineKeyboard = new InlineKeyboardMarkup(new[]
{
                    // first row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Кошкин дом", "cathouse"),
                        InlineKeyboardButton.WithCallbackData("Собачья жизнь", "doglife"),
                    },
                    // second row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Работа - не волк!", "work!=wolf"),
                        InlineKeyboardButton.WithCallbackData("Главная страница", "mainpage"),
                    }
                });
                    await Program.botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: "Choose page of kotomatrix I will parse",
                        replyMarkup: inlineKeyboard
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
