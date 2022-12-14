using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float offset;

    void Update()
    {
        if(pauseMenu.gameIsPaused != true)
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
            if(Input.GetMouseButtonDown(0))
            {
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            }
        }
    }
}
