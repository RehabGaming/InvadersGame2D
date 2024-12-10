using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton עבור גישה ל-GameManager
    public GameObject[] characters; // מערך פריפאבים של דמויות
    public Transform spawnPoint; // נקודת יצירה
    public float spawnInterval = 5f; // זמן בין יצירת דמויות
    public int lives = 3; // מספר החיים ההתחלתי

    private void Awake()
    {
        // שמירה על אובייקט יחיד (Singleton)
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // אם יש אובייקט נוסף, מחק אותו
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(SpawnCharacter), 0f, spawnInterval);
    }

    private void SpawnCharacter()
    {
        int index = Random.Range(0, characters.Length);
        Instantiate(characters[index], spawnPoint.position, Quaternion.identity);
    }

    public void LoseLife()
    {
        Debug.Log("LoseLife called!"); // בדיקת קריאה לפונקציה
        lives--;
        Debug.Log($"Lives left: {lives}");

        if (lives <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        SceneManager.LoadScene("GameOverScene");
    }

    public void ResetGame()
    {
        lives = 3; // איפוס החיים
        InvokeRepeating(nameof(SpawnCharacter), 0f, spawnInterval); // התחלת יצירת דמויות מחדש
        Debug.Log("Game reset successfully!");
    }
}
