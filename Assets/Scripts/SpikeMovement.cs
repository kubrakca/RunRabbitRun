using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float patrolDistance = 2f;
    private Vector2 startPos;
    private Vector2 endPos;
    private bool movingForward = true;

    void Start()
    {
        startPos = transform.position;
        endPos = startPos + Vector2.right * patrolDistance;
    }

    void Update()
    {
        
        Vector2 targetPos = movingForward ? endPos : startPos;

        
        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        
        if (Vector2.Distance(transform.position, targetPos) < 0.1f)
        {
            movingForward = !movingForward;
        }
    }
}
