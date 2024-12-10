using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HealthUIManager : MonoBehaviour
{
    public static HealthUIManager Instance;
    public GameObject heartPrefab; // ������ �� ��
    private List<GameObject> hearts = new List<GameObject>(); // ����� ������

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // ���� ����� �������� ���� GameManager
        UpdateHearts(GameManager.Instance.lives);
    }

    public void UpdateHearts(int lives)
    {
        // ����� ����� �� ����
        // ����� �� ���� �� �����
        while (hearts.Count < lives)
        {
            AddHeart();
        }

        while (hearts.Count > lives)
        {
            RemoveHeart();
        }
    }

    private void AddHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab, transform);
        hearts.Add(newHeart);
    }

    private void RemoveHeart()
    {
        if (hearts.Count > 0)
        {
            GameObject heartToRemove = hearts[hearts.Count - 1];
            hearts.Remove(heartToRemove);
            Destroy(heartToRemove);
        }
    }
}
