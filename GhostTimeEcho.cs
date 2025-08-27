using System.Collections.Generic;
using UnityEngine;

public class GhostTimeEcho : MonoBehaviour
{
    public Transform player;           // Reference to the player
    public float delaySeconds = 2f;    // How long the ghost lags behind
    public float recordInterval = 0.05f; // How often we record the player’s position

    private Queue<Vector3> positionHistory = new Queue<Vector3>();
    private float recordTimer = 0f;
    private float delayTimer = 0f;

    private void Update()
    {
        if (player == null) return;

        // Record player positions at fixed intervals
        recordTimer += Time.deltaTime;
        if (recordTimer >= recordInterval)
        {
            positionHistory.Enqueue(player.position);
            recordTimer = 0f;
        }

        // Wait until we have enough history to match the delay
        delayTimer += Time.deltaTime;
        if (delayTimer >= delaySeconds && positionHistory.Count > 0)
        {
            Vector3 targetPosition = positionHistory.Dequeue();
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5f);

        }
    }
}
