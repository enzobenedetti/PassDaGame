using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void ToTheLevelSelector()
    {
        SceneManager.LoadScene("LevelSelector");
    }
}
