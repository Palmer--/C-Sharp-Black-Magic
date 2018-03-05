using System;
using System.Reflection;

class Program
{
    /// <summary>
    /// This code demonstrates how you can create an instantiated object with a generic value.
    /// </summary>
    /// <param name="args"></param>

    static void Main(string[] args)
    {
        object obj = GetGenericObject();
        // This evaluation will return True. You now have an instantiated object with a generic value.
        var isObjGeneric = obj.GetType().GetTypeInfo().IsGenericTypeDefinition;
        Console.WriteLine(isObjGeneric);
    }

    static object GetGenericObject()
    {
        var type = typeof(Foo<>.GenericEnum).GetTypeInfo();
        var decField = type.GetDeclaredField("Bar");
        var obj = decField.GetValue(null);
        return obj;
    }

    class Foo<T>
    {
        public enum GenericEnum
        {
            Bar = 0
        }
    }
}