using UnityEngine;
using UnityEngine.SceneManagement;

public class BushInteraction : MonoBehaviour
{
    int maxChance = 100;
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bush")
        {
            int randomNumber = Random.Range(1, maxChance);
            if (randomNumber > 90)
            {
                SceneManager.LoadScene("BattleScene");

            }

        }
    }
}
