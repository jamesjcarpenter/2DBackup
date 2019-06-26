using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatscriptplayer : MonoBehaviour
{
    public GameObject boat;

    //Invoked when a button is pressed.
    private void OnCollisionEnter(Collision c)
    {
        c.transform.parent = gameObject.transform;

    }
}