using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class Tokenizer
    {

        static List<Token> TokenList = new List<Token>();
        public static Node<String> Tokenize(String input)
        {
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
                                level = LevelChar.setLevel((LevelChar.LevelChars)token.EnumValue);
                            }

                            if (token.Value != null && token.Value.Length >= 1)
                            {
                                linePos--;
                            }
                            token = new Token(line, level);


                        }
                    }
                }
                //////////////////////////////////////////
                for (int i = 0; i < TokenList.Count; i++)
                {
                    if (token.EnumType == typeof(BinaireOperator.BinaireOperators))
                    {
                        Token[] partners = new Token[2];
                        if (i < 0 && TokenList[i - 1].EnumType == typeof(Variable))
                        {
                            partners[0] = TokenList[i - 1];
                        }
                        if (i < TokenList.Count && TokenList[i + 1].EnumType == typeof(Variable))
                        {
                            partners[0] = TokenList[i + 1];
                        }
                        token.Partners = partners;
                    }
                    else if (token.EnumType == typeof(UnaireOperator.UnaireOperators))
                    {
                        Token[] partners = new Token[1];
                        if (i < 0 && TokenList[i - 1].EnumType == typeof(Variable))
                        {
                            partners[0] = TokenList[i - 1];
                        }
                        if (i < TokenList.Count && TokenList[i + 1].EnumType == typeof(Variable))
                        {
                            if (partners != null)
                            {
                                throw new Exception("Error: Unaire operator is used as binaire operator");
                            }
                            partners[0] = TokenList[i + 1];
                        }
                        token.Partners = partners;
                    }
                    else if (token.EnumType == typeof(KeyWords.keyWords) || (token.EnumValue == 0) || (token.EnumValue == 1))
                    {
                        List<Token> partners = new List<Token>();

                        int pos = i;
                        bool found = false;
                        while (pos < TokenList.Count && !found)
                        {
                            int tempLevel = 0;
                            if (TokenList[pos].EnumType == typeof(LevelChar.LevelChars) && TokenList[pos].EnumValue == (int)LevelChar.LevelChars._curlyBracketCLose && TokenList[pos].Level == token.Level + 1)
                            {
                                found = true;
                            }
                            pos++;
                        }

                        if (pos < TokenList.Count && (token.EnumValue == (int)KeyWords.keyWords._elseif) || (token.EnumValue == (int)KeyWords.keyWords._else))
                        {
                            token.Partners = new Token[1] { TokenList[pos] };
                        }



                        token.Partners = partners.ToArray();
                    }

                }
            }
            catch (Exception)
            {
                throw new Exception("Syntax error: at " + (token.Line + 1) + " - " + (token.LinePos + 1));
            }
            return null;
        }
    }
}
