using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerCollision : MonoBehaviour
{
    public float hits = 0.0f;
    private float damage = 1.0f;
    public float health = 10.0f;
    public int coins = 0;
   public GameObject resetMenuUi;


    void Start()
    {
        coins = 0;
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.CompareTag("Bullet") && hitInfo.gameObject != null)
        {
            takeDamage();
            Destroy(hitInfo);
        }
        
        if(hitInfo.CompareTag("Coin"))
        {
            coins ++;
            Destroy(hitInfo.gameObject);
        }
    }

    ////////////////////////////////////
    public void takeDamage()
    {
        CameraShake.instance.ShakeCamera(1f);
        hits++;
        health = health - damage;
        if(health <= 0)
        {
            //Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
