using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleEmoji.Interface;

namespace ConsoleEmoji
{
    public class InputProcessorService : IInputProcessor
    {
        public string[] Input()
        {

            Console.WriteLine("Nhập tên hình ảnh (cách nhau bởi dấu phẩy):");
            string imageNamesInput = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(imageNamesInput))
            {
                string[] imageNames = imageNamesInput.Split(',');
                return imageNames;
   
            }
            return null;

        }
    }
}