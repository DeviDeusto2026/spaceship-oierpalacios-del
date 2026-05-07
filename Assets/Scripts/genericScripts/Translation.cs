using UnityEngine;

public class Translation : MonoBehaviour
{
    [Tooltip("Number of segments that the ellipse is divided in")]
    public int ellipseSegments = 50;

    [Tooltip("Ellipse mayor axis radius")]
    public float avgSunDistance;

    public float e;

    [Tooltip("Orbital period in years")]
    public float orbitalPeriod;

    [Tooltip("Ellipse segments")]
    private Vector3[] _ellipsePoints = new Vector3[0];

    [Tooltip("Ellipse minor axis radius")]
    private float _xScale;

    [Tooltip("Ellipse major axis radius")]
    private float _zScale;

    [Tooltip("Orbital period in seconds")]
    private float _orbitalPeriofSeconds;

    [Tooltip("Origin point of the planet movement")]
    private Vector3 _origin;

    [Tooltip("Destiny point of the planet movement")]
    private Vector3 _destiny;

    [Tooltip("Counter use to loop the ellipsePoints array")]
    int counter = 0;

    private void Awake()
    {
        _zScale = avgSunDistance;
        _xScale = avgSunDistance * Mathf.Sqrt(1 - Mathf.Pow(e, 2));

        CalculateEllipse();
        
        _origin = _ellipsePoints[counter];
        _destiny = _ellipsePoints[counter + 1];

        this.transform.position = _origin;
    }

    void Start()
    {
        this.GetComponent<MeshRenderer>().material.color = Color.blue;

        //Parsed orbitalPeriod to seconds, divided by "constant" to accelerate the system
        _orbitalPeriofSeconds = (orbitalPeriod * 365 * 24 * 60 * 60)/1000000;
    }

    void Update()
    { 
        //Fixeted Y so the planets can still move upwards
        _origin.y = this.transform.position.y;
        _destiny.y = this.transform.position.y;

        //Move to next position
        move(_origin, _destiny);

        if (this.transform.position == _destiny)
        {
            nextDestiny();
        }
    }


    [Tooltip("Moves the planet to the destiny")]
    void move(Vector3 origin, Vector3 destiny)
    {
        Vector3 direction = destiny - origin;
        float velocity =  direction.magnitude / (_orbitalPeriofSeconds / ellipseSegments);
        this.transform.position += direction.normalized * velocity * Time.deltaTime;

        Vector3 myDirection = destiny - this.transform.position;
        if (direction.normalized != myDirection.normalized)
        {
            this.transform.position = destiny;
        }
    }


    [Tooltip("Changes origin to the next destiny")]
    void nextDestiny()
    {
        _origin = _destiny;
        
        counter++;

        //Reset array position
        if (counter == ellipseSegments)
        {
            counter = 0;
        }

        _destiny = _ellipsePoints[counter];
    }

    [Tooltip("Calculates all the Ellipse points and adds them to _ellipsePoints array")]
    private void CalculateEllipse()
    {
        _ellipsePoints = new Vector3[ellipseSegments];

        for (int i = 0; i < ellipseSegments; i++)
        {
            float _angle = ((float)i / (float)ellipseSegments) * 360 * Mathf.Deg2Rad;
            float x = Mathf.Cos(_angle) * _xScale;
            float z = Mathf.Sin(_angle) * _zScale;

            _ellipsePoints[i] = new Vector3(x, 0f, z);
        }
    }
}
