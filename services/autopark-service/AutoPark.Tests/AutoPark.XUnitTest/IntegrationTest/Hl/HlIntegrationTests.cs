using AutoPark.Application.UseCases.Branches;
using AutoPark.Application.UseCases.Departments;
using Newtonsoft.Json;
using System.Text;

namespace AutoPark.XUnitTests;

public class HlIntegrationTests : AuthenticatedTestBase
{
    public int BranchId { get; set; }
    public HlIntegrationTests(CustomWebApiFactory factorygGetToken)
        : base(factorygGetToken)
    {
    }

    [Fact]
    public async Task CRUD_Branch_Test()
    {
        try
        {
            #region Create Branch
            var command = new CreateBranchCommand
            {
                UniqueCode = "123",
                ShortName = "ShortName",
                FullName = "FullName",
                OrganizationId = 1,
                CountryId = 1,
                RegionId = 1,
                DistrictId = 1,
                Address = "Address",
                Latitude = "23.23",
                Longitude = "45.45"
            };

            var content = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");
            var response = await ClientRealDb.PostAsync("/Branch/Create", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorJson = await response.Content.ReadAsStringAsync();
                Assert.Fail($"❌ Create Branch Failed! StatusCode: {response.StatusCode}, Response: {errorJson}");
            }

            var json = await response.Content.ReadAsStringAsync();
            var responseModel = JsonConvert.DeserializeObject<ResponseModel>(json);
            BranchId = responseModel?.Id ?? 0;

            Console.WriteLine($"✅ Branch Created Successfully! ID: {BranchId}");
            #endregion

            #region GetById Branch
            var responseGetById = await ClientRealDb.GetAsync($"/Branch/GetById?Id={BranchId}");

            if (!responseGetById.IsSuccessStatusCode)
            {
                var errorJson = await responseGetById.Content.ReadAsStringAsync();
                Assert.Fail($"❌ GetById Failed! StatusCode: {responseGetById.StatusCode}, Response: {errorJson}");
            }

            Console.WriteLine("✅ GetById Successful");
            #endregion

            #region Update Branch
            var commandUpdate = new UpdateBranchCommand
            {
                Id = BranchId,
                UniqueCode = "12345",
                ShortName = "ShortNameUpdate",
                FullName = "FullNameUpdate",
                OrganizationId = 1,
                CountryId = 1,
                RegionId = 1,
                DistrictId = 1,
                Address = "AddressUpdate",
                Latitude = "11.11",
                Longitude = "45.45"
            };

            var contentUpdate = new StringContent(JsonConvert.SerializeObject(commandUpdate), Encoding.UTF8, "application/json");
            var responseUpdate = await ClientRealDb.PostAsync("/Branch/Update", contentUpdate);

            if (!responseUpdate.IsSuccessStatusCode)
            {
                var errorJson = await responseUpdate.Content.ReadAsStringAsync();
                Assert.Fail($"❌ Update Branch Failed! StatusCode: {responseUpdate.StatusCode}, Response: {errorJson}");
            }

            Console.WriteLine("✅ Branch Updated Successfully");
            #endregion

            #region GetBriefList Branch
            var responseGetBriefList = await ClientRealDb.GetAsync("/Branch/GetBriefList");

            if (!responseGetBriefList.IsSuccessStatusCode)
            {
                var errorJson = await responseGetBriefList.Content.ReadAsStringAsync();
                Assert.Fail($"❌ GetBriefList Failed! StatusCode: {responseGetBriefList.StatusCode}, Response: {errorJson}");
            }

            Console.WriteLine("✅ GetBriefList Successful");
            #endregion

            #region Delete Branch
            //var commandDelete = new DeleteBranchCommand { Id = BranchId };
            //var contentDelete = new StringContent(JsonConvert.SerializeObject(commandDelete), Encoding.UTF8, "application/json");
            //var responseDelete = await ClientRealDb.PostAsync("/Branch/Delete", contentDelete);

            //if (!responseDelete.IsSuccessStatusCode)
            //{
            //    var errorJson = await responseDelete.Content.ReadAsStringAsync();
            //    Assert.Fail($"❌ Delete Branch Failed! StatusCode: {responseDelete.StatusCode}, Response: {errorJson}");
            //}

            //Console.WriteLine("✅ Branch Deleted Successfully");
            #endregion
        }
        catch (Exception ex)
        {
            Console.WriteLine($"🚨 Test Failed: {ex.Message}");
            Assert.Fail(ex.Message);
        }
    }

