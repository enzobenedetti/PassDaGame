using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public bool resetSave;
    public Transform levelPanel;

    private void Awake()
    {
        if (resetSave)
        {
            PlayerPrefs.DeleteAll();
        }
        
        if(!PlayerPrefs.HasKey("LevelFinished"))
        {
            PlayerPrefs.SetInt("LevelFinished", 0);
        }
    }

    private void Start()
    {
        int levelFinished = PlayerPrefs.GetInt("LevelFinished");
        for (int i = 0; i < levelFinished+1; i++)
        {
            if (levelPanel.childCount <= i)
                return;
            levelPanel.GetChild(i).GetComponent<Button>().interactable = true;
        }
    }

    public void LoadLevel(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }
}
