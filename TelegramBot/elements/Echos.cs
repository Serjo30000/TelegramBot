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
    public class Echos : Elementable
    {
        private ITelegramBotClient botClient;
        private Update update;
        private CancellationToken tokens;

        public Echos()
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
                if ((message.Text.ToLower().Contains("/help") && message.Text.ToLower().Length == 5))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Привет! Этот бот умеет: \n1. Играть с вами, если вы напишите 'игра'. \n2. Делать заметки, если вы напишите 'заметки'. \n3. Делать напоминания, если вы напишите 'напоминания'. \n4. Общаться с вами, если вы напишите 'привет', 'пока', 'что делаешь' и тд. \n5. Обрабатывать ваши фотографии, если вы отправите документ в формате jpg. \n6. Играть в викторину на 5 вопросов, если напишите 'викторина'.");
                }
                if ((message.Text.ToLower().Contains("привет") && message.Text.ToLower().Length == 6) || (message.Text.ToLower().Contains("здарова") && message.Text.ToLower().Length == 7) || (message.Text.ToLower().Contains("hi") && message.Text.ToLower().Length == 2) || (message.Text.ToLower().Contains("hello") && message.Text.ToLower().Length == 5))
                {
                    Random rnd = new Random();
                    int r = rnd.Next(0, 4);
                    List<string> listR = new List<string> { "Привет!", "Здарова!", "Hi!", "Hello!" };
                    await botClient.SendTextMessageAsync(message.Chat.Id, listR[r]);
                    await botClient.SendStickerAsync(chatId: message.Chat.Id, sticker: "CAACAgIAAxkBAAEGZZNjb9TMLR8jZNiF8L0sPI1SDu-F0AACBQADwDZPE_lqX5qCa011KwQ");
                }
                if ((message.Text.ToLower().Contains("как дела") && message.Text.ToLower().Length == 8) || (message.Text.ToLower().Contains("как твои дела") && message.Text.ToLower().Length == 13) || (message.Text.ToLower().Contains("как дела?") && message.Text.ToLower().Length == 9) || (message.Text.ToLower().Contains("как твои дела?") && message.Text.ToLower().Length == 14))
                {
                    Random rnd = new Random();
                    int r = rnd.Next(0, 4);
                    List<string> listR = new List<string> { "Хорошо", "Нормально", "Отлично", "Плохо" };
                    List<string> listSt = new List<string> { "CAACAgIAAxkBAAEGZZVjb9XCzZLCRoCmXA6GRwsHwGy_2wACDQADwDZPE6T54fTUeI1TKwQ", "CAACAgIAAxkBAAEGZZdjb9aClD2wkk0hojMGNeYBPhSdwAACEAADwDZPE-qBiinxHwLoKwQ", "CAACAgIAAxkBAAEGZZljb9abHj-g3xNBQfSPM8zooS-u4AACFgADwDZPE2Ah1y2iBLZnKwQ", "CAACAgIAAxkBAAEGZZtjb9atlrV17u6fHJ70-D0pb7e7eAACDgADwDZPEyNXFESHbtZlKwQ" };
                    await botClient.SendTextMessageAsync(message.Chat.Id, listR[r]);
                    await botClient.SendStickerAsync(chatId: message.Chat.Id, sticker: listSt[r]);
                }
                if ((message.Text.ToLower().Contains("пока") && message.Text.ToLower().Length == 4) || (message.Text.ToLower().Contains("до свидания") && message.Text.ToLower().Length == 11) || (message.Text.ToLower().Contains("прощай") && message.Text.ToLower().Length == 6) || (message.Text.ToLower().Contains("до встречи") && message.Text.ToLower().Length == 10))
                {
                    Random rnd = new Random();
                    int r = rnd.Next(0, 4);
                    List<string> listR = new List<string> { "Пока!", "Ещё увидимся!", "Возвращайся!", "Буду тебя ждать!" };
                    await botClient.SendTextMessageAsync(message.Chat.Id, listR[r]);
                    await botClient.SendStickerAsync(chatId: message.Chat.Id, sticker: "CAACAgIAAxkBAAEGZa1jb9eTxxi0uEAyxZETwBLMy-LaewACBgADwDZPE8fKovSybnB2KwQ");
                }
                if ((message.Text.ToLower().Contains("что делаешь") && message.Text.ToLower().Length == 11) || (message.Text.ToLower().Contains("что делаешь?") && message.Text.ToLower().Length == 12))
                {
                    Random rnd = new Random();
                    int r = rnd.Next(0, 4);
                    List<string> listR = new List<string> { "Ничего", "Общаюсь", "Отдыхаю", "Играю" };
                    List<string> listSt = new List<string> { "CAACAgIAAxkBAAEGZbRjb9gPE1lC7m63YV99QiGxO4VsmQACIAADwDZPE_QPK7o-X_TPKwQ", "CAACAgIAAxkBAAEGZbZjb9gji7yxZzGcVot6SJMSIc3bqAACCgADwDZPE_8Nrj7oDv0IKwQ", "CAACAgIAAxkBAAEGZbhjb9g-t3KrMTbj7gvQsccdaaD_xQACHgADwDZPE6FgWy2rAAHeBCsE", "CAACAgIAAxkBAAEGZbpjb9hqLlcY3f36WOtqjpfmBVk76wACEwADwDZPE6qzh_d_OMqlKwQ" };
                    await botClient.SendTextMessageAsync(message.Chat.Id, listR[r]);
                    await botClient.SendStickerAsync(chatId: message.Chat.Id, sticker: listSt[r]);
                }
            }
        }
    }
}
