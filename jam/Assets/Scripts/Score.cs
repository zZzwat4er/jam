using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score; // current score
    public Text text; // text where we put score


    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        text.text = "Score: " + score; // print score
    }
}
