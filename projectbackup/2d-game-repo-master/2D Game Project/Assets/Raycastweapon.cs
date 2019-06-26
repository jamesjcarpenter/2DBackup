using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycastweapon : MonoBehaviour
{

    public Transform firePoint;
    public int damage = 40;
    public GameObject impactEffect;
    public LineRenderer lineRenderer;

void Start()
{
}
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, Input.mousePosition - firePoint.position);
        Vector2 screenToWorldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 mousePosition = new Vector2 (screenToWorldPoint.x, screenToWorldPoint.y);

        if (hitInfo)
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.DamageEnemy(damage);
            }

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right);
        }

        lineRenderer.enabled = true;

        yield return 0;

        lineRenderer.enabled = false;
    }
}