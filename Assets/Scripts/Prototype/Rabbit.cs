using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Rabbit : MonoBehaviour
{
    [SerializeField]
    private float openDuration;
    [SerializeField]
    private Color openColor;
    [SerializeField]
    private Color defaultColor;
    [SerializeField]
    private UnityEvent onCollideWhileOpen;
    [SerializeField]
    private UnityEvent onCollideWhileClosed;

    private Renderer renderer;

    private bool isOpen = false;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = defaultColor;
    }

    public void Open()
    {
        if (!isOpen)
        {
            isOpen = true;
            StartCoroutine(OpenCoroutine());
        }
    }

    private IEnumerator OpenCoroutine()
    {
        renderer.material.color = openColor;

        yield return new WaitForSeconds(openDuration);

        renderer.material.color = defaultColor;
        isOpen = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        if(isOpen)
        {
            onCollideWhileOpen.Invoke();
        }
        else
        {
            onCollideWhileClosed.Invoke();
        }
    }
}
