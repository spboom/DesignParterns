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
            _if,
            _elseif,
            _else,
            _while,
            _for,
            _foreach
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
                default:
                    return null;
            }

        }


    }

    public class BinaireOperator
    {
        public enum BinaireOperators
        {
            _minus,
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
            _negative,
            _addOne,
            _minusOne
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
                default:
                    return null;
            }
        }
    }

    public class LevelChar
    {
        public enum LevelChars
        {
            _bracketOpen,
            _bracketClose,
            _hookBracketOpen,
            _hookBracketClose,
            _curlyBracketOpen,
            _curlyBracketCLose
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

    public static class KeyWordChecker
    {
        static KeyWords keywords = new KeyWords();
        static BinaireOperator binaireOperators = new BinaireOperator();
        static UnaireOperator unaireOperators = new UnaireOperator();
        static LevelChar levelChars = new LevelChar();

        public static bool check(String value)
        {
            foreach (KeyWords.keyWords keyWord in GetValues<KeyWords.keyWords>())
            {
                if (keywords.ToString(keyWord).StartsWith(value.ToLower()))
                {
                    return true;
                }
            }
            foreach (BinaireOperator.BinaireOperators keyWord in GetValues<BinaireOperator.BinaireOperators>())
            {
                if (binaireOperators.ToString(keyWord).StartsWith(value.ToLower()))
                {
                    return true;
                }
            }
            foreach (UnaireOperator.UnaireOperators keyWord in GetValues<UnaireOperator.UnaireOperators>())
            {
                if (unaireOperators.ToString(keyWord).StartsWith(value.ToLower()))
                {
                    return true;
                }
            }
            foreach (LevelChar.LevelChars keyWord in GetValues<LevelChar.LevelChars>())
            {
                if (levelChars.ToString(keyWord).StartsWith(value.ToLower()))
                {
                    return true;
                }
            }

            return false;
        }

        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

    }
}
