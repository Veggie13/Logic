using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    interface ILogicGate
    {
        bool Eval(Dictionary<char, bool> values);
        string ToString();
    }

    static class LogicGateExtensions
    {
        public static string Paren(this ILogicGate gate)
        {
            string s = gate.ToString();
            return (s.Length > 1) ? ("(" + s + ")") : s;
        }

        public static NotGate Not(this ILogicGate gate)
        {
            return new NotGate() { Input = gate };
        }

        public static AndGate And(this ILogicGate gate, ILogicGate other)
        {
            return new AndGate(gate, other);
        }

        public static OrGate Or(this ILogicGate gate, ILogicGate other)
        {
            return new OrGate(gate, other);
        }

        public static NotGate Nand(this ILogicGate gate, ILogicGate other)
        {
            return gate.And(other).Not();
        }

        public static NotGate Nor(this ILogicGate gate, ILogicGate other)
        {
            return gate.Or(other).Not();
        }
    }

    abstract class LogicBase : ILogicGate
    {
        public static NotGate operator !(LogicBase input)
        {
            return input.Not();
        }

        public static AndGate operator &(LogicBase input, ILogicGate other)
        {
            return input.And(other);
        }

        public static OrGate operator |(LogicBase input, ILogicGate other)
        {
            return input.Or(other);
        }

        public static NotGate operator /(LogicBase input, ILogicGate other)
        {
            return input.Nand(other);
        }

        public static NotGate operator -(LogicBase input, ILogicGate other)
        {
            return input.Nor(other);
        }

        public abstract bool Eval(Dictionary<char, bool> values);
    }
}
