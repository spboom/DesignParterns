using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor.Nodes
{
    public class Condition : Node
    {
        private Token l_value;
        private Token r_value;
        private Token condition;
        private Token vm_l_value; //voor de virtualmachine
        private Token vm_r_value; //voor de virtualmachine

        private Token L_value { get { return l_value; } }
        public Token R_value { get { return r_value; } }
        public Token Vm_l_value { set { vm_l_value = value; } }
        public Token Vm_r_value { set { vm_r_value = value; } }

        public Condition(List<Token> piece)
        {
            this.l_value = piece[0];
            this.r_value = piece[2];
            this.condition = piece[1];
        }

        public Boolean calculate()
        {
            if (condition.EnumType == typeof(BinaireOperator.BinaireOperators) && condition.EnumValue == (int)BinaireOperator.BinaireOperators._greaterThan)
            {
                return Int32.Parse(vm_l_value.Value) > Int32.Parse(vm_r_value.Value);
            }
            else if (condition.EnumType == typeof(BinaireOperator.BinaireOperators) && condition.EnumValue == (int)BinaireOperator.BinaireOperators._smallerThan)
            {
                return Int32.Parse(vm_l_value.Value) < Int32.Parse(vm_r_value.Value);
            }
            else if (condition.EnumType == typeof(BinaireOperator.BinaireOperators) && condition.EnumValue == (int)BinaireOperator.BinaireOperators._equals)
            {
                return Int32.Parse(vm_l_value.Value) == Int32.Parse(vm_r_value.Value);
            }
            else if (condition.EnumType == typeof(BinaireOperator.BinaireOperators) && condition.EnumValue == (int)BinaireOperator.BinaireOperators._notEquals)
            {
                return Int32.Parse(vm_l_value.Value) != Int32.Parse(vm_r_value.Value);
            }

            return false;
        }
    }
}
