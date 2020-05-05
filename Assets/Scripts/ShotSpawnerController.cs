using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
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
            GameObject shot = Instantiate(bullet, shotSpawn.position, new Quaternion());
            shot.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, shotSpeed));
        }
    }
}
