using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleEmoji.Interface;

namespace ConsoleEmoji.Service
{
    public class EmojiDownloaderService : IEmojiDownloader
    {
        private const string GitHubRepoUrl = "https://raw.githubusercontent.com/microsoft/fluentui-emoji/main/assets/";

        public string CapitalizeFirstLetter(string word)
        {
            if (string.IsNullOrEmpty(word))

            {
                return word;
            }

            return char.ToUpper(word[0]) + word.Substring(1);
        }

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

  
    }
}