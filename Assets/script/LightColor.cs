using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightColor : MonoBehaviour
{
    Light lt;

    void Start()
    {
        lt = GetComponent<Light>();
    }

    // Darken the light completely over a period of 2 seconds.
    void Update()
    {
        lt.color = new Color(255, 0, 0);
    }
}
