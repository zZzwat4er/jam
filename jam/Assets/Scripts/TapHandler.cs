using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapHandler : MonoBehaviour
{
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject brick;
            if (brick = GameObject.FindWithTag("currentBrick"))
            {
                brick.transform.GetChild(0).GetComponent<BrickMovement>().enabled = false;
                brick.tag = "Untagged";
                brick.transform.GetChild(0).GetComponent<BrickFall>().enabled = true;
            }
        }

        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                GameObject brick;
                if (brick = GameObject.FindWithTag("currentBrick"))
                {
                    brick.transform.GetChild(0).GetComponent<BrickMovement>().enabled = false;
                    brick.tag = "Untagged";
                    brick.transform.GetChild(0).GetComponent<BrickFall>().enabled = true;
                }
            }
        }
    }
}
