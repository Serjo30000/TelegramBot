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
    public class Reminds : Elementable
    {
        private ITelegramBotClient botClient;
        private Update update;
        private CancellationToken tokens;
        private DataStorage ds;
        private List<bool> listf = new List<bool>() { false, false};

        public Reminds(DataStorage ds)
        {
            this.ds = ds;
        }


        public async void Elem(ITelegramBotClient botClient, Update update, CancellationToken tokens)
        {
            this.botClient = botClient;
            this.update = update;
            this.tokens = tokens;
            var message = update.Message;
            if (message.Text != null)
            {
                if ((message.Text.ToLower().Contains("увидеть заметки") && message.Text.ToLower().Length == 15))
                {

                    if (message.Text.ToLower() == "увидеть заметки")
                    {

                        await botClient.SendTextMessageAsync(message.Chat.Id, ds.ToString());
                    }
                }
                if ((message.Text.ToLower().Contains("добавить заметку") && message.Text.ToLower().Length == 16) || listf[0] == true)
                {
                    string str = message.Text.ToLower();
                    if (message.Text.ToLower() == "добавить заметку" || listf[0] == true)
                    {
                        listf[0] = false;
                        await botClient.SendTextMessageAsync(message.Chat.Id, ds.AddNotes(str));
                    }
                }
                if ((message.Text.ToLower().Contains("удалить заметку") && message.Text.ToLower().Length == 15) || listf[1] == true)
                {
                    if (ds.RemoveHelper(message.Text.ToLower()))
                    {
                        int num = int.Parse(message.Text.ToLower());
                        string str = message.Text.ToLower();
                        if (((message.Text.ToLower() == "удалить заметку" && ds.ListR.Count > 0 && ds.ListR.Count > num) || listf[1] == true) && ds.RemoveHelper(str))
                        {
                            listf[1] = false;
                            await botClient.SendTextMessageAsync(message.Chat.Id, ds.RemoveNotes(num - 1));
                        }
                    }
                    else
                    {
                        listf[1] = false;
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Введите правильный номер заметки");
                    }

                }
                if ((message.Text.ToLower().Contains("заметки") && message.Text.ToLower().Length == 7) || (message.Text.ToLower().Contains("увидеть") && message.Text.ToLower().Length == 7) || (message.Text.ToLower().Contains("добавить") && message.Text.ToLower().Length == 8) || (message.Text.ToLower().Contains("удалить") && message.Text.ToLower().Length == 7))
                {
                    ReplyKeyboardMarkup replyKeyboardMarkup = new(new List<KeyboardButton>
                    {
                        "увидеть", "добавить", "удалить"
                    });
                    if (message.Text.ToLower().Contains("заметки"))
                    {
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Что вы хотите сделать?", replyMarkup: replyKeyboardMarkup);
                    }

                    switch (message.Text.ToLower())
                    {
                        case "увидеть":
                            {
                                ReplyKeyboardMarkup replyKeyboardMarkup1 = new(new List<KeyboardButton>
                                {
                                    "увидеть заметки"
                                });
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Увидеть заметки", replyMarkup: replyKeyboardMarkup1);
                                break;
                            }
                        case "добавить":
                            {
                                ReplyKeyboardMarkup replyKeyboardMarkup2 = new(new List<KeyboardButton>
                                {
                                    "добавить заметку"
                                });
                                listf[0] = true;
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Добавить заметки", replyMarkup: replyKeyboardMarkup2);
                                break;
                            }
                        case "удалить":
                            {
                                ReplyKeyboardMarkup replyKeyboardMarkup3 = new(new List<KeyboardButton>
                                {
                                    "удалить заметку"
                                });
                                listf[1] = true;
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Удалить заметки", replyMarkup: replyKeyboardMarkup3);
                                break;
                            }
                        default: break;
                    }
                }
            }
        }
    }
}
