using UnityEngine;
using System.Collections;

public interface IFly {


}

public static class Fly
{
    public static void fly<T>(this T fly)where T:IFly
    {
        Debug.Log("Fly!");
    }
}
