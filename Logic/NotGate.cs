using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    class NotGate : LogicBase
    {
        public ILogicGate Input
        {
            get;
            set;
        }

        public override bool Eval(Dictionary<char, bool> values)
        {
            return !Input.Eval(values);
        }

        public override string ToString()
        {
            return "~" + Input.Paren();
        }
    }
}
