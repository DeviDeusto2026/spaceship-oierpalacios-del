using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int health = 3;
    bool dead;
    public void TakeDamage(int amount)
    {
        Debug.Log("B");
        Debug.Log(health);
        health += amount;
        if(health == 0)
        {
            Debug.Log("Te han matado");
            Time.timeScale = 0;
            dead = true;
            Destroy(gameObject, 1);
        }
    }
    public bool isDead()
    {
        return dead;
    }
    private void Start()
    {
        dead = false;
    }
}
