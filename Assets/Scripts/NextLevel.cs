using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private string LevelName;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            string s = SceneManager.GetActiveScene().name.Replace("Level", "");
            int res;
            bool t = int.TryParse(s,out res);

            if(t && PlayerPrefs.GetInt("LevelFinished") <= res)
            {
                PlayerPrefs.SetInt("LevelFinished", res);
            }
            
            SceneManager.LoadScene(LevelName);
        }
    }
}
