using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{
    private float MaxArmRotation;
 private float MinArmRotation;
 private bool facingRight = true;
  float horizontalMove = 0f;
    float verticalMove = 0f;
    public int rotationOffset = 0;
    public float runSpeed = 0.28f;
    private GameObject armgun;
    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
        difference.Normalize();
        
        float rotZ = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
transform.rotation = Quaternion.Euler (0f, 0f, -rotZ - 180f);
    if (facingRight == true) {
         transform.rotation = Quaternion.Euler (0f, 0f, rotZ);
    } else {
    transform.rotation = Quaternion.Euler (0f, 0f, -rotZ - 180f);
         }
    }
    public void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}