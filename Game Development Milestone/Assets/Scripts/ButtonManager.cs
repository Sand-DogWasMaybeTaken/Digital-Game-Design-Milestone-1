using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    // variables
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
