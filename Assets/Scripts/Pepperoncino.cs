using UnityEngine;
using UnityEngine.SceneManagement;

public class Pepperoncino : MonoBehaviour
{
    [Range(0.0f, 5.0f)]
    public float radius;
    public Transform obj;

    private GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {
        obj.localPosition = new Vector3(radius, 0.0f, 0.0f);
    }

    public void OnPepperoncinoShot()
    {
        gameController.Lost();
        gameController.CameraShake();
    }
}
