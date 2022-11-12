using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveUI : MonoBehaviour
{
    public WaveSpawner wave;
    public TMP_Text level;
 
    void Update()
    {
        level.text = "Wave: " + wave.numWave.ToString();
    }
}
