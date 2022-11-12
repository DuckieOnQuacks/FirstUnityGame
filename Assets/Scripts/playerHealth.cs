using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    private Slider Slider;
    public Image fillImage;
    public playerCollision player;
    public float fillValue;

    void Awake()
    {
        Slider = GetComponent<Slider>();
    }

    void Update()
    {
        fillValue = (player.health - player.hits) / player.health;
        fillValue = Mathf.Round(fillValue * 10f) * 0.1f;
        Slider.value = fillValue;
    }
}
