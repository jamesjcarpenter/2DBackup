using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabWeapon : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject bulletTrailPrefab;
    public Transform muzzleflash;

    // Update is called once per frame

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        Destroy(GameObject.Find("Bullet(Clone)"), 0.4f);
        Destroy(GameObject.Find("Line(Clone)"), 0.10f);
        Destroy(GameObject.Find("doo(Clone)"), 1f);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Instantiate(bulletTrailPrefab, firePoint.position, firePoint.rotation);

        Transform clone = (Transform)Instantiate(muzzleflash, firePoint.position, firePoint.rotation);
        clone.parent = firePoint;
        float size = Random.Range(0.6f, 0.9f);
        clone.localScale = new Vector3(size, size, size);
        Destroy(clone.gameObject, 0.02f);
    }
}