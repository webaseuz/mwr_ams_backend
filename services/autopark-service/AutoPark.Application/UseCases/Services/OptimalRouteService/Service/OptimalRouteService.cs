using AutoPark.Integration.Service.MapService;

namespace AutoPark.Application.UseCases.Services.OptimalRouteService;

public class OptimalRouteService :
    IOptimalRouteService
{
    public async Task<OptimalRouteDto> GetDirectionResponseAsync(OptimalRouteDto dto)
    {
        var res = new OptimalRouteDto();
        res.StartLocation = dto.StartLocation;
        res.EndLocation = dto.EndLocation;

        if (dto.Directions.Count <= 10)
            res.Directions = await Task.Run(() => GetOptimalWithLimitAsync(dto.StartLocation, dto.EndLocation, dto.Directions));
        else
        {
            var result = await Task.Run(() => GetNerarestNeighbourAsync(dto.StartLocation, dto.Directions));
            res.Directions.Add(result);
        }

        return res;
    }

    private List<List<Location>> GetPermutations(List<Location> list, int start)
    {
        if (start == 0)
            list = list.OrderBy(l => l.Longitude).ToList();

        var result = new List<List<Location>>();

        if (start == list.Count - 1)
            result.Add(new List<Location>(list));
        else
            for (int i = start; i < list.Count; i++)
            {
                Swap(list, start, i);
                result.AddRange(GetPermutations(list, start + 1));
                Swap(list, start, i);
            }

        return result;
    }

    private void Swap(List<Location> list, int i, int j)
    {
        var temp = list[i];
        list[i] = list[j];
        list[j] = temp;
    }

    private Task<double> CalculateDistanceAsync(Location start,
                                                Location end)
    {
        if (start.Latitude == 0 || start.Longitude == 0 || end.Latitude == 0 || end.Longitude == 0)
            return Task.FromResult(0.0);

        const double R = 6371; // Yerning radiusi (km)

        double lat1Rad = DegreeToRadian(start.Latitude);
        double lon1Rad = DegreeToRadian(start.Longitude);
        double lat2Rad = DegreeToRadian(end.Latitude);
        double lon2Rad = DegreeToRadian(end.Longitude);

        double deltaLon = lon2Rad - lon1Rad;
        double deltaLat = lat2Rad - lat1Rad;

        double a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                   Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                   Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);

        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        double distance = R * c; // Masofa (km)

        return Task.FromResult(Math.Round(distance, 3));
    }

    private double DegreeToRadian(double gradus)
        => gradus / 180 * Math.PI;


    private async Task<List<Location>> GetOptimalWithLimitAsync(Location start, Location end,
                                                             List<Location> locations)
    {
        var result = GetPermutations(locations, 0);
        var len = double.MaxValue;
        var res = new List<Location>();

        foreach (var permutation in result)
        {
            var current = start;
            double lenichki = 0;

            foreach (var location in permutation)
            {
                lenichki += await CalculateDistanceAsync(current, location);
                current = location;
            }

            lenichki += await CalculateDistanceAsync(current, end);

            if (lenichki <= len)
            {
                len = lenichki;
                res = permutation;
            }
        }

        return res;
    }

    private async Task<Location> GetNerarestNeighbourAsync(Location start,
                                                           List<Location> all)
    {
        var len = double.MaxValue;
        var res = new Location();

        foreach (var loc in all)
        {
            var length = await CalculateDistanceAsync(start, loc);

            if (length < len)
            {
                len = length;
                res = loc;
            }
        }

        return res;
    }
}
