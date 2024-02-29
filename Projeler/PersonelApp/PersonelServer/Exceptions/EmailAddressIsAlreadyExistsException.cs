namespace PersonelServer.Exceptions;

public sealed class EmailAddressIsAlreadyExistsException : Exception
{
    public EmailAddressIsAlreadyExistsException() : base("Email address is already exists")
    {
        
    }
}
