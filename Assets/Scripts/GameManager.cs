using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton ���� ���� �-GameManager
    public GameObject[] characters; // ���� �������� �� ������
    public Transform spawnPoint; // ����� �����
    public float spawnInterval = 5f; // ��� ��� ����� ������
    public int lives = 3; // ���� ����� �������

    private void Awake()
    {
        // ����� �� ������� ���� (Singleton)
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // �� �� ������� ����, ��� ����
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
        Debug.Log("LoseLife called!"); // ����� ����� ��������
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
        lives = 3; // ����� �����
        InvokeRepeating(nameof(SpawnCharacter), 0f, spawnInterval); // ����� ����� ������ ����
        Debug.Log("Game reset successfully!");
    }
}
