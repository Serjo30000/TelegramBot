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
    class DataStorages : Elementable
    {
        private ITelegramBotClient botClient;
        private Update update;
        private CancellationToken tokens;
        private Remind rr;
        private List<bool> listf = new List<bool>() { false, false };

        public DataStorages(Remind rr)
        {
            this.rr = rr;
        }


        public async void Elem(ITelegramBotClient botClient, Update update, CancellationToken tokens)
        {
            this.botClient = botClient;
            this.update = update;
            this.tokens = tokens;
            var message = update.Message;
            int timer1 = DateTime.Now.DayOfYear;
            if (rr.RemindHelper(timer1))
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, rr.ToRemind(timer1));
            }
            if (message.Text != null)
            {
                if ((message.Text.ToLower().Contains("посмотреть напоминания") && message.Text.ToLower().Length == 22))
                {

                    if (message.Text.ToLower() == "посмотреть напоминания")
                    {

                        await botClient.SendTextMessageAsync(message.Chat.Id, rr.ToString());
                    }
                }
                if ((message.Text.ToLower().Contains("изменить напоминания") && message.Text.ToLower().Length == 20) || listf[0] == true)
                {
                    string str = message.Text.ToLower();
                    if (message.Text.ToLower() == "изменить напоминания" || listf[0] == true)
                    {
                        listf[0] = false;
                        await botClient.SendTextMessageAsync(message.Chat.Id, rr.AddNotes(str));
                    }
                }
                if ((message.Text.ToLower().Contains("убрать напоминания") && message.Text.ToLower().Length == 18) || listf[1] == true)
                {
                    if (rr.RemoveHelper(message.Text.ToLower()))
                    {
                        int num = int.Parse(message.Text.ToLower());
                        string str = message.Text.ToLower();
                        if (((message.Text.ToLower() == "убрать напоминания" && rr.ListR.Count > 0 && rr.ListR.Count > num) || listf[1] == true) && rr.RemoveHelper(str))
                        {
                            listf[1] = false;
                            await botClient.SendTextMessageAsync(message.Chat.Id, rr.RemoveNotes(num - 1));
                        }
                    }
                    else
                    {
                        listf[1] = false;
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Введите правильный номер напоминания");
                    }

                }
                if ((message.Text.ToLower().Contains("напоминания") && message.Text.ToLower().Length == 11) || (message.Text.ToLower().Contains("посмотреть") && message.Text.ToLower().Length == 10) || (message.Text.ToLower().Contains("изменить") && message.Text.ToLower().Length == 8) || (message.Text.ToLower().Contains("убрать") && message.Text.ToLower().Length == 6))
                {
                    ReplyKeyboardMarkup replyKeyboardMarkup = new(new List<KeyboardButton>
                    {
                        "посмотреть", "изменить", "убрать"
                    });
                    if (message.Text.ToLower().Contains("напоминания"))
                    {
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Что вы хотите сделать?", replyMarkup: replyKeyboardMarkup);
                    }

                    switch (message.Text.ToLower())
                    {
                        case "посмотреть":
                            {
                                ReplyKeyboardMarkup replyKeyboardMarkup1 = new(new List<KeyboardButton>
                                {
                                    "посмотреть напоминания"
                                });
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Посмотреть напоминания", replyMarkup: replyKeyboardMarkup1);
                                break;
                            }
                        case "изменить":
                            {
                                ReplyKeyboardMarkup replyKeyboardMarkup2 = new(new List<KeyboardButton>
                                {
                                    "изменить напоминания"
                                });
                                listf[0] = true;
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Изменить напоминания", replyMarkup: replyKeyboardMarkup2);
                                break;
                            }
                        case "убрать":
                            {
                                ReplyKeyboardMarkup replyKeyboardMarkup3 = new(new List<KeyboardButton>
                                {
                                    "убрать напоминания"
                                });
                                listf[1] = true;
                                await botClient.SendTextMessageAsync(message.Chat.Id, "Убрать напоминания", replyMarkup: replyKeyboardMarkup3);
                                break;
                            }
                        default: break;
                    }
                }
            }
        }
    }
}
