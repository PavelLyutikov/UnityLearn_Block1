using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float timeDelay = 0f;

    // Update is called once per frame
    void Update()
    {

        if (timeDelay == 0)
        {
            // On spacebar press, send dog
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                InvokeRepeating("TimeDelay", 0, 1);
            }
        }
    }

    void TimeDelay()
    {
        timeDelay += 1;
        if (timeDelay >= 2)
        {
            CancelInvoke("TimeDelay");
            timeDelay = 0;
        }
    }
}
