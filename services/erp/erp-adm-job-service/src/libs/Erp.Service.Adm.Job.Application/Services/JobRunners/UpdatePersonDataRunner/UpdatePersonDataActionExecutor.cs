using System.Text.Json;
using Erp.Core;
using Erp.Core.Constants;
using Erp.Core.Service.Application;
using Erp.Core.Service.Domain;
using Erp.Service.Adm.Models;
using Erp.Service.Adm.Sdk;
using Erp.Service.Itg.Proxy.Models;
using Erp.Service.Itg.Proxy.Sdk.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Adm.Job.Application.Services.JobRunners;

public interface IUpdatePersonDataActionExecutor
    : ICustomJobActionExecuter<UpdatePersonDataActionInputData>
{
}

public class UpdatePersonDataActionExecutor : IUpdatePersonDataActionExecutor
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IGcpCitizenApi _gcpCitizenApi;
    private readonly IPersonApi _personApi;

    public UpdatePersonDataActionExecutor(
        IApplicationDbContext dbContext,
        IGcpCitizenApi gcpCitizenApi,
        IPersonApi personApi)
    {
        _dbContext = dbContext;
        _gcpCitizenApi = gcpCitizenApi;
        _personApi = personApi;
    }

    public async Task<CustomJobActionExecuteResult> Execute(
        CustomJob job,
        UpdatePersonDataActionInputData actionInputData)
    {
        var result = new CustomJobActionExecuteResult();

        // STEP 1: Person ma'lumotlari sinxronizatsiya qilish
        var isSynced = await _personApi.PersonSyncAsync(new PersonSyncQuery
        {
            Id = actionInputData.PersonId,
            IncludePhoto = false
        });

        // STEP 2-4: Agar sinxronizatsiya muvaffaqiyatli bo'lsa, GSP dan rasmni olish va MinIO ga yuklash
        if (isSynced)
        {
            bool photoUpdated = false;
            string photoMessage = null;
            // STEP 2: GSP dan fuqaro ma'lumotlarini olish (rasm bilan)
            if (job.IsForceUpdate)
            {
                try
                {
                    var updatePhotoCommand = await _personApi.PersonGetPhotoFromGSPAsync(new PersonGetPhotoFromGSPQuery
                    {
                        Id = actionInputData.PersonId,
                        IsForceUpdate = true
                    });

                    if (!string.IsNullOrWhiteSpace(updatePhotoCommand))
                        photoUpdated = true;

                }
                catch (Exception ex)
                {
                    photoMessage = $"Rasm update qilishda xatolik: {ex.Message}";
                    photoUpdated = false;
                }
            }

            // STEP 5: Success result qaytarish
            result.ReturnData = JsonSerializer.Serialize(new
            {
                PersonId = actionInputData.PersonId,
                Pinfl = actionInputData.Pinfl,
                PhotoUpdated = photoUpdated
            });

            result.UserMessage = photoUpdated
                ? "Ma'lumotlar va rasm muvaffaqiyatli yangilandi"
                : $"Ma'lumotlar yangilandi, lekin rasm yangilanmadi ({photoMessage})";
            result.FromCache = false;
        }
        else
        {
            result.UserMessage = "Person ma'lumotlarini sinxronizatsiya qilishda xatolik";
            result.FromCache = false;
        }

        return result;

    }
}
