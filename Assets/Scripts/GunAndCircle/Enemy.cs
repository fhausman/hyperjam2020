using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private Transform circleCenter;
    [SerializeField]
    private float angularSpeed;

    private void Update()
    {
        transform.RotateAround(circleCenter.position, Vector3.up, Mathf.Rad2Deg * Time.deltaTime * angularSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        health--;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
