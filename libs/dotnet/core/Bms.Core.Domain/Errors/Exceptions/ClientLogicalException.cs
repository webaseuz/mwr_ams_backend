namespace Bms.Core.Domain;

public class ClientLogicalException :
    ClientException
{
    public ClientLogicalException(string message)
        : base(message)
    { }

    public ClientLogicalException(ErrorCode code, string message) :
        base(message)
    {
        Code = code;
    }
}


public static class ClientLogicalExceptionHelper
{
    public static ClientLogicalException Wrap(string message, ErrorCode code)
        => new ClientLogicalException(code, message);


    #region Account
    public static ClientLogicalException InvlalidPassword()
        => Wrap($"Неправильный пароль", ErrorCode.CLIENT_CREDENTIALS);

    #endregion

    #region NotFound
    public static ClientLogicalException UserNotFound()
        => Wrap($"Пользователь не найден", ErrorCode.CLIENT_NOT_FOUND);

    public static ClientLogicalException NotFound(int id)
        => Wrap($"Информация по идентификатору = {id} не найдена", ErrorCode.CLIENT_NOT_FOUND);

    public static ClientLogicalException NotFound(Guid id)
        => Wrap($"Информация по идентификатору = {id} не найдена", ErrorCode.CLIENT_NOT_FOUND);

    public static ClientLogicalException NotFoundPinfl(string pinfl)
        => Wrap($"Информация по идентификатору = {pinfl} не найдена", ErrorCode.CLIENT_NOT_FOUND);

    public static ClientLogicalException NotFound(long id)
        => Wrap($"Информация по идентификатору = {id} не найдена", ErrorCode.CLIENT_NOT_FOUND);

    public static ClientLogicalException InvalidFuelCard(int transportId)
        => Wrap($"Не подходит топливная карта для этого транспорта = ({transportId})", ErrorCode.CLIENT_NOT_FOUND);

    public static ClientLogicalException NotificationTemplateNotFound(string template)
        => Wrap($"Информация по шаблону = {template} не найдена.", ErrorCode.CLIENT_NOT_FOUND);

    public static ClientLogicalException NotFountInvoiceNumber(string documentName, long[] ids)
        => Wrap($"Номер счета-фактуры не найден в таблице {documentName}, ID = '{string.Join(", ", ids)}'", ErrorCode.CLIENT_NOT_FOUND);
    #endregion

    #region Already Exists
    public static ClientLogicalException AlreadyExists(string value)
       => Wrap($"Значение '{value}' уже существует.", ErrorCode.CLIENT_ALREADY_EXISTS);

    public static ClientLogicalException AcceptDocumntAlreadyExists(string transportName, string docNumber)
       => Wrap($"У вас уже есть документ на это транспортное средство {transportName}. Номер документа {docNumber}", ErrorCode.CLIENT_ALREADY_EXISTS);
    public static ClientLogicalException AcceptedDocumentAlreadyExists(string value)
       => Wrap($"Подтвержденный документ для значения '{value}' уже существует.", ErrorCode.CLIENT_ALREADY_EXISTS);
    #endregion

    #region Documents
    public static ClientLogicalException NotAllowedStatus()
       => Wrap($"Неверный статус для этого действия", ErrorCode.CLIENT_NOT_ALLOWED_STATUS);

    #endregion

    #region Turnover related
    /// <summary>
    /// В системе недостаточно количества {name} = ({value})
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static ClientLogicalException NotEnaughQuantity(string name, string value)
       => Wrap($"В системе недостаточно количества {name} = ({value})", ErrorCode.CLIENT_NOT_ENAUGH);

    #endregion

    #region ApplicationLogic related
    public static ClientLogicalException CanNotPassive(string message)
        => Wrap($"Эту строку нельзя пассивировать. Поскольку эта строка используется в {message};", ErrorCode.CLIENT_CAN_NOT_PASSIVE);
    #endregion
}