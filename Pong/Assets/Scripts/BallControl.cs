using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    
    private Rigidbody2D rigidBody2D;
    private Vector2 trajectoryOrigin;
    
    public float xInitialForce;
    public float yInitialForce;


    
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        trajectoryOrigin = transform.position;
        RestartGame();
    }

    
    void Update()
    {
        
    }
    void ResetBall()
    {
        
        transform.position = Vector2.zero;
 
        
        rigidBody2D.velocity = Vector2.zero;
    }
    void PushBall()
    {
        
        float yRandomInitialForce = yInitialForce;

        
        float randomDirection = Random.Range(0, 2);

        
        if (randomDirection < 1.0f)
        {
            
            rigidBody2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce));
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce));
        }
    }
    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }
    void RestartGame()
    {
        
        ResetBall();
 
        
        Invoke("PushBall", 2);
    }
}
