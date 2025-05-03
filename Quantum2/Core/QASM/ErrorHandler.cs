using System.Collections.Generic;

namespace Quantum2.Core.QASM
{
    public class ErrorHandler
    {
        private List<Error> _errors;

        public List<Error> Errors
        {
            get
            {
                return _errors;
            }
        }

        public ErrorHandler()
        {
            _errors = new List<Error>();
        }

        public void AddError(Error error)
        {
            _errors.Add(error);
        }

        public void AddError(TError typeError, string description)
        {
            _errors.Add(new Error(typeError, description));
        }
    }
}
