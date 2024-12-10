using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void RestartGame()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetGame();
        }
        SceneManager.LoadScene("KingdomEntry"); // החלף לשם הסצנה הראשית שלך
    }
}




//public void GoToMainMenu()
//{
//    SceneManager.LoadScene("MainMenuScene"); // החלף בשם סצנת התפריט שלך
//}

