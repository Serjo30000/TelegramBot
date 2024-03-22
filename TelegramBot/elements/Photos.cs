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
    public class Photos : Elementable
    {
        private ITelegramBotClient botClient;
        private Update update;
        private CancellationToken tokens;

        public Photos()
        {
            
        }


        public async void Elem(ITelegramBotClient botClient, Update update, CancellationToken tokens)
        {
            this.botClient = botClient;
            this.update = update;
            this.tokens = tokens;
            var message = update.Message;
            if (message.Document != null)
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Сейчас обработаю фотографию...");

                var fileId = update.Message.Document.FileId;
                var fileInfo = await botClient.GetFileAsync(fileId);
                var filePath = fileInfo.FilePath;

                string destinationFilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\{message.Document.FileName}";
                await using FileStream fileStream = System.IO.File.OpenWrite(destinationFilePath);
                await botClient.DownloadFileAsync(
                    filePath: filePath,
                    destination: fileStream);
                fileStream.Close();
                Process.Start(@"C:\Users\Serge\OneDrive\Рабочий стол\MovieStar.exe", $@"""{destinationFilePath}""");
                await Task.Delay(2000);

                await using Stream stream = System.IO.File.OpenRead(destinationFilePath);
                await botClient.SendDocumentAsync(message.Chat.Id, new InputOnlineFile(stream, message.Document.FileName));
            }
        }
    }
}
