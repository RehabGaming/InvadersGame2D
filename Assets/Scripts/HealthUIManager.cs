using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HealthUIManager : MonoBehaviour
{
    public static HealthUIManager Instance;
    public GameObject heartPrefab; // פריפאב של לב
    private List<GameObject> hearts = new List<GameObject>(); // רשימת הלבבות

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
        // קבלת החיים הראשונים מתוך GameManager
        UpdateHearts(GameManager.Instance.lives);
    }

    public void UpdateHearts(int lives)
    {
        // עדכון החיים על המסך
        // הוספה או הסרה של לבבות
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
