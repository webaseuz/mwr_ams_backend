using AutoPark.Integration.Models;
using AutoPark.Integration.Models.Yhxbb.VehicleInfo;
using Microsoft.Extensions.Options;

namespace AutoPark.Integration.Service;

public class YhxbbIntegrationService : IYhxbbIntegrationService
{
    private readonly YhxbbHttpClient _client;
    private readonly AutoParkHttpConfig _config;

    public YhxbbIntegrationService(
        YhxbbHttpClient client,
        AutoParkHttpConfig config)
    {
        _client = client;
        _config = config;
    }

    #region DRIVER LICENSE

    public async Task<DriverLicenseResponse> GetDriverLicenseInfoAsync(DriverLicenseRequest req)
    {
        if (_config.UseStub)
            return CreateDriverLicenseStub(req);

        return await _client.PostAsync<DriverLicenseRequest, DriverLicenseResponse>(
            _config.DriverLicenseApi, req);
    }

    #endregion

    #region VEHICLE LICENSE

    public async Task<VehicleLicenseResponse> GetVehicleLicenseInfoAsync(VehicleLicenseRequest req)
    {
        if (_config.UseStub)
            return CreateVehicleLicenseStub(req);

        return await _client.PostAsync<VehicleLicenseRequest, VehicleLicenseResponse>(
            _config.VehicleLicenseApi, req);
    }

    #endregion

    #region VEHICLE SEARCH

    public async Task<VehicleInfoResponse> SearchVehicleByPlateNumberAsync(VehicleSearchByPlateNumber req)
    {
        if (_config.UseStub)
            return CreateVehicleInfoStub(plate: req.PlateNumber);

        return await _client.PostAsync<VehicleSearchByPlateNumber, VehicleInfoResponse>(
            _config.VehicleInfoApi + "search-by-plate-number", req);
    }

    public async Task<VehicleInfoResponse> SearchVehicleByPnflAsync(VehicleSearchByPinfl req)
    {
        if (_config.UseStub)
            return CreateVehicleInfoStub(pinfl: req.Pinfl);

        return await _client.PostAsync<VehicleSearchByPinfl, VehicleInfoResponse>(
            _config.VehicleInfoApi + "search-by-pnfl", req);
    }

    public async Task<VehicleInfoResponse> SearchVehicleByTinAsync(VehicleSearchByTin req)
    {
        if (_config.UseStub)
            return CreateVehicleInfoStub(tin: req.Tin);

        return await _client.PostAsync<VehicleSearchByTin, VehicleInfoResponse>(
            _config.VehicleInfoApi + "search-by-tin", req);
    }

    #endregion

    #region STUB GENERATORS

    private DriverLicenseResponse CreateDriverLicenseStub(DriverLicenseRequest req)
    {
        var hash = Hash(req.ApplicantPinfl ?? req.PassportNumber);

        return new DriverLicenseResponse
        {
            Result = 1,
            Comment = "OK (STUB)",
            Pinfl = req.ApplicantPinfl,
            DriverDocument = $"{req.PassportSeries}{req.PassportNumber}",
            DriverFullName = $"TEST DRIVER {hash}",
            DriverBirthOn = new DateTime(1970 + hash % 25, 1, 1),
            DocumentStartDate = DateTime.UtcNow.AddYears(-5),
            DocumentEndDate = DateTime.UtcNow.AddYears(5),
            DocumentInfo = new DriverLicenseDocumentModel
            {
                BeginDate = DateTime.UtcNow.AddYears(-5),
                EndDate = DateTime.UtcNow.AddYears(5),
                SerialNumber = $"AA{hash}"
            },
            BirthPlace = CreatePlaceStub(hash),
            Address = CreatePlaceStub(hash + 1),
            Categorys = new List<DriverCategoryModel>
            {
                new DriverCategoryModel
                {
                    Category = "B",
                    BeginDate = "01.01.2015",
                    EndDate = "01.01.2035"
                }
            }
        };
    }

    private VehicleLicenseResponse CreateVehicleLicenseStub(VehicleLicenseRequest req)
    {
        var hash = Hash(req.PlateNumber);

        return new VehicleLicenseResponse
        {
            Result = 1,
            Comment = "OK (STUB)",
            Pinfl = $"3{hash}000000000",
            OwnerName = $"OWNER {hash}",
            OwnerType = 0,
            Vehicles = new List<VehicleInfoModel>
            {
                CreateVehicleStub(req.PlateNumber, hash)
            }
        };
    }

    private VehicleInfoResponse CreateVehicleInfoStub(
        string plate = null,
        string pinfl = null,
        string tin = null)
    {
        var key = plate ?? pinfl ?? tin;
        var hash = Hash(key);

        return new VehicleInfoResponse
        {
            Result = 1,
            Comment = "OK (STUB)",
            Pinfl = pinfl ?? $"3{hash}000000000",
            OwnerName = $"OWNER {hash}",
            OwnerType = tin == null ? 0 : 1,
            OrganizationInn = tin,
            Vehicles = new List<VehicleInfoModel>
            {
                CreateVehicleStub(plate ?? $"01A{hash}", hash)
            }
        };
    }

    private VehicleInfoModel CreateVehicleStub(string plate, int hash)
    {
        return new VehicleInfoModel
        {
            VehicleId = hash,
            TechPassportSeries = "AAF",
            TechPassportNumber = hash.ToString(),
            PlateNumber = plate,
            Model = hash % 2 == 0 ? "COBALT" : "NEXIA",
            VehicleColor = hash % 2 == 0 ? "WHITE" : "BLACK",
            RegistrationDate = new DateTime(2010 + hash % 14, 1, 1),
            Year = 2010 + hash % 14,
            VehicleTypeId = 2,
            KuzovNumber = $"KUZOV-{hash}",
            MotorNumber = $"MOTOR-{hash}",
            FuelTypeId = 4,
            Seats = 5,
            Power = 90 + hash % 40
        };
    }

    private DriverPlaceModel CreatePlaceStub(int hash)
    {
        return new DriverPlaceModel
        {
            RegionId = 1700 + hash % 10,
            CityId = 1700000 + hash,
            Place = $"TEST PLACE {hash}"
        };
    }

    private int Hash(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Random.Shared.Next(100_000, 999_999);

        unchecked
        {
            int hash = 23;
            foreach (var c in value)
                hash = hash * 31 + c;
            return Math.Abs(hash % 900_000) + 100_000;
        }
    }

    #endregion
}
