using UnityEngine;
using UnityEngine.SceneManagement;

public class Pepperoncino : MonoBehaviour
{
    [Range(0.0f, 5.0f)]
    public float radius;
    public Transform obj;

    void Update()
    {
        obj.localPosition = new Vector3(radius, 0.0f, 0.0f);
    }

    public void OnPepperoncinoShot()
    {
        //todo: naive reloding, change
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
