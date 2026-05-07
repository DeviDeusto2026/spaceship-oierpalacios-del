using UnityEngine;

public class Movement : MonoBehaviour
{
    [Tooltip("The speed of the solar system movement in Y axis")]
    public float velocity = 0.0001f;

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0f, velocity * Time.deltaTime * 1000000, 0f);
    }
}
