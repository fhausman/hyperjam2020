using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController_prot : MonoBehaviour
{
    [SerializeField]
    private Camera camera;
    [SerializeField]
    private float carrotSpawnInterval;
    [SerializeField]
    private GameObject carrot;
    [SerializeField]
    private Text text;

    [SerializeField]
    private List<Transform> carrotSpawnPositions;

    private int score;

    private void Start()
    {
        text.text = "Score: " + score;
        StartCoroutine(SpawnCarrots());
    }

    private void Update()
    {
#if UNITY_EDITOR
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hit);
            GameObject hitObject = hit.collider?.gameObject;
            if(hitObject?.tag == "Rabbit")
            {
                Rabbit hitRabbit = hitObject.GetComponent<Rabbit>();
                hitRabbit.Open();
            }
        }
#endif
    }

    private IEnumerator SpawnCarrots()
    {
        while (true)
        {
            yield return new WaitForSeconds(carrotSpawnInterval);

            Vector3 spawnPosition = carrotSpawnPositions[Random.Range(0, carrotSpawnPositions.Count)].position;
            spawnPosition.y = camera.transform.position.y;

            Instantiate(carrot, spawnPosition, new Quaternion());
        }
    }

    public void ChangeScore(bool increase)
    {
        score += (increase ? 1 : -1);
        text.text = "Score: " + score;
    }
}
