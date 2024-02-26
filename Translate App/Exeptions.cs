using System;
namespace Translate_App
{
    // Custom exception class for handling language requirement exceptions
    internal class LangReqExption: ApplicationException
    {
        private string _msg;
        public LangReqExption()
        {
            _msg = "Enter The Language Correctly!";
        }
        // Override the Message property to provide custom error message
        public override string Message
        {
            get { return $"{_msg}"; }
        }
    }

    // Custom exception class for handling null argument exceptions
    internal class ArgumentNullException : ApplicationException
    {
        private string _msg;

        public ArgumentNullException()
        {
            _msg = "The Chosen Languages Are The Same.";
        }
        // Override the Message property to provide custom error message
        public override string Message
        {
            get { return $"{_msg}"; }
        }
    }
}


