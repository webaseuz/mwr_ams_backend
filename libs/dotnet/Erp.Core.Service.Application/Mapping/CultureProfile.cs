using AutoMapper;

namespace Erp.Core.Service.Application;

public class CultureProfile : Profile
{
    protected int CultureId;
    public CultureProfile()
    {
        int cultureId = 1;
        this.CultureId = cultureId;

        // Global DateOnly konverterlar
        CreateMap<DateOnly, DateTime>()
            .ConvertUsing(src => src.ToDateTime(TimeOnly.MinValue));

        CreateMap<DateOnly?, DateTime?>()
            .ConvertUsing((src, dest) => src.HasValue ? src.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null);

    }
}

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Global DateOnly konverterlar
        CreateMap<DateOnly, DateTime>()
            .ConvertUsing(src => src.ToDateTime(TimeOnly.MinValue));

        CreateMap<DateOnly?, DateTime?>()
            .ConvertUsing((src, dest) => src.HasValue ? src.Value.ToDateTime(TimeOnly.MinValue) : (DateTime?)null);
    }
}
