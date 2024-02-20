using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Exceptions.Types;
public class AydincException:Exception
{
    public IEnumerable<AydincExceptionModel> Errors { get; }

    public AydincException()
    {
        Errors = Array.Empty<AydincExceptionModel>();
    }
    public AydincException(string message):base(message)
    {
        Errors = Array.Empty<AydincExceptionModel>();
    }
    public AydincException(string message,Exception? innerException) : base(message,innerException)
    {
        Errors = Array.Empty<AydincExceptionModel>();
    }
    public AydincException(IEnumerable<AydincExceptionModel> errors)
        : base(BuildErrorMessage(errors))
    {
        Errors = errors;
    }
    protected AydincException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
    private static string BuildErrorMessage(IEnumerable<AydincExceptionModel> errors)
    {
        IEnumerable<string> arr = errors.Select(x =>
            $"{Environment.NewLine} -- {x.Property}: {string.Join(Environment.NewLine, values: x.Errors ?? Array.Empty<string>())}"
        );
        return $"Validation failed: {string.Join(string.Empty, arr)}";
    }
}

public class AydincExceptionModel
{
    public string? Property { get; set; }
    public IEnumerable<string>? Errors { get; set; }
}
