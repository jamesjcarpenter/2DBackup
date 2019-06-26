using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class fiyah : MonoBehaviour
{
    public bool m_FacingRight = true;

    // Update is called once per frame
    void Update()
    {
        void Move(float move)
        {
            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            void Flip()
            {
                // Switch the way the player is labelled as facing.
                m_FacingRight = !m_FacingRight;

                // Multiply the player's x local scale by -1.
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
        }
    }
}