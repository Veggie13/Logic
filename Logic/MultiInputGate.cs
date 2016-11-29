using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    abstract class MultiInputGate : LogicBase
    {
        public MultiInputGate(params ILogicGate[] inputs)
        {
            _inputs.AddRange(inputs);
        }

        private List<ILogicGate> _inputs = new List<ILogicGate>();
        public List<ILogicGate> Inputs
        {
            get { return _inputs; }
        }

        protected abstract string Operator
        {
            get;
        }

        public override string ToString()
        {
            return string.Join(Operator, _inputs.Select(g => g.Paren()));
        }
    }
}
