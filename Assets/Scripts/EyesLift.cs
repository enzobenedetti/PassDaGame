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
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - 0.3f, gameObject.transform.position.y);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + 0.3f, gameObject.transform.position.y);
        }
        
        //Right
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + 0.3f, gameObject.transform.position.y);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - 0.3f, gameObject.transform.position.y);
        }
        
        //Up
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.3f);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.3f);
        }
        
        //Down
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.3f);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 0.3f);
        }
    }
}
