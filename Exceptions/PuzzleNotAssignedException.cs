using System;
public class PuzzleNotAssignedException : Exception
{
    public PuzzleNotAssignedException(string message) : base(message)
    {
    }
}