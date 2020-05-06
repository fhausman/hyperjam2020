using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField]
    Transform cam;
    [SerializeField]
    private float duration = 0.5f;
    [SerializeField]
    private float strength = 0.7f;

    Vector3 origPoisiton;
    private float timeLeft = 0.0f;

    private void Start()
    {
        origPoisiton = cam.position;
    }

    void Update()
    {
        if(timeLeft > 0)
        {
            cam.position = origPoisiton + Random.insideUnitSphere * strength;
            timeLeft -= Time.deltaTime;
        }
        else
        {
            cam.position = origPoisiton;
        }
    }

    public void StartShaking()
    {
        origPoisiton = cam.position;
        timeLeft = duration;
    }

    public void StopShaking()
    {
        duration = 0.0f;
    }

}
