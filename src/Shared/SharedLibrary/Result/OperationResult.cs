namespace SharedLibrary.Result;

public class OperationResult<T>
{
    public T Data { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }
    public OperationResult(T data)
    {
        IsSuccess = true;
        Data = data;
    }
    public OperationResult(string message, bool isSuccess = true)
    {
        IsSuccess = isSuccess;
        Message = message;
    }
    public OperationResult(List<string> errors)
    {
        IsSuccess = false;
        Errors = errors;
    }

}
