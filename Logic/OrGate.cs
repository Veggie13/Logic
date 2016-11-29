using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    class OrGate : MultiInputGate
    {
        public OrGate(params ILogicGate[] inputs)
            : base(inputs)
        {
        }

        protected override string Operator
        {
            get { return "+"; }
        }

        public override bool Eval(Dictionary<char, bool> values)
        {
            return Inputs.Any(g => g.Eval(values));
        }
    }
}
