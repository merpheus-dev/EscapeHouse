using System;

public class ItemDatabaseNotExistsException : Exception
{
    public ItemDatabaseNotExistsException(string message) : base(message)
    {

    }
}
