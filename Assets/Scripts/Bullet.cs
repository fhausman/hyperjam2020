using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float bulletInitialSpeed;
    [SerializeField]
    private float bulletSpeedDelta;

    private Rigidbody2D rigidbody2D;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(new Vector2(0, bulletInitialSpeed));
    }

    private void FixedUpdate()
    {
        rigidbody2D.AddForce(new Vector2(0, bulletSpeedDelta) * Time.deltaTime);
    }
}
