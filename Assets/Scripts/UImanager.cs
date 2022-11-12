using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UImanager : MonoBehaviour
{
    private GameObject player;
    private GameObject playerAir;
    private GameObject playerClone;
    public TMP_Text numCoins;
    public float health = 10.0f;

    public int total = 0;
    public  int total2 = 0;
    public int total3 = 0;
    public int total4 = 0;

    void Start()
    {
        player = GameObject.Find("Player"); 
        //health = playerClone.GetComponent<playerCollision>().health; 
    }
    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Player") != null)
        {
            total = player.GetComponent<playerCollision>().coins;
            health = player.GetComponent<playerCollision>().health;
        }
        else
        {
            playerAir = GameObject.Find("PlayerAir (1)(Clone)");
        }
        
        if(playerAir != null)
        {
            total2 = playerAir.GetComponent<playerCollision>().coins;
        }
        else 
        {
            playerClone = GameObject.Find("Player(Clone)");
        }

        if(playerClone != null)
        {
            total3 = playerClone.GetComponent<playerCollision>().coins;
            //playerAir.GetComponent<playerCollision>().health = health;
        }
        total4 = total + total2 + total3;
        numCoins.text = "Coins: " + total4.ToString();
    }
}
