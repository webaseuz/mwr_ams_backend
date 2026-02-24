namespace Bms.WEBASE.Models;

public abstract class SuccessResult
{
    public static SuccessResult<TParam> Create<TParam>(TParam param)
        => new SuccessResult<TParam>(param);

}

public class SuccessResult<TParam>
{
    public SuccessResult(TParam param)
    {
        Success = param;
    }
    public TParam Success { get; set; }
}
