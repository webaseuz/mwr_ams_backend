namespace Bms.Core.Domain;

public class ClientValidationException :
    ClientException
{
    public ClientValidationException(string message)
        : base(message)
    { }

    public ClientValidationException(ErrorCode code, string message) :
        base(message)
    {
        Code = code;
    }
}


public static class ClientValidationExceptionHelper
{
    public static ClientValidationException Wrap(string message, ErrorCode code)
        => new ClientValidationException(code, message);



    #region Not Null
    public static ClientValidationException NotNullPropert(string propertyName)
        => Wrap($"Это значение ({propertyName}) является обязательным", ErrorCode.CLIENT_NOT_NULL_PROPERTY);
    #endregion

    #region Invalid Property
    public static ClientValidationException InvalidLengthProperty(string propertyName, int min, int max)
        => Wrap($"Это значение ({propertyName}) должно быть длиной от {min} до {max} символов.", ErrorCode.CLIENT_INVALID_PROPERTY_FORMAT);
    public static ClientValidationException InvalidMinLengthProperty(string propertyName, int amount)
        => Wrap($"Это значение ({propertyName}) должно быть длиной больше {amount}", ErrorCode.CLIENT_INVALID_PROPERTY_FORMAT);

    public static ClientValidationException InvalidPropertyFormat(string propertyName)
        => Wrap($"Неверный формат ({propertyName})", ErrorCode.CLIENT_INVALID_PROPERTY_FORMAT);
    
    public static ClientValidationException InvalidPropertyFormat(string propertyName, string value)
        => Wrap($"""
            Неверный формат ({propertyName}: "value")
            Например, "123 AAA"
            """, ErrorCode.CLIENT_INVALID_PROPERTY_FORMAT);
            

    public static ClientValidationException PropertiesMustNotBeEqual(string prop1, string prop2)
        => Wrap($"Эти столбцы не должны быть равны ({prop1} , {prop2})", ErrorCode.CLIENT_PROPS_MUST_NOT_EQUAL);
    #endregion
}