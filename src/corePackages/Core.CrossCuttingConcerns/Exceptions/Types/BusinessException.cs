using System.Runtime.Serialization;

namespace Core.CrossCuttingConcerns.Exceptions.Types;

public class BusinessException : Exception
{
    public string DetailedMessage { get;}
    public BusinessException() { }

    protected BusinessException(SerializationInfo info, StreamingContext context)
        : base(info, context) {}

    public BusinessException(string? message)
        : base(message) {}

    public BusinessException(string? message, Exception? innerException)
        : base(message, innerException) {}
}
