using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public static int score; // current score
    public static int lives = 5;
    public Text text; // text where we put score
    public GameObject Lives;

    [SerializeField] private Sprite HP_5;
    [SerializeField] private Sprite HP_4;
    [SerializeField] private Sprite HP_3;
    [SerializeField] private Sprite HP_2;
    [SerializeField] private Sprite HP_1;
    [SerializeField] private Sprite HP_0;

    private Image currentImage;
    
    private void Start()
    {
        score = 0;
        currentImage = Lives.GetComponent<Image>();
    }

    private void Update()
    {
        text.text = "Score: " + score; // print score
        switch (lives)
        {
            case 5:
                currentImage.sprite = HP_5;
                break;
            case 4:
                currentImage.sprite = HP_4;
                break;
            case 3:
                currentImage.sprite = HP_3;
                break;
            case 2:
                currentImage.sprite = HP_2;
                break;
            case 1:
                currentImage.sprite = HP_1;
                break;
            default:
                currentImage.sprite = HP_0;
                break;
        }
    }
}
