namespace Quantum2.Core.QASM
{
    public class Point
    {
        private int _line;
        private int _part;

        public int Line
        {
            get
            {
                return _line;
            }
        }

        public int Part
        {
            get
            {
                return _part;
            }
        }

        public Point(int line, int part)
        {
            _line = line;
            _part = part;
        }
    }

    public class Token
    {
        private int _type;

        private int _typeValue;

        private string _nameID;
        private Point _pointLiteral;

        public int Type
        {
            get
            {
                return _type;
            }
        }

        public int TypeValue
        {
            get
            {
                return _typeValue;
            }
        }

        public string NameID
        {
            get
            {
                return _nameID;
            }
        }

        public Point PointLiteral
        {
            get
            {
                return _pointLiteral;
            }
        }

        public Token(int type)
        {
            _type = type;
        }

        public Token(int type,int typeValue, string nameID)
        {
            _type = type;
            _typeValue = typeValue;
            _nameID = nameID;
        }

        public Token(int type,int typeValue, Point pointLiteral)
        {
            _type = type;
            _typeValue = typeValue;
            _pointLiteral = pointLiteral;
        }
    }
}
