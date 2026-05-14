using UnityEngine;

public class enemyChasing : MonoBehaviour
{
    public enemyControl enemyControl;

    public void Chase()
    {
        if (enemyControl == null) return;
        if (enemyControl.target == null) return;

        Vector3 dir = (enemyControl.target.transform.position
                       - transform.position).normalized;
        transform.position += dir * enemyControl.speed * 2f * Time.deltaTime;

        if (dir != Vector3.zero)
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                Quaternion.LookRotation(dir),
                5f
            );
    }
}