using System;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;
    public Text text;


    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        text.text = "Score: " + score;
    }
}
