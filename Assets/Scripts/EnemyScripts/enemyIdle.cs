using UnityEngine;

public class enemyIdle : MonoBehaviour
{
    public enemyControl enemyControl;
    public float maxDistance = 10f;

    float cronometro = 0f;
    int rutina = 0;
    Quaternion anguloObjetivo = Quaternion.identity;
    Vector3 destinoPatrulla = Vector3.zero;
    bool destinoAsignado = false;

    public void Idle()
    {
        if (rutina == 2 && destinoAsignado)
        {
            float distAlDestino = Vector3.Distance(transform.position, destinoPatrulla);

            if (distAlDestino > 0.3f)
            {
                Vector3 dir = (destinoPatrulla - transform.position).normalized;
                transform.position += dir * enemyControl.speed * Time.deltaTime;
                transform.rotation = Quaternion.RotateTowards(
                    transform.rotation,
                    Quaternion.LookRotation(dir),
                    2f
                );
                return;
            }

            destinoAsignado = false;
            rutina = 0;
        }

        cronometro += Time.deltaTime;
        if (cronometro >= 4f)
        {
            rutina = Random.Range(0, 2);
            cronometro = 0f;
        }

        switch (rutina)
        {
            case 0:
                transform.rotation = Quaternion.RotateTowards(
                    transform.rotation, anguloObjetivo, 0.5f);
                break;
            case 1:
                anguloObjetivo = Random.rotation;
                destinoPatrulla = transform.position + new Vector3(
                    Random.Range(-maxDistance, maxDistance),
                    Random.Range(-maxDistance, maxDistance),
                    Random.Range(-maxDistance, maxDistance)
                );
                destinoAsignado = true;
                rutina = 2;
                break;
        }
    }
}