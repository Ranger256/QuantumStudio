namespace Quantum2.Core.QASM
{
    public class Error
    {
        private TError _type;
        private string _description;

        public TError Type
        {
            get
            {
                return _type;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
        }

        public Error(TError type,string description)
        {
            _type = type;
            _description = description;
        }
    }

    public enum TError
    {
        lexical_error_incorrect_placement_of_a_language_directive_character,
        lexical_error_incorrect_placement_of_a_preprocessor_directive_character,
        lexical_error_incorrect_definition_of_a_preprocessor_directive,
        lexical_error_incorrect_definition_of_a_language_directive
    }
}
