using System;

[Serializable]
public class NotFoundException : System.Exception
{
    public NotFoundException() : base()
    {

    }
    public NotFoundException(string name) : base(String.Format(name))
    {

    }
    public NotFoundException(string message, System.Exception inner) : base(message, inner) { }

    protected NotFoundException(System.Runtime.Serialization.SerializationInfo info,
        System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}