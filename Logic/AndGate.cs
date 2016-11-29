using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    class AndGate : MultiInputGate
    {
        public AndGate(params ILogicGate[] inputs)
            : base(inputs)
        {
        }

        protected override string Operator
        {
            get { return "&"; }
        }

        public override bool Eval(Dictionary<char, bool> values)
        {
            return Inputs.All(g => g.Eval(values));
        }
    }
}
