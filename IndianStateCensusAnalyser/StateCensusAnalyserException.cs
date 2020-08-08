using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public class StateCensusAnalyserException : Exception
    {
        public enum ExceptionType
        {
            NO_SUCH_FILE,
            NO_SUCH_FILE_TYPE,
            NO_SUCH_DELIMITER
        }

        public ExceptionType type;

        public StateCensusAnalyserException(String message, ExceptionType type) : base(message)
        {
            this.type = type;
        }
    }
}
