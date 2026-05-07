using UnityEngine;

public class TimeControler : MonoBehaviour
{
    [Tooltip("NewTimeScale < 1 and newTimeScale > 1, decrease and increase respectively all the simulation speed")]
    [Range(0,100)] public float newTimeScale;

    [Tooltip("If this option is selected, the simulation will pause. Pressing the P key will pause and resume the simulation.")]
    private bool paused = false;

    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = newTimeScale;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            paused = !paused;
        }
    }
}
