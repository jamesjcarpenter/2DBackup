using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skycontroller : MonoBehaviour
{
    public Transform myChildObject;
    public bool detachChild;
    void Update()
    {
        if (detachChild == true)
        {
            myChildObject.parent = null;
        }
    }
}