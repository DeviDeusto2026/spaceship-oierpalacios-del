using UnityEngine;

public class balaLogica : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 10);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemigo")
        {
            other.gameObject.GetComponent<enemyControl>().TakeDamage(-1);
        }
    }
}

