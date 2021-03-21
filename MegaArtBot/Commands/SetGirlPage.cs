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
        public static async void Bot_SetGirlPage(object sender, MessageEventArgs e)
        {
            try
            {
                if (e.Message.Text == "/setgirlpage")
                {
                    var inlineKeyboard = new InlineKeyboardMarkup(new[]
{
                    // first row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("1", "1"),
                        InlineKeyboardButton.WithCallbackData("2", "2"),
                        InlineKeyboardButton.WithCallbackData("3", "3"),
                    },
                    // second row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("4", "4"),
                        InlineKeyboardButton.WithCallbackData("5", "5"),
                        InlineKeyboardButton.WithCallbackData("6", "6"),
                    }
                });
                    await Program.botClient.SendTextMessageAsync(
                        chatId: e.Message.Chat,
                        text: "Choose page of NSFW I will parse",
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
