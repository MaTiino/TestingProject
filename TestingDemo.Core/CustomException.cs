using System;

namespace TestingDemo.Core;

public class CustomException : Exception
{
    public CustomException(string message) : base(message) { }
} 