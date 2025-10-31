using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayLevel()
    {
        SceneManager.LoadScene("GameMapScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
