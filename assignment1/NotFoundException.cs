using System;

[Serializable]
public class NotFoundException : System.Exception
{
    public NotFoundException()
    {

    }
    public NotFoundException(string name) : base(String.Format( name))
    {

    }
}