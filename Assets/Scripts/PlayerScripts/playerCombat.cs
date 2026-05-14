using UnityEngine;

public class playerCombat : MonoBehaviour
{
    public GameObject prefabBala;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bala = Instantiate(prefabBala, transform.position, transform.rotation);
            bala.GetComponent<Rigidbody>().AddForce(transform.forward * 10000, ForceMode.Force);
            bala.GetComponent<balaLogica>().Disparador = this.gameObject;
        }
    }
}
