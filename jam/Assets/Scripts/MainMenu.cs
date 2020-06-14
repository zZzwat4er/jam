using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject main_menu;
    public Canvas menuCanvas;
    public GameObject game_over;//нужен чтобы достать панель со сцены
    private static GameObject konets; //нужен для вызова конца игры вне данного класса.
    public void on_click()
    {
        // При нажатии на кнопку "Начать игру", выключаем панель с меню
        
        main_menu.active = false;
        konets = game_over;
        
    }

    public static void Game_Over()
    {
        konets.SetActive(true);
      
    }
}
