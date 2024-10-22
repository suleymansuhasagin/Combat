using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    private Vector2 moveDir;
    private Rigidbody2D enemyRB;
    private void Awake() 
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() 
    {
        enemyRB.MovePosition(enemyRB.position + moveDir * moveSpeed * Time.fixedDeltaTime);
    }
    
    public void MoveTo (Vector2 targetPosition)
    {
        moveDir = targetPosition;
    }
}
