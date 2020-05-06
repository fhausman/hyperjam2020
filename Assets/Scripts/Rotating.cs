using UnityEngine;

public class Rotating : MonoBehaviour
{
    [SerializeField]
    private bool isClockwise = true;

    public float angularSpeed;

    private void Update()
    {
        float angle = Mathf.Rad2Deg * Time.deltaTime * angularSpeed * (isClockwise ? 1 : -1);
        transform.RotateAround(transform.position, Vector3.forward, angle);
    }
}
