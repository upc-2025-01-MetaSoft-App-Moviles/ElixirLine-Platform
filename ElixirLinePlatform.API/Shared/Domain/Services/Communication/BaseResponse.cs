namespace ElixirLinePlatform.API.Shared.Domain.Services.Communication;

public abstract class BaseResponse<T>
{
    protected BaseResponse(T resource)
    {
        Success = true;
        Resource = resource;
        Message = string.Empty;
    }

    protected BaseResponse(string message)
    {
        Success = false;
        Message = message;
        Resource = default;
    }

    public bool Success { get; private set; }
    public string Message { get; private set; }
    public T? Resource { get; private set; }
}