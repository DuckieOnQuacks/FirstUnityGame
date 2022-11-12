using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    public Transform cameraTransform;
    private Vector3 originalCameraPos;

    public float shakeDuration = 0.01f;
    public float shakeAmount = 0.01f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else 
        {
            Destroy(this);
        }
    }

    public void ShakeCamera(float shakeDuration1)
    {
        shakeDuration = shakeDuration1;
    }

    // Start is called before the first frame update
    void Start()
    {
        originalCameraPos = cameraTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(shakeDuration > 0)
        {
            cameraTransform.localPosition = originalCameraPos + Random.insideUnitSphere * shakeAmount;
            shakeDuration -= Time.deltaTime;
        }
        else
        {
            shakeDuration = 0f;
            cameraTransform.localPosition = originalCameraPos;
        }
    }
}
