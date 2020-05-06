using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowingAngle : MonoBehaviour
{
    [SerializeField]
    [Range(0, 360)]
    private float startAngle;
    [SerializeField]
    [Range(0, 360)]
    private float stopAngle;
    [SerializeField]
    private float speedRatio;

    private Rotating rotating;
    private float normalAngularSpeed;
    public bool isSlowed = false;

    private void Start()
    {
        rotating = GetComponent<Rotating>();
        normalAngularSpeed = rotating.angularSpeed;
    }

    private void Update()
    {
        float currentAngle = (transform.localEulerAngles.z + 360f) % 360f;

        if (isSlowed)
        {
            if (currentAngle > stopAngle)
            {
                rotating.angularSpeed = normalAngularSpeed;
                isSlowed = false;
            }
        }
        else
        {
            if(currentAngle > startAngle && currentAngle < stopAngle)
            {
                rotating.angularSpeed = normalAngularSpeed * speedRatio;
                isSlowed = true;
            }
        }
    }
}
