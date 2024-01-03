using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleEmoji.Interface;

namespace ConsoleEmoji
{
    public class InputLoaderService : IInputLoader
    {
        public string CapitalizeFirstLetter(string word)
        {
             if (string.IsNullOrEmpty(word))
        {
            return word;
        }

        return char.ToUpper(word[0]) + word.Substring(1);
        }
    }
}