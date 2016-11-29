using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    class LogicInput : LogicBase
    {
        private char _name;

        public LogicInput(char name)
        {
            _name = name;
        }

        public override bool Eval(Dictionary<char, bool> values)
        {
            return values[_name];
        }

        public override string ToString()
        {
            return _name.ToString();
        }
    }
}
