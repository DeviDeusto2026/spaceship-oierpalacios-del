using UnityEngine;

public class playerHealth : MonoBehaviour
{
    private int health = 3;
    public void TakeDamage(int amount)
    {
        health += amount;
        if(health == 0)
        {
            Debug.Log("Te han matado");
            Time.timeScale = 0;
            Destroy(gameObject, 1);
        }
    }
}
