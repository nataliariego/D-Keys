using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
class MyClass
{
    static MyClass()
    {
        Debug.Log("Hola?");
        // EditorApplication.update += Update;

    }

    static void Update()
    {
       // Debug.Log("Updating");
    }
}
