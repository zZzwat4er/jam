using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score; // current score
    public static int lives = 5;
    public Text text; // text where we put score
    public Text Lives;

    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        text.text = "Score: " + score; // print score
        Lives.text = lives + "";
    }
}
