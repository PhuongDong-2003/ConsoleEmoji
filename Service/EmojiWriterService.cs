using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleEmoji.Interface;

namespace ConsoleEmoji.Service
{
    public class EmojiWriterService : IEmojiWriter
    {
        public void SaveImage(string name, byte[] content)
        {
            string fileName = $"{name}.png";
            File.WriteAllBytes(fileName, content);
        }
    }
}