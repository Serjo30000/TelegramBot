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
    public class Victorins : Elementable
    {
        private ITelegramBotClient botClient;
        private Update update;
        private CancellationToken tokens;
        private Victorina victr;
        private int countQuest = -1;

        public Victorins(Victorina victr)
        {
            
            this.victr = victr;
        }


        public async void Elem(ITelegramBotClient botClient, Update update, CancellationToken tokens)
        {
            this.botClient = botClient;
            this.update = update;
            this.tokens = tokens;
            var message = update.Message;
            if (message.Text != null)
            {
                if ((message.Text.ToLower().Contains("викторина") && message.Text.ToLower().Length == 9) || countQuest > -1)
                {
                    if (message.Text.ToLower().Contains("викторина") && message.Text.ToLower().Length == 9)
                    {
                        countQuest = 0;
                        await botClient.SendTextMessageAsync(message.Chat.Id, victr._questionList[countQuest].ToString());
                    }
                    else if (countQuest == 0 && victr.isAnswer(victr._questionList[countQuest], message.Text.ToLower()))
                    {
                        countQuest++;
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Вы ответили верно.");
                        await botClient.SendTextMessageAsync(message.Chat.Id, victr._questionList[countQuest].ToString());
                    }
                    else if (countQuest == 1 && victr.isAnswer(victr._questionList[countQuest], message.Text.ToLower()))
                    {
                        countQuest++;
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Вы ответили верно.");
                        await botClient.SendTextMessageAsync(message.Chat.Id, victr._questionList[countQuest].ToString());
                    }
                    else if (countQuest == 2 && victr.isAnswer(victr._questionList[countQuest], message.Text.ToLower()))
                    {
                        countQuest++;
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Вы ответили верно.");
                        await botClient.SendTextMessageAsync(message.Chat.Id, victr._questionList[countQuest].ToString());
                    }
                    else if (countQuest == 3 && victr.isAnswer(victr._questionList[countQuest], message.Text.ToLower()))
                    {
                        countQuest++;
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Вы ответили верно.");
                        await botClient.SendTextMessageAsync(message.Chat.Id, victr._questionList[countQuest].ToString());
                    }
                    else if (countQuest == 4 && victr.isAnswer(victr._questionList[countQuest], message.Text.ToLower()))
                    {
                        countQuest = -1;
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Вы ответили верно.");
                        await botClient.SendTextMessageAsync(message.Chat.Id, victr.ToString());
                    }
                    else
                    {
                        countQuest++;
                        await botClient.SendTextMessageAsync(message.Chat.Id, "Вы ответили неверно.");
                        if (countQuest > -1 && countQuest <= victr.isCount() - 1)
                        {
                            await botClient.SendTextMessageAsync(message.Chat.Id, victr._questionList[countQuest].ToString());
                        }
                        if (countQuest == victr.isCount())
                        {
                            await botClient.SendTextMessageAsync(message.Chat.Id, victr.ToString());
                            countQuest = -1;
                        }

                    }
                }
            }
        }
    }
}