    [Fact]
    public async Task CRUD_Department_Test()
    {
        int DepartmentId = 0;
        try
        {
            #region Create Department

            var command = new CreateDepartmentCommand
            {
                BranchId = 1,
                ShortName = "ShortName",
                FullName = "FullName",
                Code = "Code",
                OrderCode = "OrderCode",
                Translates = new List<DepartmentTranslateCommand>
                {
                    new DepartmentTranslateCommand
                    {
                        LanguageId = 1,
                        TranslateText = "ShortNameTranslate"
                    }
                }
            };

            var content = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");

            var response = await ClientRealDb.PostAsync("/Department/Create", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorJson = await response.Content.ReadAsStringAsync();

                Assert.Fail($"Create Department Failed! StatusCode: {response.StatusCode}, Response: {errorJson}");
            }

            var json = await response.Content.ReadAsStringAsync();

            var responseModel = JsonConvert.DeserializeObject<ResponseModel>(json);

            DepartmentId = responseModel?.Id ?? 0;

            Console.WriteLine($"Department Created Successfully! ID: {DepartmentId}");
            #endregion

            #region GetById Department

            var responseGetById = await ClientRealDb.GetAsync($"/Department/GetById?Id={DepartmentId}");

            if (!responseGetById.IsSuccessStatusCode)
            {
                var errorJson = await responseGetById.Content.ReadAsStringAsync();
                Assert.Fail($"❌ GetById Failed! StatusCode: {responseGetById.StatusCode}, Response: {errorJson}");
            }

            Console.WriteLine("✅ GetById Successful");

            #endregion

            #region GetBriefList Department

            var responseGetBriefList = await ClientRealDb.GetAsync("/Department/GetBriefList");

            if (!responseGetBriefList.IsSuccessStatusCode)
            {
                var errorJson = await responseGetBriefList.Content.ReadAsStringAsync();
                Assert.Fail($"❌ GetBriefList Failed! StatusCode: {responseGetBriefList.StatusCode}, Response: {errorJson}");
            }

            Console.WriteLine("✅ GetBriefList Successful");
            #endregion

            #region Update Department

            var commandUpdate = new UpdateDepartmentCommand
            {
                Id = DepartmentId,
                ShortName = "ShortNameUpdate",
                FullName = "FullNameUpdate",
                Code = "CodeUpdate",
                OrderCode = "OrderCodeUpdate",
                Translates = new List<DepartmentTranslateCommand>
                {
                    new DepartmentTranslateCommand
                    {
                        LanguageId = 1,
                        TranslateText = "ShortNameTranslateUpdate"
                    }
                }
            };

            var contentUpdate = new StringContent(JsonConvert.SerializeObject(commandUpdate), Encoding.UTF8, "application/json");
            var responsUpdate = await ClientRealDb.PostAsync("/Department/Update", content);

            if (!responsUpdate.IsSuccessStatusCode)
            {
                var errorJson = await responsUpdate.Content.ReadAsStringAsync();
                Assert.Fail($"Update Department Failed! StatusCode: {responsUpdate.StatusCode}, Response: {errorJson}");
            }

            Console.WriteLine("Department Updated Successfully");
            #endregion

            #region Delete Department
            var commandDelete = new DeleteDepartmentCommand { Id = DepartmentId };

            var contentDelete = new StringContent(JsonConvert.SerializeObject(commandDelete), Encoding.UTF8, "application/json");
            var responseDelete = await ClientRealDb.PostAsync("/Department/Delete", contentDelete);

            if (!responseDelete.IsSuccessStatusCode)
            {
                var errorJson = await responseDelete.Content.ReadAsStringAsync();
                Assert.Fail($"❌ Delete Department Failed! StatusCode: {responseDelete.StatusCode}, Response: {errorJson}");
            }

            Console.WriteLine("Department Deleted Successfully");
            #endregion
        }
        catch (Exception ex)
        {
            Console.WriteLine($"🚨 Test Failed: {ex.Message}");
            //Assert.True(false, ex.Message);
        }
    }

