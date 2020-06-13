using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapHandler : MonoBehaviour
{
    public GameObject menu_panel; //панель главного меню
    void FixedUpdate()
    {
        if (menu_panel.active) return;
        if (Input.GetMouseButtonDown(0))
        {
            //при нажатии выключаем скрипт движения и включаем скрипт падения
            GameObject brick;
            if (brick = GameObject.FindWithTag("currentBrick"))
            {
                brick.transform.GetChild(0).GetComponent<BrickMovement>().enabled = false;
                brick.tag = "Untagged";
                brick.transform.GetChild(0).GetComponent<BrickFall>().enabled = true;
            }
        }
        // отслеживает нажатие
        foreach (Touch touch in Input.touches)
        {
            //при нажатии выключаем скрипт движения и включаем скрипт падения
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
