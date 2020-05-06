using UnityEngine;
using UnityEngine.EventSystems;

public class ShotSpawnerController : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform shotSpawn;
    [SerializeField]
    private float shotDelay;

    private float time;
    private bool active = true;

    private void Start()
    {
        time = shotDelay;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (!active)
            return;

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
        }
    }

    public void SetActive()
    {
        active = true;
    }

    public void SetInactive()
    {
        active = false;
    }
}
