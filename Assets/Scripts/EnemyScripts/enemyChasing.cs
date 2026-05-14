using UnityEngine;

public class enemyChasing : MonoBehaviour
{
    public enemyControl enemyControl;
    float zigzagTimer = 0f;
    float zigzagFrequency = 1.5f;  // segundos por ciclo
    float zigzagAmplitude = 4f;
    public void Chase()
    {
        if (enemyControl == null) return;
        if (enemyControl.target == null) return;

        Vector3 dir = (enemyControl.target.transform.position
                       - transform.position).normalized;
        if (enemyControl.esJefe)
        {
            zigzagTimer += Time.deltaTime;

            // Vector perpendicular al avance (en el plano horizontal)
            Vector3 perpendicular = new Vector3(-dir.z, 0f, dir.x);
            float zigzag = Mathf.Sin(zigzagTimer * (2f * Mathf.PI / zigzagFrequency))
                           * zigzagAmplitude;

            Vector3 finalDir = (dir + perpendicular * zigzag).normalized;

            transform.position += finalDir * enemyControl.speed * 2f * Time.deltaTime;

            if (finalDir != Vector3.zero)
                transform.rotation = Quaternion.RotateTowards(
                    transform.rotation,
                    Quaternion.LookRotation(finalDir),
                    5f
                );
        }
        else
        {
            transform.position += dir * enemyControl.speed * 2f * Time.deltaTime;

            if (dir != Vector3.zero)
                transform.rotation = Quaternion.RotateTowards(
                    transform.rotation,
                    Quaternion.LookRotation(dir),
                    5f
                );
        }
    }
}