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
    public class Program
    {
        private static string token { get; set; } = "5636001186:AAEFvBbpOjGzm-EdhcllPMYh_IREJjEnEFo";
        private static TelegramBotClient client;
        private static DataStorage ds = new DataStorage();
        private static Remind rr = new Remind();
        private static List<Question> listQwestions = new List<Question>() { new Question("Сколько планет в Солнечной Системе?", "8"), new Question("Сколько Континентов на Земле?", "6"), new Question("Какая страна самая маленькая?", "ватикан"), new Question("Какой самый большой Океан?", "тихий"), new Question("Кто написал у лукоморья дуб зелёный?", "пушкин") };
        private static Victorina victr = new Victorina(listQwestions);
        private static List<Elementable> listElements = new List<Elementable>() { new Photos(), new Victorins(victr), new Echos(), new PlayGames(), new Reminds(ds), new DataStorages(rr) };
        public static void Main(string[] args)
        {

            using var cts = new CancellationTokenSource();
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }
            };
            client = new TelegramBotClient(token);
            client.StartReceiving(Update, Error, receiverOptions: receiverOptions, cancellationToken: cts.Token);
            Console.ReadLine();
            cts.Cancel();
        }
        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken tokens)
        {
            foreach(Elementable elem in listElements)
            {
                elem.Elem(botClient, update, tokens);
            }
        }
        private static Task Error(ITelegramBotClient botClient, Exception exception, CancellationToken tokens)
        {
            throw new NotImplementedException();
        }

    }
}