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
        InputLoaderService inputLoaderService = new InputLoaderService();
        EmojiSolverService emojiSolverService = new EmojiSolverService();

        Console.WriteLine("Nhập tên hình ảnh (cách nhau bởi dấu phẩy):");
        string imageNamesInput = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(imageNamesInput))
        {
            string[] imageNames = imageNamesInput.Split(',');

            foreach (var imageName in imageNames)
            {
                string formattedName = inputLoaderService.CapitalizeFirstLetter(imageName.Trim());
                byte[] imageBytes = await emojiSolverService.LoadImageFromGitHub(formattedName + "/3D/" + imageName.Replace(" ", "_").Trim() + "_3d.png");

                if (imageBytes != null)
                {
                    emojiSolverService.SaveImage(formattedName, imageBytes);
                    Console.WriteLine($"Hình ảnh '{formattedName}' đã được lấy và lưu thành công.");
                }
                else
                {
                    Console.WriteLine($"Không thể lấy và lưu hình ảnh '{formattedName}'.");
                }
            }
        }
        else
        {
            Console.WriteLine("Bạn chưa nhập tên hình ảnh.");
        }
    }




}
