
namespace Quantum2.Core.QASM
{
    public class ID
    {
        private int _type;

        private object _value;

        private bool _isConst;

        private bool _isCC;

        public int Type
        {
            get
            {
                return _type;
            }
        }

        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public bool IsConst
        {
            get
            {
                return _isConst;
            }
            set
            {
                _isConst = value;
            }
        }

        public bool IsCC
        {
            get
            {
                return _isCC;
            }
        }

        public ID(int type, bool isCC = false)
        {
            _type = type;

            _value = null;

            _isCC = isCC;
        }
    }
}
