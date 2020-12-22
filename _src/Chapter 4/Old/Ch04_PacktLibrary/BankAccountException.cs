using System;
namespace Packt.LearningCS
{
    public class BankAccountException : Exception
    {
        public BankAccountException() { }
        public BankAccountException(string message) { }
        public BankAccountException(string message, Exception innerException) { }
    }
}
