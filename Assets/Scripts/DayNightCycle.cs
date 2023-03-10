using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class DayNightCycle : MonoBehaviour
{
    public Volume globalVolume;

    [SerializeField] float seconds;
    public float timeTillNight;

    public List<GameObject> enemies = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (seconds < timeTillNight)
        {
            seconds += Time.deltaTime;
        }

        else if (seconds >= timeTillNight)
        {
            globalVolume.weight = 1f;
            foreach(GameObject i in enemies)
            {
                i.SetActive(true);
            }
        }
    }
}
