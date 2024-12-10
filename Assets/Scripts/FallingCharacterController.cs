using UnityEngine;

public class FallingCharacterController : MonoBehaviour
{
    public float speed = 5f; // מהירות תנועה לצדדים
    private bool hasDecided = false; // בודק אם כבר התקבלה החלטה
    public string characterTag; // תג של הדמות ("King" או "Robber")

    private void Update()
    {
        // אם השחקן עדיין לא החליט
        if (!hasDecided)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveToSide(Vector3.left); // תנועה שמאלה
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveToSide(Vector3.right); // תנועה ימינה
            }
        }
    }

    private void MoveToSide(Vector3 direction)
    {
        transform.position += direction * speed;
        hasDecided = true; // למנוע לחיצות חוזרות
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Triggered with {collision.tag} by {characterTag}");

        if (collision.CompareTag("KingdomZone"))
        {
            if (characterTag == "Robber")
            {
                Debug.Log("Robber entered the Kingdom! Losing a life.");
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.LoseLife();
                }
            }
            else if (characterTag == "King")
            {
                Debug.Log("King entered the Kingdom! All good.");
            }
        }
        else if (collision.CompareTag("DesertZone"))
        {
            if (characterTag == "King")
            {
                Debug.Log("King sent to the Desert! Losing a life.");
                if (GameManager.Instance != null)
                {
                    GameManager.Instance.LoseLife();
                }
            }
            else if (characterTag == "Robber")
            {
                Debug.Log("Robber sent to the Desert! All good.");
            }
        }

        // מחיקת הדמות לאחר שהיא פוגעת באזור
        Destroy(gameObject);
    }
}
