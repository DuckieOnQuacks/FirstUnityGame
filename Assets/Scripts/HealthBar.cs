using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
        private Slider Slider;
        public Image fillImage;
        public Enemy enemy;
        public float fillValue;

        void Awake()
        {
            Slider = GetComponent<Slider>();
        }

        void Update()
        {
            fillValue = (enemy.health - enemy.hits) / enemy.health;
            fillValue = Mathf.Round(fillValue * 10.0f) * 0.1f;
            Slider.value = fillValue;
        }
}
