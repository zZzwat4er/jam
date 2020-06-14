using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrickFall : MonoBehaviour
{
    private static int currentLevel = 1; // текущей слой
    private static int collisionCount = 0; // сколько кирпечей было поствленно на текущем слое
    private bool isCollided;// костыль для того чтобы кирпичь колайдил только 1 раз 
    private GameObject blockCreator; // обект на карте на координатах которого создается кирпич
    private GameObject ground;
    private BrickInfo info; // информация о кирпиче(пока только в каком ряду он стоит)
    public int Zavershim; //панель завершения игры
    
    public float speed = 10f; // скорость падения
    // проверяем обе ли половины кирпича стоят на земле
    private bool isGrounded()
    {
        return transform.Find("leftSide").GetComponent<GroundCollisionCheck>().IsGrounded() && 
               transform.Find("rightSide").GetComponent<GroundCollisionCheck>().IsGrounded();
    }

    private void Awake()
    {
        ground = GameObject.FindWithTag("Ground"); // найти землю
        
    }

    // базовые настройки переменных при активации скрипта
    private void OnEnable()
    {
        isCollided = false;
        info = gameObject.GetComponent<BrickInfo>();
        info.lvl = currentLevel;
        blockCreator = GameObject.FindWithTag("blockCreator");
    }
    // обработка столкновений
    private void OnTriggerEnter2D(Collider2D col)
    {
        bool not = false;
        if(!isCollided)
        {
            //при косании с землей актевируем обекты крторые проверяют касание земли кирпечем
            transform.Find("leftSide").gameObject.SetActive(true);
            transform.Find("rightSide").gameObject.SetActive(true);
            // score calculation
            if (col.gameObject == ground && currentLevel == 1)
            {
                gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(0.3f, 0.2f, 0.3f, 1);//изменение цвета кирпича
                collisionCount++;
                Score.score += collisionCount;
                                        

            }
            else
            {
                if(col.gameObject != ground)
                {
                    if (col.gameObject.GetComponent<BrickInfo>().lvl == currentLevel - 1)
                    {
                        gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(0.3f, 0.2f, 0.3f, 1); //изменение цвета кирпича
                        collisionCount++;
                        Score.score += collisionCount * currentLevel;
                        
                    }
                    else if (col.gameObject.GetComponent<BrickInfo>().lvl == currentLevel && isGrounded())
                    {
                        gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(0.3f, 0.2f, 0.3f, 1);//изменение цвета кирпича
                        currentLevel++;
                        collisionCount = 0;
                        Score.score += currentLevel;
                        
                    }
                    else
                    {
                        Score.lives--;
                        Destroy(this.gameObject);
                        if(Score.lives <= 0)
                            MainMenu.Game_Over();
                    }
                }
                else
                {
                    Score.lives--;
                    not = true;
                    Destroy(this.gameObject);
                    if(Score.lives <= 0)
                        MainMenu.Game_Over();
                }
            }
            Debug.Log(isGrounded());
            info.lvl = currentLevel;// запись слоя на котором лежит кирпич
            isCollided = true;
            gameObject.layer = 8; // изменение слоя кирпича на слой Ground
            // тригер скрипта для спавна кирпича
           
                blockCreator.GetComponent<CreateBlock>().enabled = true;
                blockCreator.GetComponent<CreateBlock>().enabled = false;
            

            // удоление данного скрипта с обекта чтобы не было двойного сробатывания при падение кирпича на кирпич
            Destroy(gameObject.GetComponent<BrickFall>());
        }
    }

    private void FixedUpdate()
    {
        // просто опускание кирпича с константной скоростью    
        gameObject.transform.parent.transform.position += Vector3.down * (Time.deltaTime * speed);
    }
}
