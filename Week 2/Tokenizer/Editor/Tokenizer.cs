using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class Tokenizer
    {
        public static Node<String> Tokenize(String input)
        {
            String[] lines = input.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < lines.Length; i++)
            {
                char[] chars = lines[i].ToCharArray();
                string token = "";

                for (int j = 0; j < chars.Length; j++)
                {
                    //string temp = 
                    token += chars[j];
                }
            }

            return null;
        }
    }
}
