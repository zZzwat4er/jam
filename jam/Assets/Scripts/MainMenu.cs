using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject main_menu;

    public void on_click()
    {
        // При нажатии на кнопку "Начать игру", выключаем панель с меню
        main_menu.active = false;
    }
}
