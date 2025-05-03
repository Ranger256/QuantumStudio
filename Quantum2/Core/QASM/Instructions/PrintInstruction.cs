using System;
using System.Text;
using System.Collections.Generic;

namespace Quantum2.Core.QASM.Instructions
{
    public class PrintInstruction : Instr
    {
        private Dictionary<string, ID> _ids;
        private Dictionary<Point, Literal> _literals;

        private StringBuilder _outputStringBuilder;

        public PrintInstruction(Dictionary<string, ID> ids, Dictionary<Point, Literal> literals, StringBuilder outputString) : base()
        {
            _ids = ids;
            _literals = literals;
            _outputStringBuilder = outputString;

            _countArgs = 1;

            _validArgs = new Arg[1]
            {
                new Arg(new int[2]
                {
                    (int)STToken.id,
                    (int)STToken.literal
                }, new int[]
                {
                    (int)STTypes.qreg,
                    (int)STTypes.reg,

                    (int)STTypes.qbit,
                    (int)STTypes.bit,

                    (int)STTypes.qstate,

                    (int)STTypes.gate,

                    (int)STTypes.rule,

                    (int)STTypes.type_byte,
                    (int)STTypes.word,
                    (int)STTypes.dword,
                    (int)STTypes.qword,

                    (int)STTypes.type_sbyte,
                    (int)STTypes.sword,
                    (int)STTypes.sdword,
                    (int)STTypes.sqword,

                    (int)STTypes.real4,
                    (int)STTypes.real8,

                    (int)STTypes.@string,
                    
                    (int)STTypes.complex,

                    (int)STTypes.label
                })
            };
        }

        public override void ExecuteInstruction(List<ASTNode> args)
        {
            if (args.Count == 1)
            {
                object value = GetValue(args[0].Token, _ids, _literals);
                
                if(value != null)
                {
                    string source = value.ToString();

                    Console.WriteLine(value.GetType().Name + " " + GetType(args[0].Token, _ids, _literals));

                    Console.WriteLine(source);

                    _outputStringBuilder.Append(source + Environment.NewLine);
                }
                else
                {
                    Console.WriteLine("PRINT: NULL VALUE");
                    //error
                }
            }
            else
            {
                //error
            }
        }
    }
}
