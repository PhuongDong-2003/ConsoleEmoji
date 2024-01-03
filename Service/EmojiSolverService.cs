using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleEmoji.Interface;

namespace ConsoleEmoji.Service
{
    public class EmojiSolverService : IEmojiSolver
    {
         private const string GitHubRepoUrl = "https://raw.githubusercontent.com/microsoft/fluentui-emoji/main/assets/";
        public async Task<byte[]> LoadImageFromGitHub(string name)
        {
            try
        {
            using (var httpClient = new HttpClient())
            {
            
                string imageUrl = $"{GitHubRepoUrl}{name}";

                Uri uri = new Uri(imageUrl);

                HttpResponseMessage response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsByteArrayAsync();
                }
                else
                {
                    Console.WriteLine($"Không thể lấy hình ảnh '{name}'. Mã trạng thái: {response.StatusCode}");
                    return null;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Đã xảy ra lỗi khi lấy hình ảnh '{name}': {ex.Message}");
            return null;
        }
        }

        public void SaveImage(string name, byte[] content)
        {
              string fileName = $"{name}.png";

            File.WriteAllBytes(fileName, content);
        }

       
    }
}