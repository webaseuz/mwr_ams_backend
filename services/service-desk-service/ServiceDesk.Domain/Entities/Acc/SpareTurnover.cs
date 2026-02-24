using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ServiceDesk.Domain.Constants;

namespace ServiceDesk.Domain;

[Table("acc_spare_turnover")]
public class SpareTurnover
{
    #region Properties
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("doc_number")]
    [StringLength(50)]
    public string DocNumber { get; set; } = null!;

    [Column("doc_date")]
    public DateTime DocDate { get; set; }

    [Required]
    [Column("present_spare_turnover_id")]
    public Guid PresentSpareTurnoverId { get; set; }

    [Column("table_id")]
    public int TableId { get; set; }

    [Column("document_id")]
    public long DocumentId { get; set; }

    [Column("document_table_id")]
    public long? DocumentTableId { get; set; }

    [Column("branch_id")]
    public int BranchId { get; set; }

    [Column("user_id")]
    public int? UserId { get; set; }

    [Column("device_spare_type_id")]
    public int DeviceSpareTypeId { get; set; }

    [Column("quantity")]
    public int Quantity { get; set; }

    [Column("is_debit")]
    public bool IsDebit { get; set; }

    [Column("is_deleted")]
    public bool IsDeleted { get; private set; }

    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }

    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [Column("modified_at", TypeName = "timestamp without time zone")]
    public DateTime? ModifiedAt { get; set; }

    [Column("modified_by")]
    public int? ModifiedBy { get; set; }
    #endregion

    #region Relationships
    [ForeignKey(nameof(BranchId))]
    public virtual Branch Branch { get; set; } = null!;

    [ForeignKey(nameof(DeviceSpareTypeId))]
    public virtual DeviceSpareType DeviceSpareType { get; set; } = null!;

    [ForeignKey(nameof(TableId))]
    public virtual Table Table { get; set; } = null!;

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    [ForeignKey(nameof(PresentSpareTurnoverId))]
    public virtual PresentSpareTurnover PresentSpareTurnover { get; set; }
    #endregion


    #region Methods

    public int MarkAsIsDeleted()
    {
        if (PresentSpareTurnover == null)
            throw new Exception($"PresentSpareTurnover has not be loaded ({nameof(SpareTurnover)} -> {nameof(MarkAsIsDeleted)})");

        if (!IsDebit)
            PresentSpareTurnover.Quantity += Quantity;
        else
            PresentSpareTurnover.Quantity -= Quantity;

        IsDeleted = true;

        return PresentSpareTurnover.Quantity;
    }

    public static SpareTurnover AddSpareTurnover(SpareTurnoverItemParameter parametrs)
    {
        var result = new SpareTurnover();

        result.Id = Guid.NewGuid();
        result.DocNumber = parametrs.DocNumber;
        result.DocDate = parametrs.DocDate;
        result.TableId = parametrs.TableId;
        result.DocumentId = parametrs.DocumentId;
        result.BranchId = parametrs.FromBranchId ?? parametrs.ToBranchId.Value;
        result.UserId = parametrs.FromUserId ?? parametrs.ToUserId;
        result.DeviceSpareTypeId = parametrs.DeviceSpareTypeId;
        result.Quantity = parametrs.Quantity;
        result.IsDebit = parametrs.IsDebit;

        return result;
    }
    #endregion

}

public class SpareTurnoverParameter
{
    public SpareTurnoverParameter(
        string docNumber,
        DateTime docDate,
        int tableId,
        long documentId,
        int movementTypeId,
        List<SpareTurnoverParameterTable> tables,
        int? fromBranchId = null,
        int? toBranchId = null,
        int? fromUserId = null,
        int? toUserId = null)
    {
        DocNumber = docNumber;

        if (docNumber == null)
            throw new Exception($"{nameof(DocNumber)} can not be null");

        if (tables == null || !tables.Any())
            throw new Exception("SpareTurnoverParameterTable list is null");

        DocDate = docDate;
        TableId = tableId;
        DocumentId = documentId;
        MovementTypeId = movementTypeId;
        Tables = tables;

        switch (movementTypeId)
        {
            case MovementTypeIdConst.INCOME:
                IsDebit = true;

                if (!toBranchId.HasValue)
                    throw new Exception($"{nameof(ToBranchId)} can not be null in movementType = {movementTypeId}");

                ToBranchId = toBranchId;
                ToUserId = toUserId;
                break;
            case MovementTypeIdConst.OUTCOME:
                IsDebit = false;

                if (!fromBranchId.HasValue)
                    throw new Exception($"{nameof(FromBranchId)} can not be null in movementType = {movementTypeId}");

                FromBranchId = fromBranchId;
                FromUserId = fromUserId;
                break;
            case MovementTypeIdConst.MOVEMENT:
                if (!fromBranchId.HasValue || !toBranchId.HasValue)
                    throw new Exception($"{nameof(FromBranchId)} and {nameof(ToBranchId)} can not be null in movementType = {movementTypeId}");
                break;
            default:
                throw new Exception($"Invalid {nameof(MovementTypeId)}");
        }
    }

