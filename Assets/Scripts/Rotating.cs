using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    [SerializeField]
    private float angularSpeed;
    [SerializeField]
    private bool isClockwise = true;

    private void Update()
    {
        float angle = Mathf.Rad2Deg * Time.deltaTime * angularSpeed * (isClockwise ? 1 : -1);
        transform.RotateAround(transform.position, Vector3.forward, angle);
    }
}
