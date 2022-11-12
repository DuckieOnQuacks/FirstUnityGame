using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 5.00f;
    public float hits = 0.0f;
    public Transform[] dropCoinPoint;
    public Transform firePoint;
    public GameObject CoinPrefab;
    public GameObject bullet;

    private float timeBetweenShots;
    public float startTimeBtwShots;
    void Start ()
    {
        timeBetweenShots = startTimeBtwShots;
    }
    void Update()
    {
        if(timeBetweenShots <= 0)
        {
            Instantiate(bullet, firePoint.position, Quaternion.identity);
            timeBetweenShots = startTimeBtwShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
    ////////////////////////////////////
    public void takeDamage(float damage)
    {
        hits++;
        health = health - damage;
        if(health <= 0)
        {
            //Instantiate(deathEffect, transform.position, Quaternion.identity);
            dropCoin();
            Destroy(gameObject);
        }       
    }
    
    //////////////////////
    public void dropCoin()
    {
        for(int i = 0; i < dropCoinPoint.Length; i++)
        {
            Instantiate(CoinPrefab, dropCoinPoint[i].position, Quaternion.identity);
        }
    }
}
