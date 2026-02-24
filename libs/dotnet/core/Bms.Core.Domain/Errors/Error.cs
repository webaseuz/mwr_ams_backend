namespace Bms.Core.Domain;

public class Error
{
    public ErrorType Type { get; set; }
    public ErrorLevel Level { get; set; }
    public ushort Code { get; set; }
    public string CodeName { get; set; } = string.Empty;
    public string ExceptionName { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public string TraceId { get; set; }

    public void ParseFrom(BaseException ex,
                          string traceId)
    {
        Type = ErrorParser.GetErrorType(ex.Code);
        Level = ErrorParser.GetErrorLevel(ex.Code);
        Code = (ushort)ex.Code;
        CodeName = ex.Code.ToString();

        Message = ex.Message;
        TraceId = traceId;

        if (ex is ClientException clEx)
            ExceptionName = nameof(ClientException);


        if (ex is ServerException serEx)
            ExceptionName = nameof(ServerException);
    }

    public void ParseUnknownFrom(Exception ex,
                                 string traceId,
                                 string exName)
    {
        Type = ErrorType.SERVER;
        Level = ErrorLevel.CRITICAL;
        Message = ex.Message;
        TraceId = traceId;
        ExceptionName = exName;
    }

}
