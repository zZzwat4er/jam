using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject main_menu;
    public Canvas menuCanvas;
    public GameObject game_over;//нужен чтобы достать панель со сцены
    private static GameObject konets; //нужен для вызова конца игры вне данного класса.
    public GameObject Info;
    public void on_click()
    {
        // При нажатии на кнопку "Начать игру", выключаем панель с меню
        
        main_menu.active = false;
        konets = game_over;
        Info.active = true;
    }

    public static void Game_Over()
    {
        konets.SetActive(true);
        GameObject.Find("tapRegistrator").GetComponent<TapHandler>().enabled = false;
        GameObject.Find("Panel").SetActive(false);
    }

    public void restart_click()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex);
        Score.lives = 5;
        Score.score = 0;
        BrickFall.currentLevel = 1;
        BrickFall.collisionCount = 0;
    }
}
