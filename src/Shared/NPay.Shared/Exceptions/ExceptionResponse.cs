using System.Net;

namespace NPay.Shared.Exceptions
{
    public sealed record ExceptionResponse(object Response, HttpStatusCode StatusCode);
}