using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor.Nodes
{
    public class Assignment : Node
    {
        private Token l_value;
        List<Token> r_value = new List<Token>();
        List<Token> vm_value = new List<Token>(); //voor de virtualmachine

        private Token L_value { get { return l_value; }}
        public List<Token> R_value { get { return r_value;}}
        public List<Token> Vm_value { set { vm_value = value; }}

        public Assignment(List<Token> piece)
        {
            this.l_value = piece[0];
            for (int i = 2; i < piece.Count; i++ )
            {
                r_value.Add(piece[i]);
            }
        }

        public int calculate()
        {
            if(vm_value.Count == 1)
            {
                return Int32.Parse(vm_value[0].Value);
            }
            else
            {
                if(vm_value[1].EnumType == typeof(BinaireOperator.BinaireOperators) && vm_value[1].EnumValue == (int)BinaireOperator.BinaireOperators._add)
                {
                    return Int32.Parse(vm_value[0].Value) + Int32.Parse(vm_value[2].Value);
                }
                else if (vm_value[1].EnumType == typeof(BinaireOperator.BinaireOperators) && vm_value[1].EnumValue == (int)BinaireOperator.BinaireOperators._minus)
                {
                    return Int32.Parse(vm_value[0].Value) - Int32.Parse(vm_value[2].Value);
                }
                else if (vm_value[1].EnumType == typeof(BinaireOperator.BinaireOperators) && vm_value[1].EnumValue == (int)BinaireOperator.BinaireOperators._mulitply)
                {
                    return Int32.Parse(vm_value[0].Value) * Int32.Parse(vm_value[2].Value);
                }
                else if (vm_value[1].EnumType == typeof(BinaireOperator.BinaireOperators) && vm_value[1].EnumValue == (int)BinaireOperator.BinaireOperators._devide)
                {
                    return Int32.Parse(vm_value[0].Value) / Int32.Parse(vm_value[2].Value);
                }

                return 0;
            }
        }
    }
}
