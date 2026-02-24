using Bms.Core.Domain;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Domain;
using ServiceDesk.Domain.Constants;

namespace ServiceDesk.Application.UseCases.Services.SpareTurnoverServices;

public class SpareTurnoverService :
    ISpareTurnoverService
{
    private readonly IWriteEfCoreContext _context;

    public SpareTurnoverService(IWriteEfCoreContext context)
    {
        _context = context;
    }

    public async Task InsertSpareTurnoverRow(SpareTurnoverParameter parameters,
                                             CancellationToken cancellationToken)
    {
        bool canCommit = _context.Database.CurrentTransaction == null;
        var transaction = canCommit ? await _context.Database.BeginTransactionAsync(cancellationToken)
                                    : _context.Database.CurrentTransaction;

        try
        {
            switch (parameters.MovementTypeId)
            {
                case MovementTypeIdConst.INCOME:
                    await UpsertSpareTurnoverAsync(
                        // In constructor there is validation so this won't be null at all
                        branchId: parameters.ToBranchId.Value,
                        parameters: parameters,
                        cancellationToken: cancellationToken,
                        checkQuantity: false);
                    break;

                case MovementTypeIdConst.OUTCOME:
                    await UpsertSpareTurnoverAsync(
                        branchId: parameters.FromBranchId.Value,
                        parameters: parameters,
                        cancellationToken: cancellationToken,
                        checkQuantity: true);
                    break;

                case MovementTypeIdConst.MOVEMENT:
                    // Handle outcome part for movement
                    await UpsertSpareTurnoverAsync(
                        branchId: parameters.FromBranchId.Value,
                        parameters: parameters,
                        cancellationToken: cancellationToken,
                        checkQuantity: true);

                    // Handle income part for movement
                    await UpsertSpareTurnoverAsync(
                        branchId: parameters.ToBranchId.Value,
                        parameters: parameters,
                        cancellationToken: cancellationToken,
                        checkQuantity: false);

                    break;

                default:
                    throw new Exception($"Invalid {nameof(parameters.MovementTypeId)} in  {nameof(SpareTurnoverService)} -> {nameof(InsertSpareTurnoverRow)}");
            }

            await _context.SaveChangesAsync(cancellationToken);

            if (canCommit)
                await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception)
        {
            if (canCommit)
                await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }

    private async Task UpsertSpareTurnoverAsync(
        int branchId,
        SpareTurnoverParameter parameters,
        CancellationToken cancellationToken,
        bool checkQuantity)
    {
        var presentItems = parameters.ConvertToItemList();

        foreach (var parameter in presentItems)
        {
            var presentRow = await _context.PresentSpareTurnovers
                .Include(p => p.DeviceSpareType)
                .FirstOrDefaultAsync(p => !p.IsDeleted &&
                                           p.BranchId == branchId &&
                                           p.DeviceSpareTypeId == parameter.DeviceSpareTypeId
                                   , cancellationToken);

            if (presentRow == null)
            {
                if (!parameters.IsDebit)
                    throw ClientLogicalExceptionHelper.NotEnaughQuantity(presentRow.DeviceSpareType?.FullName,
                                                                         $"{parameter.Quantity}");

                var entity = PresentSpareTurnover.CreatePresentSpareTurnoverEntity(parameter);

                await _context.AddAsync(entity, cancellationToken);
            }
            else
            {
                if (!parameters.IsDebit && parameter.Quantity > presentRow.Quantity)
                    throw ClientLogicalExceptionHelper.NotEnaughQuantity(presentRow.DeviceSpareType?.FullName,
                                                                         $"{parameter.Quantity}");

                var entry = _context.Entry(presentRow);

                await entry.Collection(e => e.SpareTurnovers)
                    .LoadAsync(cancellationToken);

                presentRow.UpdatePresentSpareTurnoverEntity(parameter);

                #region New Spare Turnover Row create logic
                var newSpareTurnoverRow = SpareTurnover.AddSpareTurnover(parameter);

                newSpareTurnoverRow.PresentSpareTurnoverId = presentRow.Id;

                await _context.AddAsync(newSpareTurnoverRow, cancellationToken);
                #endregion
            }
        }
    }

    public async Task RemoveSpareTurnoverRow(RemoveSpareTurnoverRowDto dto,
                                             CancellationToken cancellationToken)
    {
        bool canCommit = _context.Database.CurrentTransaction == null;
        var transaction = canCommit ? await _context.Database.BeginTransactionAsync(cancellationToken)
                                    : _context.Database.CurrentTransaction;
        try
        {
            var spareTurnovers = _context.SpareTurnovers
                .Include(st => st.PresentSpareTurnover)
                .Include(st => st.DeviceSpareType)
                .Where(st => !st.IsDeleted &&
                              st.TableId == dto.TableId &&
                              st.DocumentId == dto.DocumentId)
                .ToArray();

            if (!spareTurnovers.Any())
            {
                if (canCommit)
                    await transaction.RollbackAsync(cancellationToken);

                return;
            }

            foreach (var spareTurnover in spareTurnovers)
            {
                var deleteResult = spareTurnover.MarkAsIsDeleted();

                if (deleteResult < 0)
                {
                    if (canCommit)
                        await transaction.RollbackAsync(cancellationToken);

                    throw ClientLogicalExceptionHelper.NotEnaughQuantity(spareTurnover.DeviceSpareType?.FullName,
                                                                         spareTurnover.Quantity.ToString());
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            if (canCommit)
                await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception)
        {
            if (canCommit)
                await transaction.RollbackAsync(cancellationToken);

            throw;
        }
    }
}