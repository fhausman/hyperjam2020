using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSpawnerController : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform shotSpawn;
    [SerializeField]
    private float shotSpeed;

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
#endif
    }

    private void Shoot()
    {
        GameObject shot = Instantiate(bullet, shotSpawn.position, Quaternion.Euler(90, 0, 0));
        shot.GetComponent<Rigidbody>().AddForce(0, 0, shotSpeed);
    }
}
