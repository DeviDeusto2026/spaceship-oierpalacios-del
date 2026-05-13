using UnityEngine;
using UnityEngine.PlayerLoop;

public class Rotation : MonoBehaviour
{

    public Vector3 rotationVector;
    public float rotationVelocity;


    void Start()
    {
        //Upscaled so we don't have to wait a year to see the earth rotate
        rotationVelocity *= 1000000;
    }

    void FixedUpdate()
    {
        this.transform.rotation *= Quaternion.Euler(rotationVector * rotationVelocity * Time.deltaTime);
    }
}