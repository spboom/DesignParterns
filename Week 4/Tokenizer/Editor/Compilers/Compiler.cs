using Editor.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class Compiler
    {
        static LinkedList<Node> nodeList;

        public Compiler()
        {
            nodeList = new LinkedList<Node>();
        }

        public LinkedList<Node> Compile(List<Token> tokenList)
        {
            List<List<Token>> pieceList = splitList(tokenList);

            foreach (List<Token> piece in pieceList)
            {
                handlePiece(piece);
            }

            return nodeList;
        }

        private List<List<Token>> splitList(List<Token> tokenList)
        {
            List<List<Token>> splitList = new List<List<Token>>();
            List<Token> part = new List<Token>();

            foreach (Token token in tokenList)
            {
                part.Add(token);

                if (token.EnumType == typeof(LevelChar.LevelChars) && token.EnumValue == (int)LevelChar.LevelChars._curlyBracketCLose)
                {
                    splitList.Add(part);
                    part = new List<Token>();
                }
                else
                {
                    if(token.EnumType == typeof(KeyWords.keyWords) && token.EnumValue == (int)KeyWords.keyWords._lineEnd && token.Level == part[0].Level)
                    {
                        splitList.Add(part);
                        part = new List<Token>();
                    }
                }
            }

            return splitList;
        }

        private void handlePiece(List<Token> piece)
        {
            if (piece[0].EnumType == typeof(Variable))
            {
                piece.RemoveAt(piece.Count - 1);
                nodeList.AddLast(new Assignment(piece));
            } 
            else if (piece[0].EnumType == typeof(KeyWords.keyWords) && piece[0].EnumValue == (int)KeyWords.keyWords._if) 
            {
                _if(piece);
            }
            else if (piece[0].EnumType == typeof(KeyWords.keyWords) && piece[0].EnumValue == (int)KeyWords.keyWords._while) 
            {
                _while(piece);
            }
        }

        private void _if(List<Token> piece)
        {
            Condition condition = new Condition(_condition(piece));
            nodeList.AddLast(condition);

            ConditionalJump conditionaljump = new ConditionalJump();
            nodeList.AddLast(conditionaljump);

            DoNothing donothing_true = new DoNothing();
            nodeList.AddLast(donothing_true);
            conditionaljump.Jump_true = nodeList.Last;

            List<List<Token>> statements = _statement(piece);
            foreach (List<Token> tokens in statements)
            {
                handlePiece(tokens);
            }

            DoNothing donothing_false = new DoNothing();
            nodeList.AddLast(donothing_false);
            conditionaljump.Jump_false = nodeList.Last;
        }

        private void _while(List<Token> piece)
        {
            DoNothing donothing = new DoNothing();
            nodeList.AddLast(donothing);

            LinkedListNode<Node> donothing_node = nodeList.Last;

            Condition condition = new Condition(_condition(piece));
            nodeList.AddLast(condition);

            ConditionalJump conditionaljump = new ConditionalJump();
            nodeList.AddLast(conditionaljump);

            DoNothing donothing_true = new DoNothing();
            nodeList.AddLast(donothing_true);
            conditionaljump.Jump_true = nodeList.Last;

            List<List<Token>> statements = _statement(piece);
            foreach (List<Token> tokens in statements)
            {
                handlePiece(tokens);
            }

            Jump jump = new Jump();
            nodeList.AddLast(jump);
            jump.Jump_location = donothing_node;

            DoNothing donothing_false = new DoNothing();
            nodeList.AddLast(donothing_false);
            conditionaljump.Jump_false = nodeList.Last;
        }

        private List<List<Token>> _statement(List<Token> statement)
        {
            List<Token> statement_list = new List<Token>();
            bool state = false;

            foreach (Token token in statement)
            {
                if (token.EnumType == typeof(LevelChar.LevelChars) && token.EnumValue == (int)LevelChar.LevelChars._curlyBracketOpen)
                {
                    state = true;
                }
                else if (token.EnumType == typeof(LevelChar.LevelChars) && token.EnumValue == (int)LevelChar.LevelChars._curlyBracketCLose)
                {
                    break;
                }

                if (state && !(token.EnumType == typeof(LevelChar.LevelChars) && token.EnumValue == (int)LevelChar.LevelChars._curlyBracketOpen))
                {
                    statement_list.Add(token);
                }
            }

            return splitList(statement_list);
        }

        private List<Token> _condition(List<Token> condition)
        {
            List<Token> condition_piece = new List<Token>();
            bool con = false;

            foreach(Token token in condition)
            {
                if(token.EnumType == typeof(LevelChar.LevelChars) && token.EnumValue == (int)LevelChar.LevelChars._bracketOpen)
                {
                    con = true;
                }
                else if (token.EnumType == typeof(LevelChar.LevelChars) && token.EnumValue == (int)LevelChar.LevelChars._bracketClose)
                {
                    return condition_piece;
                }

                if (con && !(token.EnumType == typeof(LevelChar.LevelChars) && token.EnumValue == (int)LevelChar.LevelChars._bracketOpen))
                {
                    condition_piece.Add(token);
                }
            }

            return condition;
        }
    }
}
