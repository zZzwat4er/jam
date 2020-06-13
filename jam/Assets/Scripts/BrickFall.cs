using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrickFall : MonoBehaviour
{
    private static int currentLevel = 1;
    private static int collisionCount = 0;
    private bool isCollided;
    private GameObject blockCreator;
    private GameObject ground;
    private BrickInfo info;
    
    public float speed = 10f;

    private void Awake()
    {
        ground = GameObject.FindWithTag("Ground");
    }

    private void OnEnable()
    {
        isCollided = false;
        info = gameObject.GetComponent<BrickInfo>();
        info.lvl = currentLevel;
        blockCreator = GameObject.FindWithTag("blockCreator");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("col");
        if(!isCollided)
        {
            // score calculation
            if (col.gameObject == ground && currentLevel == 1)
            {
                collisionCount++;
                Score.score += collisionCount;
            }
            else
            {
                if (col.gameObject.GetComponent<BrickInfo>().lvl == currentLevel - 1)
                {
                    collisionCount++;
                    Score.score += collisionCount * currentLevel;
                }
                else if (col.gameObject.GetComponent<BrickInfo>().lvl == currentLevel)
                {
                    currentLevel++;
                    collisionCount = 0;
                    Score.score += currentLevel;
                }
                else
                {
                    //todo get damage
                }
            }

            info.lvl = currentLevel;
            isCollided = true;
            blockCreator.GetComponent<CreateBlock>().enabled = true;
            blockCreator.GetComponent<CreateBlock>().enabled = false;
            Destroy(gameObject.GetComponent<BrickFall>());
        }
    }

    private void FixedUpdate()
    {
        gameObject.transform.parent.transform.position += Vector3.down * (Time.deltaTime * speed);
    }
}
