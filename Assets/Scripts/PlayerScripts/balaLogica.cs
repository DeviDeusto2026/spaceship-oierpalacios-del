using UnityEngine;

public class balaLogica : MonoBehaviour
{
    public GameObject Disparador;
    void Update()
    {
        Destroy(gameObject, 10);
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Enemy" && Disparador.tag.Equals("Player")) || (other.gameObject.tag == "Jefe" && Disparador.tag.Equals("Player")))
        {
            other.gameObject.GetComponent<enemyControl>().TakeDamage(-1);
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "Player" && Disparador.tag.Equals("Jefe"))
        {
            other.gameObject.GetComponent<playerHealth>().TakeDamage(-1);
            Destroy(gameObject);
        }
    }
}

