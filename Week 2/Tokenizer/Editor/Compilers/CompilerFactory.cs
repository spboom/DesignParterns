using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    class CompilerFactory
    {
        public static Compiler getCompiler(Token token)
        {

            if (token.EnumType == typeof(KeyWords.keyWords))
            {
                return getKeyWordCompiler(token);
            }
            else if (token.EnumType == typeof(BinaireOperator.BinaireOperators))
            {
                return getBinaireOperatorCompiler(token);
            }
            else if (token.EnumType == typeof(UnaireOperator.UnaireOperators))
            {
                return getUnaireOperatorCompiler(token);
            }
            else if (token.EnumType == typeof(Variable))
            {
                //??
            }

            return null;
        }

        private static Compiler getKeyWordCompiler(Token token)
        {
            switch ((KeyWords.keyWords)token.EnumValue)
            {
                case KeyWords.keyWords._if:
                    {
                        if (token.Partner == null)
                            return new CompilerIf();
                        else
                        {
                            return new CompilerIfElse();
                        }
                    }
                case KeyWords.keyWords._for:
                    return new CompilerFor();
                case KeyWords.keyWords._foreach:
                    return new CompilerForEach();
                case KeyWords.keyWords._do:
                    return new CompilerDoWhile();
                case KeyWords.keyWords._while:
                    {
                        if (token.Partner == null)
                        {
                            return new CompilerWhile();
                        }
                        return null;
                    }
                case KeyWords.keyWords._elseif:
                case KeyWords.keyWords._else:
                    return null;
                default:
                    throw new Exception("UnKnown KeyWord: " + token.Value);
            }
        }
        private static Compiler getBinaireOperatorCompiler(Token token)
        {
            switch ((BinaireOperator.BinaireOperators)token.EnumValue)
            {
                case BinaireOperator.BinaireOperators._minus:
                    return new CompilerMinus();
                case BinaireOperator.BinaireOperators._add:
                    return new CompilerAdd();
                case BinaireOperator.BinaireOperators._devide:
                    return new CompilerDivide();
                case BinaireOperator.BinaireOperators._mulitply:
                    return new CompilerMultiply();
                case BinaireOperator.BinaireOperators._notEquals:
                    return new CompilerNotEquals();
                case BinaireOperator.BinaireOperators._equals:
                    return new CompilerEquals();
                case BinaireOperator.BinaireOperators._greaterThan:
                    return new CompilerGreaterThan();
                case BinaireOperator.BinaireOperators._greaterThanOrEquals:
                    return new CompilerGreaterThanOrEquals();
                case BinaireOperator.BinaireOperators._smallerThan:
                    return new CompilerSmallerThan();
                case BinaireOperator.BinaireOperators._smallerThanOrEquals:
                    return new CompilerSmallerThanOrEquals();
                case BinaireOperator.BinaireOperators._and:
                    return new CompilerAnd();
                case BinaireOperator.BinaireOperators._or:
                    return new CompilerOr();
                case BinaireOperator.BinaireOperators._set:
                    return new CompilerSet();
                default:
                    throw new Exception("UnKnown Binaire Operator: " + token.Value);
            }
        }
        private static Compiler getUnaireOperatorCompiler(Token token)
        {
            switch ((UnaireOperator.UnaireOperators)token.EnumValue)
            {
                case UnaireOperator.UnaireOperators._negative:
                    return new CompilerNegative();
                case UnaireOperator.UnaireOperators._addOne:
                    return new CompilerAddOne();
                case UnaireOperator.UnaireOperators._minusOne:
                    return new CompilerMinusOne();
                case UnaireOperator.UnaireOperators._return:
                    return null;
                default:
                    throw new Exception("UnKnown Unaire Operator: " + token.Value);
            }
        }
    }
}
