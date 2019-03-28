using System;
public class BranchNotExistsException : Exception
{
    public BranchNotExistsException(string message) : base(message)
    {
    }
}
