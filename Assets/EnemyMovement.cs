using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

       
        
    }

    private void FixedUpdate()
    {
        if (rb.position.x > 50)
        {
            moveSpeed *= -1;
        }
        else if(rb.position.x < -45 && moveSpeed < 0) {
            
            moveSpeed *= -1;
            

        
        }

        rb.velocity = new Vector2(moveSpeed,rb.velocity.y);
       
        
    }
}
