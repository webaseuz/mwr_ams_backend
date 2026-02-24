using Bms.WEBASE.DependencyInjection;
using Bms.WEBASE.EF;
using Bms.WEBASE.Models;
using Bms.WEBASE.Storage;
using Microsoft.EntityFrameworkCore;
using WEBASE.Security.Abstraction;

namespace Bms.WEBASE.MinioSdk;

public static class FileEntityExtension
{
    public static void AddFromTempFiles<TFileEntity>(this ICollection<TFileEntity> filesNavigationProperty,
                                                               string document,
                                                               List<Guid> tempFileIds,
                                                               Action<TFileEntity> onAddEntity = null!)
        where TFileEntity : IFileEntity
    {

        IStorageAsyncService storageService = BaseAsyncServiceProvider<IBaseAuthService>.StorageService;

        IStorageFileInfo[] tempFileInfos = storageService.GetTempFileInfos(document,
                                                                           tempFileIds.ToArray());



        IStorageFileInfo[] array = tempFileInfos;

        foreach (IStorageFileInfo storageFileInfo in array)
        {
            TFileEntity val = Activator.CreateInstance<TFileEntity>();

            ref TFileEntity reference = ref val;

            TFileEntity val2 = default(TFileEntity)!;

            if (val2 == null)
            {
                val2 = reference;
                reference = ref val2;
            }

            reference.Id = storageFileInfo.FileId;

            ref TFileEntity reference2 = ref val;

            val2 = default(TFileEntity)!;

            if (val2 == null)
            {
                val2 = reference2;
                reference2 = ref val2;
            }

            reference2.FileName = storageFileInfo.FileName;

            ref TFileEntity reference3 = ref val;

            val2 = default(TFileEntity)!;

            if (val2 == null)
            {
                val2 = reference3;
                reference3 = ref val2;
            }

            onAddEntity?.Invoke(val);

            filesNavigationProperty.Add(val);
        }

    }

    public static void UpdateFromFiles<TFileEntity>(this ICollection<TFileEntity> filesNavigationProperty,
                                                              string document,
                                                              string documentId,
                                                              List<Guid> files,
                                                              IDbContext context,
                                                              Action<TFileEntity> onAddEntity = null!)
        where TFileEntity : IFileEntity
    {
        var oldFilesNavigationProperty = filesNavigationProperty.ToList();


        IStorageAsyncService storageService = BaseAsyncServiceProvider<IBaseAuthService>.StorageService;

        List<Guid> list = files.ToList();

        List<TFileEntity> list2 = new List<TFileEntity>();

        foreach (TFileEntity item in filesNavigationProperty)
        {
            if (list.Contains(item.Id))
                list.Remove(item.Id);
            else
                list2.Add(item);
        }

        foreach (TFileEntity item2 in list2)
        {
            filesNavigationProperty.Remove(item2);
            storageService.MarkFileForDelete(document, documentId, item2.Id);
        }

        filesNavigationProperty.AddFromTempFiles(document, list, onAddEntity);
        foreach (var singleItem in filesNavigationProperty)
        {
            var val = oldFilesNavigationProperty.FirstOrDefault(ef => ef.Id == singleItem.Id);

            if (val == null)
                context.Entry(singleItem).State = EntityState.Added;
            else
                context.Entry(singleItem).State = EntityState.Modified;
        }

        foreach (var singleItem in oldFilesNavigationProperty.Where(a => !files.Contains(a.Id)))
            context.Entry(singleItem).State = EntityState.Deleted;

        storageService.MarkFileForMoveToPersistent(document, documentId, list.ToArray());
    }
}
