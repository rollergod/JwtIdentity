namespace JwtIdentity.Domain.Common.Contracts.Response;

public class Response<T>
{
    public bool Succeeded { get; protected set; }
    public T Data { get; protected set; }
    public string Message { get; protected set; }
    public List<string> Errors { get; set; }

    public Response()
    { }

    public Response(string message)
    {
        Succeeded = false;
        message = Message;
    }

    public Response(T data, string message)
    {
        Succeeded = true;
        Message = message;
        Data = data;
    }

    public static Response<T> Success()
    {
        return new Response<T> { Succeeded = true };
    }

    public static Response<T> Success(string message)
    {
        return new Response<T> { Succeeded = true, Message = message };
    }

    public static Response<T> Success(T data, string message)
    {
        return new Response<T> { Data = data, Succeeded = true, Message = message };
    }

    public static Response<T> Fail()
    {
        return new Response<T> { Succeeded = false };
    }
    public static Response<T> Fail(string message)
    {
        return new Response<T> { Succeeded = false, Message = message };
    }

    public static Response<T> Fail(List<string> errors, string message)
    {
        return new Response<T> { Errors = errors, Succeeded = false, Message = message };
    }

    public static Response<T> Fail(List<string> errors)
    {
        return new Response<T> { Succeeded = false, Errors = errors };
    }

    public override string ToString()
    {
        return Succeeded ?
            Message :
            Errors == null || Errors.Count == 0 ? Message : $"{Message} : {string.Join(",", Errors)}";
    }
}