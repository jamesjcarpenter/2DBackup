using UnityEngine;
using System.Collections;

public class boatscript : MonoBehaviour
{
    public Rigidbody2D rb;
    private GameObject boat;
    public float moveSpeed = 3f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Moves Forward and back along z axis                           //Up/Down
        rb.AddForce(Vector2.right * Time.deltaTime * Input.GetAxisRaw("Vertical") * moveSpeed);
        //Moves Left and right along x Axis                               //Left/Right
        rb.AddForce(Vector2.right * Time.deltaTime * Input.GetAxisRaw("Horizontal") * moveSpeed);
        }
}