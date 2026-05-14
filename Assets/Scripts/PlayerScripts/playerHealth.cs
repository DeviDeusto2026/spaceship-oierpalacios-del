using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int health = 3;
    bool dead;
    public life lifeCanvas;
    public void TakeDamage(int amount)
    {
        Debug.Log(health);
        health += amount;
        lifeCanvas.UpdateUI(health);
        if (health == 0)
        {
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
