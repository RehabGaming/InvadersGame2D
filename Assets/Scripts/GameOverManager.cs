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
        SceneManager.LoadScene("KingdomEntry"); // ���� ��� ����� ������ ���
    }
}




//public void GoToMainMenu()
//{
//    SceneManager.LoadScene("MainMenuScene"); // ���� ��� ���� ������ ���
//}

