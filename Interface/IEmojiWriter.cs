using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleEmoji.Interface
{
    public interface IEmojiWriter
    {
        public void SaveImage(string name, byte[] content);
        
 
    
    }
}