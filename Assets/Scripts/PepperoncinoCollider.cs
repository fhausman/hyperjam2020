using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepperoncinoCollider : MonoBehaviour
{
    Pepperoncino parent;

    private void Awake()
    {
        parent = GetComponentInParent<Pepperoncino>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            parent.OnPepperoncinoShot();
        }
    }
}
