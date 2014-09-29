using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class Tokenizer
    {
        static List<Token> TokenList;
        public static List<Token> Tokenize(String input)
        {
            TokenList = new List<Token>();
            int line = 0, linePos = 0;
            Token token = new Token(0, 0);
            try
            {
                String[] lines = (input + "\r").Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                int level = 0;

                for (line = 0; line < lines.Length; line++)
                {
                    char[] chars = lines[line].ToCharArray();
                    token = new Token(line, level);
                    Type enumType = null;
                    for (linePos = 0; linePos < chars.Length; linePos++)
                    {
                        int enumValue = KeyWordChecker.check(token.Value + chars[linePos], out enumType);
                        if (enumValue >= 0)
                        {
                            if (token.Value == null || token.Value == "")
                            {
                                token.Value = "";
                                token.LinePos = linePos;
                            }
                            token.Value += chars[linePos];
                            token.EnumValue = enumValue;
                            token.EnumType = enumType;
                        }
                        else
                        {
                            if (token.Value != null)
                            {
                                TokenList.Add(token);
                            }
                            if (token.EnumType == typeof(LevelChar.LevelChars))
                            {
                                level = LevelChar.setLevel(token);
                            }
                            else if (token.EnumType == typeof(KeyWords.keyWords) && token.EnumValue <= 4)
                            {
                                KeyWords.setKeyWord(token);
                            }

                            if (token.Value != null && token.Value.Length >= 1)
                            {
                                linePos--;
                            }
                            token = new Token(line, level);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Syntax error: at " + (token.Line + 1) + " - " + (token.LinePos + 1));
            }
            return TokenList;
        }
    }
}
