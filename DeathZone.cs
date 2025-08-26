using UnityEngine;
using TMPro;

public class DeathZone : MonoBehaviour
{
    [Header("UI")]
    public GameObject deathText; // GameObject, not TMP component

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Enable the DeathText GameObject
            if (deathText != null)
                deathText.SetActive(true);

            // Reset player position (optional)
            other.transform.position = Vector3.zero;
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
                rb.linearVelocity = Vector2.zero;
        }
    }
}

