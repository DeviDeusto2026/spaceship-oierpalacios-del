using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    public enemyControl enemyControl;
    public GameObject balaPrefab;    // prefab con balaLogica

    public void Attack(Transform target)
    {
        if (target == null || balaPrefab == null) return;
        
        
        // Girar hacia el jugador en 3D
        Vector3 dir = (target.position - transform.position).normalized;
        if (dir != Vector3.zero)
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                Quaternion.LookRotation(dir),
                360f
            );
        // Instanciar bala apuntando al jugador solo si es jefe: Tag de jefe: Jefe
        if (enemyControl.esJefe)
        {
            GameObject bala = Instantiate(balaPrefab,
                                        transform.position,
                                        Quaternion.LookRotation(dir));

            // Asignar el Jefe como Disparador para que balaLogica
            // identifique la bala como enemiga
            balaLogica bl = bala.GetComponent<balaLogica>();
            if (bl != null) {bl.Disparador = enemyControl.gameObject; bala.GetComponent<Rigidbody>().AddForce(transform.forward * 10000, ForceMode.Force);}
        }

    }
}