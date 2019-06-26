using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatscript2 : MonoBehaviour
{
    public Rigidbody2D rb;
    private GameObject boat;
    private GameObject player;
    public float moveSpeed = 3f;
    void OnCollisionEnter(Collision collision)
    {
        boat.transform.parent = GameObject.Find("player").transform;

        
    }
}