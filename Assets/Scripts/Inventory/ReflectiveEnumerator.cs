using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System.Linq;
using System;

public static class ReflectiveEnumerator            //returns all the subclasses of a class
{
    static ReflectiveEnumerator() { }

    public static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class
    {
        List<T> objects = new List<T>();
        foreach (Type type in
            Assembly.GetAssembly(typeof(T)).GetTypes()
            .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
        {
            objects.Add((T)Activator.CreateInstance(type, constructorArgs));
        }
        return objects;
    }
}
