using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleEmoji.Interface
{
    public interface IEmojiSolver
    {
        public  Task<byte[]> LoadImageFromGitHub(string name);
        public void SaveImage(string name, byte[] content);
    }
}