using System;

public class BranchPortNotConnectedException : Exception
{
    public BranchPortNotConnectedException(string message) : base(message)
    {
    }
}