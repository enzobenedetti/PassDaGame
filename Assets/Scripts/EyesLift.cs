using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyesLift : MonoBehaviour
{
    //Aled
    public void Update()
    {
        //Left
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - 0.3f, gameObject.transform.position.y);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + 0.3f, gameObject.transform.position.y);
        }
        
        //Right
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + 0.3f, gameObject.transform.position.y);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow)|| Input.GetKeyUp(KeyCode.D))
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - 0.3f, gameObject.transform.position.y);
        }
        
        //Up
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.3f);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.3f);
        }
        
        //Down
        if (Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetKeyDown(KeyCode.S))
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.3f);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow)|| Input.GetKeyUp(KeyCode.S))
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.3f);
        }
    }
}