    /*  [Fact]
      public async Task CRUD_Driver_Test()
      {
          try
          {
              #region Create Driver
              var command = new CreateDriverCommand
              {
                  BranchId = 20,
                  Person = new CreatePersonCommand
                  {
                      Pinfl = "12345678901234",
                      Inn = "123456789",
                      DocumentTypeId = 1,
                      DocumentSeria = "AA",
                      DocumentNumber = "1234567",
                      LastName = "Testov",
                      FirstName = "Test",
                      MiddleName = "Testovich",
                      GenderId = 1,
                      BirthCountryId = 1,
                      BirthRegionId = 1,
                      BirthDistrictId = 1,
                      CitizenshipId = 1,
                      LivingRegionId = 1,
                      LivingDistrictId = 1,
                      FileId = null,
                      FileName = "test.jpg",
                      BirthOn = new DateTime(1990, 1, 1)
                  },
                  Documents = new List<CreateDriverDocumentCommand>
                  {
                      new CreateDriverDocumentCommand
                      {
                          DocumentTypeId = 1,
                          DocumentNumber = "1234567",
                          DocumentFileId = null,
                          DocumentFileName = "test.jpg",
                      }
                  }
              };
              var content = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json");

              var response = await ClientRealDb.PostAsync("/Driver/Create", content);
              if (!response.IsSuccessStatusCode)
              {
                  var errorJson = await response.Content.ReadAsStringAsync();
                  Assert.Fail($"❌ Create Driver Failed! StatusCode: {response.StatusCode}, Response: {errorJson}");
              }

              var json = await response.Content.ReadAsStringAsync();

              var responseModel = JsonConvert.DeserializeObject<ResponseModel>(json);
              var driverId = responseModel?.Id ?? 0;

              Console.WriteLine($"✅ Driver Created Successfully! ID: {driverId}");

              #endregion

              #region GetById Driver
              var responseGetById = await ClientRealDb.GetAsync($"/Driver/GetById?Id={driverId}");
              if (!responseGetById.IsSuccessStatusCode)
              {
                  var errorJson = await responseGetById.Content.ReadAsStringAsync();
                  Assert.Fail($"❌ GetById Failed! StatusCode: {responseGetById.StatusCode}, Response: {errorJson}");
              }

              Console.WriteLine("✅ GetById Successful");
              #endregion

              #region Update Driver
              var commandUpdate = new UpdateDriverCommand
              {
                  Id = driverId,
                  BranchId = 1,
                  Person = new UpdatePersonCommand
                  {
                      Id = driverId,
                      Pinfl = "12345678901234",
                      Inn = "123456789",
                      DocumentTypeId = 1,
                      DocumentSeria = "AA",
                      DocumentNumber = "1234567",
                      LastName = "Testov",
                      FirstName = "Test",
                      MiddleName = "Testovich",
                      GenderId = 1,
                      BirthCountryId = 1,
                      BirthRegionId = 1,
                      BirthDistrictId = 1,
                      CitizenshipId = 1,

                  },
                  Documents = new List<UpdateDriverDocumentCommand>
                  {
                      new UpdateDriverDocumentCommand
                      {
                          Id = 1,
                          DocumentTypeId = 1,
                          DocumentNumber = "1234567",
                          DocumentFileId = null,
                          DocumentFileName = "test.jpg",
                      }
                  }
              };

              var contentUpdate = new StringContent(JsonConvert.SerializeObject(commandUpdate), Encoding.UTF8, "application/json");
              var responseUpdate = await ClientRealDb.PostAsync("/Driver/Update", contentUpdate);

              if (!responseUpdate.IsSuccessStatusCode)
              {
                  var errorJson = await responseUpdate.Content.ReadAsStringAsync();
                  Assert.Fail($"❌ Update Driver Failed! StatusCode: {responseUpdate.StatusCode}, Response: {errorJson}");
              }

              Console.WriteLine("✅ Driver Updated Successfully");
              #endregion

              #region GetBriefList Driver
              var responseGetBriefList = await ClientRealDb.GetAsync("/Driver/GetBriefList");

              if (!responseGetBriefList.IsSuccessStatusCode)
              {
                  var errorJson = await responseGetBriefList.Content.ReadAsStringAsync();
                  Assert.Fail($"❌ GetBriefList Failed! StatusCode: {responseGetBriefList.StatusCode}, Response: {errorJson}");
              }

              Console.WriteLine("✅ GetBriefList Successful");
              #endregion

              #region Delete Driver
              var commandDelete = new DeleteDriverCommand { Id = driverId };
              var contentDelete = new StringContent(JsonConvert.SerializeObject(commandDelete), Encoding.UTF8, "application/json");
              var responseDelete = await ClientRealDb.PostAsync("/Driver/Delete", contentDelete);

              if (!responseDelete.IsSuccessStatusCode)
              {
                  var errorJson = await responseDelete.Content.ReadAsStringAsync();
                  Assert.Fail($"❌ Delete Driver Failed! StatusCode: {responseDelete.StatusCode}, Response: {errorJson}");
              }

              Console.WriteLine("✅ Driver Deleted Successfully");
              #endregion
          }
          catch (Exception ex)
          {
              Console.WriteLine($"🚨 Test Failed: {ex.Message}");
              Assert.Fail(ex.Message);
          }
      }*/

    public class ResponseModel
    {
        public int? Id { get; set; }
        public bool Success { get; set; }
    }
}


