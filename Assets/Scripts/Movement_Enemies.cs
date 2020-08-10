using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Enemies : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Vector2 direction;
    public LayerMask layer;
    void Start(){
    }

    // Update is called once per frame
    void FixedUpdate(){
        if (!Valid(direction)){

        }
    }
    
    void MovetoPlayer(){
        Vector2 playerpos = player.position;
        Vector2 currentpos = transform.position;
        Vector2 distance = playerpos - currentpos;
        //if x + right x- left  y+ up y- down
        if (distance.x == 0 || (Mathf.Abs(distance.y) <= Mathf.Abs(distance.x))){
            if (distance.y > 0 && Valid(Vector2.up)){
                direction = Vector2.up;
            }
            else{
                direction = Vector2.down;
            }
        }
        else{
            if (distance.x >0 && Valid(Vector2.right)){
                direction = Vector2.right;
            }
            else{
                direction = Vector2.left;
            }
        }
    }
    void MovetoRandom(){

    }

    bool Valid(Vector2 direction){
        Vector2 current_position = transform.position;
        RaycastHit2D hit_detection = Physics2D.Linecast(current_position + direction, current_position, layer);
        return (hit_detection.collider == GetComponent<Collider2D>());
    }

    
}
