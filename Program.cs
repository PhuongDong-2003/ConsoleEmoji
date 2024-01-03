using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using ConsoleEmoji;
using ConsoleEmoji.Service;

class Program
{
    static async Task Main()
    {
        InputProcessorService inputProcessorService = new InputProcessorService();
        EmojiDownloaderService emojiDownloaderService = new EmojiDownloaderService();
        EmojiWriterService emojiWriterService = new EmojiWriterService();

        var imageNamesInput = inputProcessorService.Input();

        foreach (var imageName in imageNamesInput)
        {
            string formattedName = emojiDownloaderService.CapitalizeFirstLetter(imageName);
            byte[] imageBytes = await emojiDownloaderService.LoadImageFromGitHub(formattedName + "/3D/" + imageName.Replace(" ", "_").Trim() + "_3d.png");

            if (imageBytes != null)
            {
                emojiWriterService.SaveImage(formattedName, imageBytes);
                Console.WriteLine($"Hình ảnh '{formattedName}' đã được lấy và lưu thành công.");
            }
            else
            {
                Console.WriteLine($"Không thể lấy và lưu hình ảnh '{formattedName}'.");
            }
        }

    }





}
