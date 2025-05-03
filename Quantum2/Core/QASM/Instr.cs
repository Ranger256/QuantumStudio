using System;
using System.Collections.Generic;

namespace Quantum2.Core.QASM
{
    public class Arg
    {
        private int[] _typeTokens;
        private int[] _typeArguments;

        public int[] TypeTokens
        {
            get
            {
                return _typeTokens;
            }
        }

        public int[] TypeArguments
        {
            get
            {
                return _typeArguments;
            }
        }

        public Arg(int[] typeTokens,int[] typeArguments)
        {
            _typeTokens = typeTokens;
            _typeArguments = typeArguments;
        }
    }
    public class Instr
    {
        protected int _typeToken;

      //  protected int _typeReturnValue;

        protected int _countArgs;

        protected Arg[] _validArgs;

        protected ErrorHandler _errorHandler;

        public int TypeToken
        {
            get
            {
                return _typeToken;
            }
            set
            {
                _typeToken = value;
            }
        }

        /*public int TypeReturnValue
        {
            get
            {
                return _typeReturnValue;
            }
        }*/

        public int CountArgs
        {
            get
            {
                return _countArgs;
            }
        }

        public Arg[] ValidArgs
        {
            get
            {
                return _validArgs;
            }
        }

        public Instr(int typeToken, int typeReturnValue, int countArgs, Arg[] validArgs)
        {
            _typeToken = typeToken;
            //_typeReturnValue = typeReturnValue;
            _countArgs = countArgs;
            _validArgs = validArgs;

            _errorHandler = new ErrorHandler();
        }

        public virtual void ExecuteInstruction(List<ASTNode> args)
        {

        }

        protected Instr(int typeToken)
        {
            _typeToken = typeToken;

            _errorHandler = new ErrorHandler();
        }

        protected Instr()
        {
            _errorHandler = new ErrorHandler();
        }

        protected bool IsNullValue(string name, Dictionary<string, ID> ids)
        {
            return ids[name].Value == null;
        }

        protected object GetValue(Token token, Dictionary<string, ID> ids, Dictionary<Point, Literal> literals)
        {

            if (token.PointLiteral != null)
            {
                return literals[token.PointLiteral].Value;
            }
            else if (token.NameID != null)
            {
                return ids[token.NameID].Value;
            }
            else
            {
                //error
            }

            return null;
        }

        protected int GetType(Token token, Dictionary<string, ID> ids, Dictionary<Point, Literal> literals)
        {
            if (token.PointLiteral != null)
            {
                return literals[token.PointLiteral].Type;
            }
            else if (token.NameID != null)
            {
                return ids[token.NameID].Type;
            }
            else
            {
                //error
            }

            return 0;
        }

        protected object CFT(int type, double valTemp)
        {
            object value = null;

            if(type == (int)STTypes.real4)
            {
                value = (float)valTemp;
            }
            else if(type == (int)STTypes.real8)
            {
                value = valTemp;
            }

            return value;
        }

        protected object CIT(int type, long valTemp)
        {
            object value = null;

            if (type == (int)STTypes.type_byte)
            {
                value = (byte)BitConverter.GetBytes(valTemp)[0];
            }
            else if (type == (int)STTypes.word)
            {
                value = BitConverter.ToUInt16(BitConverter.GetBytes(valTemp), 0);
            }
            else if (type == (int)STTypes.dword)
            {
                value = BitConverter.ToUInt32(BitConverter.GetBytes(valTemp), 0);
            }
            else if (type == (int)STTypes.qword)
            {
                value = BitConverter.ToUInt64(BitConverter.GetBytes(valTemp), 0);
            }
            else if (type == (int)STTypes.type_sbyte)
            {
                value = (sbyte)BitConverter.GetBytes(valTemp)[0];
            }
            else if (type == (int)STTypes.sword)
            {
                value = BitConverter.ToInt16(BitConverter.GetBytes(valTemp), 0);
            }
            else if (type == (int)STTypes.sdword)
            {
                value = BitConverter.ToInt32(BitConverter.GetBytes(valTemp), 0);
            }
            else if (type == (int)STTypes.sqword)
            {
                value = valTemp;
            }

            return value;
        }
    }
}
