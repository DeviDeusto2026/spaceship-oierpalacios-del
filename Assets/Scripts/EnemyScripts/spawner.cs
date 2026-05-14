using UnityEngine;

public class spawner : MonoBehaviour
{
    float maxTime = 3;
    float curTime;
    public GameObject[] enemigosNormales;
    public GameObject jefeObj;
    public GameObject enemigoChiquito;
    bool jefe;
    bool jefeSpawneado;
    public GameObject bala;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        curTime = maxTime;
        jefeSpawneado = false;
    }
    public bool isJefe()
    {
        return jefe;
    }
    public void setJefe(bool valor)
    {
        jefe = valor;
    }
    // Update is called once per frame
    void Update()
    {
        curTime -= Time.deltaTime;
        if (!jefe)
        {
            if (curTime <= 0)
            {
                curTime = maxTime;
                GameObject enemigo = Instantiate(enemigosNormales[Random.Range(0, enemigosNormales.Length - 1)]);
                if(Random.Range(0, 100) < 10)
                {
                    jefe = true;
                    jefeSpawneado = true;
                }
            }
        }
        else
        {
            if (jefeSpawneado)
            {
                GameObject jefe = Instantiate(jefeObj);
                jefeSpawneado = false;
            }
            if(curTime <= 0)
            {
                curTime = maxTime;
                GameObject enemigo = Instantiate(enemigoChiquito);
                enemigo.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            }
        }
    }
}
