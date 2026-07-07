namespace CSVToJsonConverterAPI.Exceptions
{
    public class FileIsEmptyException : Exception
    {
        public FileIsEmptyException()
        {
        }

        public FileIsEmptyException(string? message) : base(message)
        {
        }

        public FileIsEmptyException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
