using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot
{
    public class PlayGames : Elementable
    {
        private ITelegramBotClient botClient;
        private Update update;
        private CancellationToken tokens;

        public PlayGames()
        {

        }


        public async void Elem(ITelegramBotClient botClient, Update update, CancellationToken tokens)
        {
            this.botClient = botClient;
            this.update = update;
            this.tokens = tokens;
            var message = update.Message;
            if (message.Text != null)
            {
                if ((message.Text.ToLower().Contains("игра") && message.Text.ToLower().Length == 4) || (message.Text.ToLower().Contains("камень ножницы бумага") && message.Text.ToLower().Length == 21) || (message.Text.ToLower().Contains("кости") && message.Text.ToLower().Length == 5))
                {
                    ReplyKeyboardMarkup replyKeyboardMarkup = new(new List<KeyboardButton>
                    {
                        "камень ножницы бумага", "кости"
                    });
                    if (message.Text.ToLower().Contains("игра"))
                    {
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Выбери игру", replyMarkup: replyKeyboardMarkup);
                    }

                    switch (message.Text.ToLower())
                    {
                        case "камень ножницы бумага":
                            {
                                ReplyKeyboardMarkup replyKeyboardMarkup1 = new(new List<KeyboardButton>
                                {
                                    "камень", "ножницы", "бумага"
                                });
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Игра - камень, ножницы, бумага", replyMarkup: replyKeyboardMarkup1);
                                break;
                            }
                        case "кости":
                            {
                                ReplyKeyboardMarkup replyKeyboardMarkup2 = new(new List<KeyboardButton>
                                {
                                    "бросить кубик"
                                });
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Игра - кости", replyMarkup: replyKeyboardMarkup2);
                                break;
                            }
                        default: break;
                    }
                }
                if ((message.Text.ToLower().Contains("камень") && message.Text.ToLower().Length == 6) || (message.Text.ToLower().Contains("ножницы") && message.Text.ToLower().Length == 7) || (message.Text.ToLower().Contains("бумага") && message.Text.ToLower().Length == 6))
                {
                    string txt1 = message.Text.ToLower();
                    GameRPS games;
                    if (message.Text.ToLower() == "камень" || message.Text.ToLower() == "ножницы" || message.Text.ToLower() == "бумага")
                    {
                        games = new GameRPS(txt1);
                        List<string> listSt = new List<string> { "CAACAgIAAxkBAAEGZcpjb9yXcPlLmz8c1IcX8_2KrUqPUgACHSUAAmOLRgyxhUDhJJhCiCsE", "CAACAgIAAxkBAAEGZchjb9yVJFKaxbmHUHlJ7AMnR3NaKwACHCUAAmOLRgzIU-8nVrftFisE", "CAACAgIAAxkBAAEGZcxjb9yZ58f9AwKEla8XGoi98NTo0AACHiUAAmOLRgzdrY12xKQLWysE" };
                        await botClient.SendTextMessageAsync(message.Chat.Id, games.Game());
                        if (message.Text.ToLower() == "камень")
                        {
                            await botClient.SendStickerAsync(chatId: message.Chat.Id, sticker: listSt[0]);
                        }
                        if (message.Text.ToLower() == "ножницы")
                        {
                            await botClient.SendStickerAsync(chatId: message.Chat.Id, sticker: listSt[1]);
                        }
                        if (message.Text.ToLower() == "бумага")
                        {
                            await botClient.SendStickerAsync(chatId: message.Chat.Id, sticker: listSt[2]);
                        }
                        await botClient.SendStickerAsync(chatId: message.Chat.Id, sticker: listSt[games.Rr11]);
                    }
                }
                if ((message.Text.ToLower().Contains("бросить кубик") && message.Text.ToLower().Length == 13))
                {
                    GameDice games;
                    if (message.Text.ToLower() == "бросить кубик")
                    {
                        games = new GameDice();
                        List<string> listSt = new List<string> { "CAACAgIAAxkBAAEGZbxjb9knWRid1H50QUzaeT6RqJYbTQACixUAAu-iSEvcMCGEtWaZoCsE", "CAACAgIAAxkBAAEGZb5jb9kpNUb2TK82kz9MBapOpmnsLgACzxEAAlKRQEtOAAGmnvjK7y8rBA", "CAACAgIAAxkBAAEGZcBjb9krD1by3iE8biiM0cq8FHP8vgACQBEAAiOsQUurmtw9CutR3ysE", "CAACAgIAAxkBAAEGZcJjb9ksycUMiGslcz95G6muFRvx0wACcREAAuzsQUu1GqzW_T-jpCsE", "CAACAgIAAxkBAAEGZcRjb9kuUJfacVjuYQfpgHOlPRccNwACoQ8AAkG1QUtuwcKEzQGhISsE", "CAACAgIAAxkBAAEGZcZjb9kv4gbQAsUH8eHJVYCJi8BWhwAC9g0AAvetSEtWDywqQrcoYysE" };
                        await botClient.SendTextMessageAsync(message.Chat.Id, games.Game());
                        await botClient.SendStickerAsync(chatId: message.Chat.Id, sticker: listSt[games.R11 - 1]);
                        await botClient.SendStickerAsync(chatId: message.Chat.Id, sticker: listSt[games.R22 - 1]);
                    }
                }
            } 
        }
    }
}
