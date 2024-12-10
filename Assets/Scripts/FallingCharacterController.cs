using UnityEngine;

public class FallingCharacterController : MonoBehaviour
{
    public float speed = 5f; // ������ ����� ������
    private bool hasDecided = false; // ���� �� ��� ������ �����
    public string characterTag; // �� �� ����� ("King" �� "Robber")

    private void Update()
    {
        // �� ����� ����� �� �����
        if (!hasDecided)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                MoveToSide(Vector3.left); // ����� �����
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                MoveToSide(Vector3.right); // ����� �����
            }
        }
    }

    private void MoveToSide(Vector3 direction)
    {
        transform.position += direction * speed;
        hasDecided = true; // ����� ������ ������
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

        // ����� ����� ���� ���� ����� �����
        Destroy(gameObject);
    }
}
