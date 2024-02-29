namespace PersonelServer.Exceptions;

public sealed class IdentityNumberIsAlreadyExistsException : Exception
{
    public IdentityNumberIsAlreadyExistsException() : base("Identity number is already exists")
    {

    }
}