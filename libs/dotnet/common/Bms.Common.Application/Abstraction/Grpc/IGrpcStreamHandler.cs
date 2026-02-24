namespace WEBASE.Extension.Abstraction;

public interface IGrpcStreamHandler<TRequest, TResponse>
{
    IAsyncEnumerable<TResponse> Handle(TRequest request);
}
