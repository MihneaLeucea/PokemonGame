using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public Animator transitionAnim;
    public string sceneToLoad = "BattleScreen";

    public void StartTransition()
    {
        transitionAnim.SetTrigger("Fade");
        Invoke("LoadScene", 1f);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

}
