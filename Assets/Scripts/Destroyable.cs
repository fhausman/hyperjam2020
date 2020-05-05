using UnityEngine;
using UnityEngine.Events;

public class Destroyable : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private int scoreOnHit = 1;
    [SerializeField]
    private UnityEvent onDestroy;

    private GameController gameController;

    private int maxHealth;

    private void Start()
    {
        maxHealth = health;
        gameController = FindObjectOfType<GameController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            health--;

            gameController.IncreaseScore(scoreOnHit);
            gameController.ModifyHealthBar(health / (float)maxHealth);

            if (health <= 0)
            {
                Destroy(gameObject);
                onDestroy?.Invoke();
            }
        }
    }
}
