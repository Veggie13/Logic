using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    class Program
    {
        static void Main(string[] args)
        {
            var A = new LogicInput('A');
            var B = new LogicInput('B');
            var C = new LogicInput('C');
            var D = new LogicInput('D');
            var E = new LogicInput('E');
            var F = new LogicInput('F');

            //var not01 = !A;
            //var not02 = !or01;
            //var not03 = !nand01;
            //var not04 = !and01;
            //var not05 = !C;
            //var not06 = !D;
            //var not07 = !D;
            //var not08 = !or11;
            //var not09 = !nand04;
            //var not10 = !not11;
            //var not11 = !and07;
            //var not12 = !and07;
            //var not13 = !E;
            //var not14 = !not13;
            //var not15 = !not14;
            //var not16 = !not15;

            //var or01 = B | not01;
            //var or02 = not03 | and05;
            //var or03 = nand02 | nand05;
            //var or04 = and03 | not05 | not07;
            //var or05 = or03 | or11;
            //var or06 = or02 | or05 | and06;
            //var or07 = B | or04;
            //var or08 = or07 | not10;
            //var or09 = not06 | and04;
            //var or10 = F | not10;
            //var or11 = or10 | nand06;
            //var or12 = or11 | nor02;
            //var or13 = nand06 | and08;

            //var and01 = not02 & or03;
            //var and02 = new AndGate();
                //and02.Inputs.Add(or06);
                //and02.Inputs.Add(nand03);
            //var and03 = B & C;
            //var and04 = B & C;
            //var and05 = or05 & or11;
            //var and06 = nand07 & or12;
            //var and07 = E & F;
            //var and08 = not12 & E;

            //var nand01 = and02 / and02;
            //var nand02 = not02 / nor01;
            //var nand03 = not04 / or02;
            //var nand04 = nand02 / or05;
            //var nand05 = nor01 / or07;
            //var nand06 = not05 / or09;
            //var nand07 = not08 / or08;

            //var nor01 = and03 - not01;
            //var nor02 = or13 - not15;
            //var nor03 = nor02 - not16;
            //var nor04 = new OrGate(nor03, or12, nand07, not09).Not();

            var not01 = !A;

            var or01 = B | not01;
            var not02 = !or01;
            
            var and02 = new AndGate();
            var nand01 = and02 / and02;
            var not03 = !nand01;

            var and03 = B & C;
            var nor01 = and03 - not01;
            var nand02 = not02 / nor01;
            var not05 = !C;
            var not07 = !D;
            var or04 = and03 | not05 | not07;
            var or07 = B | or04;
            var nand05 = nor01 / or07;
            var or03 = nand02 | nand05;
            var and01 = not02 & or03;
            var not04 = !and01;

            var not06 = !D;

            var and07 = E & F;
            var not11 = !and07;
            var not10 = !not11;
            var or10 = F | not10;
            var and04 = B & C;
            var or09 = not06 | and04;
            var nand06 = not05 / or09;
            var or11 = or10 | nand06;
            var not08 = !or11;

            var or05 = or03 | or11;
            var nand04 = nand02 / or05;
            var not09 = !nand04;

            var not12 = !and07;
            var not13 = !E;
            var not14 = !not13;
            var not15 = !not14;
            var not16 = !not15;

            var and05 = or05 & or11;
            var or02 = not03 | and05;

            var or08 = or07 | not10;
            var nand07 = not08 / or08;
            var and08 = not12 & E;
            var or13 = nand06 | and08;
            var nor02 = or13 - not15;
            var or12 = or11 | nor02;
            var and06 = nand07 & or12;
            var or06 = or02 | or05 | and06;
            and02.Inputs.Add(or06);

            var nand03 = not04 / or02;
            and02.Inputs.Add(nand03);

            var nor03 = nor02 - not16;
            var nor04 = new OrGate(nor03, or12, nand07, not09).Not();

            Dictionary<char, bool> values = new Dictionary<char, bool>();
            Console.WriteLine("A B C D E F   X");
            for (int i = 0; i < 1 << 6; i++)
            {
                values['A'] = ((i & 1) == 1);
                values['B'] = ((i & 2) == 2);
                values['C'] = ((i & 4) == 4);
                values['D'] = ((i & 8) == 8);
                values['E'] = ((i & 16) == 16);
                values['F'] = ((i & 32) == 32);

                bool result = nor04.Eval(values);

                Console.WriteLine("{0} {1} {2} {3} {4} {5}   {6}",
                    values['A'] ? "T" : "F",
                    values['B'] ? "T" : "F",
                    values['C'] ? "T" : "F",
                    values['D'] ? "T" : "F",
                    values['E'] ? "T" : "F",
                    values['F'] ? "T" : "F",
                    result ? "T" : "F");
            }
        }
    }
}
