using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Pacman : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.4f;
    Vector2 destination = Vector2.zero;
    Vector2 new_destination = Vector2.zero;
    public LayerMask layer;
    void Start()
    {
       destination = transform.position; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 pos = Vector2.MoveTowards(transform.position, destination, speed);
        GetComponent<Rigidbody2D>().MovePosition(pos);
        
        if (Input.GetAxis("Vertical")>0) new_destination = Vector2.up ; SetAnimation(new_destination);
        if (Input.GetAxis("Vertical")<0) new_destination = Vector2.down; SetAnimation(new_destination);
        if (Input.GetAxis("Horizontal")>0) new_destination = Vector2.right; SetAnimation(new_destination);
        if (Input.GetAxis("Horizontal")<0) new_destination = Vector2.left; SetAnimation(new_destination);
        
        if (Valid(new_destination)) destination = (Vector2)transform.position + new_destination;
  

        
    }
    bool Valid(Vector2 direction)
    {
        Vector2 current_position = transform.position;
        RaycastHit2D hit_detection = Physics2D.Linecast(current_position + direction, current_position, layer);
        return (hit_detection.collider == GetComponent<Collider2D>()) ;

    }

    void SetAnimation(Vector2 dest)
    {
        Vector2 direction = dest;
        GetComponent<Animator>().SetFloat("X", direction.x);
        GetComponent<Animator>().SetFloat("Y", direction.y);
    }

}


