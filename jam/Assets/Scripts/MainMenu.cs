using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject main_menu;

    public void on_click()
    {
        main_menu.active = false;
    }
}
