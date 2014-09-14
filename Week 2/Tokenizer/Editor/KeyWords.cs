using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class KeyWords
    {
        public enum keyWords
        {
            _if = 0,
            _elseif,
            _else,
            _while,
            _for,
            _foreach,
            _true,
            _false,
            _lineEnd,
        }

        public string ToString(keyWords value)
        {
            switch (value)
            {
                case keyWords._if:
                    return "if";
                case keyWords._elseif:
                    return "elseif";
                case keyWords._else:
                    return "else";
                case keyWords._while:
                    return "while";
                case keyWords._for:
                    return "for";
                case keyWords._foreach:
                    return "foreach";
                case keyWords._true:
                    return "true";
                case keyWords._false:
                    return "false";
                case keyWords._lineEnd:
                    return ";";
                default:
                    return null;
            }

        }


    }

    public class BinaireOperator
    {
        public enum BinaireOperators
        {
            _minus = 0,
            _add,
            _devide,
            _mulitply,
            _notEquals,
            _equals,
            _greaterThan,
            _greaterThanOrEquals,
            _smallerThan,
            _smallerThanOrEquals,
            _and,
            _or,
            _set
        }

        public string ToString(BinaireOperators value)
        {
            switch (value)
            {
                case BinaireOperators._minus:
                    return "-";
                case BinaireOperators._add:
                    return "+";
                case BinaireOperators._devide:
                    return "/";
                case BinaireOperators._mulitply:
                    return "*";
                case BinaireOperators._notEquals:
                    return "!=";
                case BinaireOperators._equals:
                    return "==";
                case BinaireOperators._greaterThan:
                    return ">";
                case BinaireOperators._greaterThanOrEquals:
                    return ">=";
                case BinaireOperators._smallerThan:
                    return "<";
                case BinaireOperators._smallerThanOrEquals:
                    return "<=";
                case BinaireOperators._and:
                    return "&&";
                case BinaireOperators._or:
                    return "||";
                case BinaireOperators._set:
                    return "=";
                default:
                    return null;
            }

        }
    }

    public class UnaireOperator
    {
        public enum UnaireOperators
        {
            _negative = 0,
            _addOne,
            _minusOne,
            _return

        }

        public string ToString(UnaireOperators value)
        {
            switch (value)
            {
                case UnaireOperators._negative:
                    return "-";
                case UnaireOperators._addOne:
                    return "++";
                case UnaireOperators._minusOne:
                    return "--";
                case UnaireOperators._return:
                    return "return";
                default:
                    return null;
            }
        }
    }

    public class LevelChar
    {

        private static Stack<LevelChars> levels = new Stack<LevelChars>();
        public enum LevelChars
        {
            _bracketOpen = 0,
            _bracketClose,
            _hookBracketOpen,
            _hookBracketClose,
            _curlyBracketOpen,
            _curlyBracketCLose
        }

        public static int setLevel(LevelChars levelChar)//TEST!!!
        {
            switch (levelChar)
            {
                case LevelChars._bracketOpen:
                case LevelChars._curlyBracketOpen:
                case LevelChars._hookBracketOpen:
                    levels.Push(levelChar);
                    break;
                case LevelChars._bracketClose:
                case LevelChars._curlyBracketCLose:
                case LevelChars._hookBracketClose:
                    if (levels.Peek() == (LevelChars)levelChar - 1)
                    {
                        levels.Pop();
                    }
                    else
                    {
                        throw new Exception();
                    }
                    break;
                default:
                    throw new Exception();
            }
            return levels.Count;
        }

        public string ToString(LevelChars value)
        {
            switch (value)
            {
                case LevelChars._bracketOpen:
                    return "(";
                case LevelChars._bracketClose:
                    return ")";
                case LevelChars._hookBracketOpen:
                    return "[";
                case LevelChars._hookBracketClose:
                    return "]";
                case LevelChars._curlyBracketOpen:
                    return "{";
                case LevelChars._curlyBracketCLose:
                    return "}";
                default:
                    return null;
            }
        }
    }

    public class Variable
    {
        string name;
    }

    public static class KeyWordChecker
    {
        static KeyWords keywords = new KeyWords();
        static BinaireOperator binaireOperators = new BinaireOperator();
        static UnaireOperator unaireOperators = new UnaireOperator();
        static LevelChar levelChars = new LevelChar();

        public static int check(String value, out Type enumType)
        {
            enumType = null;

            foreach (KeyWords.keyWords keyWord in GetValues<KeyWords.keyWords>())
            {
                if (keywords.ToString(keyWord).StartsWith(value.ToLower()))
                {
                    enumType = typeof(KeyWords.keyWords);
                    return (int)keyWord;
                }
            }
            foreach (BinaireOperator.BinaireOperators keyWord in GetValues<BinaireOperator.BinaireOperators>())
            {
                if (binaireOperators.ToString(keyWord).StartsWith(value.ToLower()))
                {
                    enumType = typeof(BinaireOperator.BinaireOperators);
                    return (int)keyWord;
                }
            }
            foreach (UnaireOperator.UnaireOperators keyWord in GetValues<UnaireOperator.UnaireOperators>())
            {
                if (unaireOperators.ToString(keyWord).StartsWith(value.ToLower()))
                {
                    enumType = typeof(UnaireOperator.UnaireOperators);
                    return (int)keyWord;
                }
            }
            foreach (LevelChar.LevelChars keyWord in GetValues<LevelChar.LevelChars>())
            {
                if (levelChars.ToString(keyWord).StartsWith(value.ToLower()))
                {
                    enumType = typeof(LevelChar.LevelChars);
                    return (int)keyWord;
                }
            }
            char[] startValues = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '_' };
            char[] numbers = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            var temp = new List<char>(startValues);
            temp.AddRange(numbers);
            char[] vallidChars = temp.ToArray();
            bool vallid = false;

            char[] charValue = value.ToCharArray();
            for (int j = 0; j < charValue.Length; j++)
            {
                if (j == 0)
                {
                    for (int i = 0; i < startValues.Length; i++)
                    {
                        if (charValue[j] == startValues[i])
                        {
                            vallid = true;
                            break;
                        }
                    }
                    if (!vallid)
                    {
                        return -1;
                    }
                }
                else
                {
                    bool contains = false;
                    for (int i = 0; i < vallidChars.Length; i++)
                    {
                        if (charValue[j] == vallidChars[i])
                        {
                            contains = true;
                            break;
                        }
                    }
                    if (!contains)
                    {
                        return -1;
                    }
                }
            }
            enumType = typeof(Variable);
            return 0;

        }

        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

    }
}