    public string DocNumber { get; private set; }
    public DateTime DocDate { get; private set; }
    public int TableId { get; private set; }
    public long DocumentId { get; private set; }

    public int? FromBranchId { get; private set; }
    public int? FromUserId { get; private set; }
    public int? ToBranchId { get; private set; }
    public int? ToUserId { get; private set; }
    public bool IsDebit { get; private set; }

    public int MovementTypeId { get; private set; }

    public List<SpareTurnoverParameterTable> Tables { get; set; } = new();

    public List<SpareTurnoverItemParameter> ConvertToItemList()
    {
        SpareTurnoverParameter parameter = this;

        var result = new List<SpareTurnoverItemParameter>();

        foreach (var item in parameter.Tables)
        {
            result.Add(new SpareTurnoverItemParameter(parameter.DocNumber,
                                                      parameter.DocDate,
                                                      parameter.TableId,
                                                      parameter.DocumentId,
                                                      item.DocumentTableId,
                                                      item.DeviceSpareTypeId,
                                                      item.Quantity,
                                                      parameter.MovementTypeId,
                                                      parameter.FromBranchId,
                                                      parameter.ToBranchId,
                                                      parameter.FromUserId,
                                                      parameter.ToUserId));
        }

        return result;
    }
}

public class SpareTurnoverParameterTable
{
    public long? DocumentTableId { get; set; }
    public int DeviceSpareTypeId { get; set; }
    public int Quantity { get; set; }
}

public class SpareTurnoverItemParameter
{
    public SpareTurnoverItemParameter(
        string docNumber,
        DateTime docDate,
        int tableId,
        long documentId,
        long? documentTableId,
        int deviceSpareTypeId,
        int quantity,
        int movementTypeId,
        int? fromBranchId,
        int? toBranchId,
        int? fromUserId,
        int? toUserId)
    {
        DocNumber = docNumber;

        if (docNumber == null)
            throw new Exception($"{nameof(DocNumber)} can not be null");

        DocDate = docDate;
        TableId = tableId;
        DocumentId = documentId;
        MovementTypeId = movementTypeId;
        DocumentTableId = documentTableId;
        DeviceSpareTypeId = deviceSpareTypeId;
        Quantity = quantity;

        switch (movementTypeId)
        {
            case MovementTypeIdConst.INCOME:
                IsDebit = true;

                if (!toBranchId.HasValue)
                    throw new Exception($"{nameof(ToBranchId)} can not be null in movementType = {movementTypeId}");

                ToBranchId = toBranchId;
                ToUserId = toUserId;
                break;
            case MovementTypeIdConst.OUTCOME:
                IsDebit = false;

                if (!fromBranchId.HasValue)
                    throw new Exception($"{nameof(FromBranchId)} can not be null in movementType = {movementTypeId}");

                FromBranchId = fromBranchId;
                FromUserId = fromUserId;
                break;
            case MovementTypeIdConst.MOVEMENT:
                if (!fromBranchId.HasValue || !toBranchId.HasValue)
                    throw new Exception($"{nameof(FromBranchId)} and {nameof(ToBranchId)} can not be null in movementType = {movementTypeId}");
                break;
            default:
                throw new Exception($"Invalid {nameof(MovementTypeId)}");
        }

    }

    public string DocNumber { get; private set; }
    public DateTime DocDate { get; private set; }
    public int TableId { get; private set; }
    public long DocumentId { get; private set; }

    public int? FromBranchId { get; private set; }
    public int? FromUserId { get; private set; }
    public int? ToBranchId { get; private set; }
    public int? ToUserId { get; private set; }
    public bool IsDebit { get; private set; }

    public int MovementTypeId { get; private set; }
    public long? DocumentTableId { get; private set; }
    public int DeviceSpareTypeId { get; private set; }
    public int Quantity { get; private set; }
}