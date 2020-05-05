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
    [SerializeField]
    private float shotDelay;

    private float time;

    private void Start()
    {
        time = shotDelay;
    }

    private void Update()
    {
        time += Time.deltaTime;

#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            Shoot();
        }
#endif
    }

    private void Shoot()
    {
        if (time >= shotDelay)
        {
            time = 0f;
            GameObject shot = Instantiate(bullet, shotSpawn.position, Quaternion.Euler(90, 0, 0));
            shot.GetComponent<Rigidbody>().AddForce(0, 0, shotSpeed);
        }
    }
}
