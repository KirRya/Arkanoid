using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.allColors;
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] allColors;
    }
}
