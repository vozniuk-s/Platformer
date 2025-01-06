using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes
{
    StartMenu, Level1, Level2
}
public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene((int)Scenes.Level1);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
