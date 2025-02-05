﻿namespace CodeTest.Application.Exceptions;

[Serializable]
public class ProblemException(string error, string message) : Exception(message)
{
    public string Error { get; } = error;
    public new string Message { get; } = message;
}