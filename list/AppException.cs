using System;

namespace list
{
    public class AppException : Exception
    {
        private string message { get; }

        public AppException(string message)
        {
            this.message = message;
        }

        public AppException()
        {
            this.message = "Неизвестная ошибка";
        }
    }
}