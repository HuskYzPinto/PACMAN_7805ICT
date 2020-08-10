using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OrangeGhost : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.075f;
    public bool omoved;
    float seed;
    public Transform player;
    Vector2 direction;
    Vector2 destination;
    public LayerMask layer;
    bool gameStarted;
    void Start(){
        destination = transform.position;
        MoveSelection();
        omoved = false;
        Physics2D.IgnoreLayerCollision(8, 8);
        gameStarted = false;
    }

    // Update is called once per frame
    void FixedUpdate(){
        if (!gameStarted && Input.anyKey){
            gameStarted = true;
            omoved = true;
        }
        if (gameStarted){
            if (SceneManager.GetActiveScene().name == "GameOver" || SceneManager.GetActiveScene().name == "Victory"){
                this.enabled = false;
            }           
            destination = transform.position;
            Vector2 pos = Vector2.MoveTowards(transform.position, destination+direction, speed);
            GetComponent<Rigidbody2D>().MovePosition(pos);
        }
            if (!Valid(direction)){
                print ("GO SOMEWHERE ELSE");
                MoveSelection();
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
    
    void MovetoRandom(float dir){
        if (dir<0.5f){
            if (Valid(Vector2.left)){
                direction = Vector2.left;
            }
            else{
                direction = Vector2.right;
            }
        }
        else if (dir < 1.0f){
            if (Valid(Vector2.right)){
                direction = Vector2.right;
            }
            else{
                direction = Vector2.left;
            }
        }
        else if (dir < 1.5f){
            if (Valid(Vector2.up)){
                direction = Vector2.up;
            }
            else{
                direction = Vector2.down;
            }
        }
        else{
            if (Valid(Vector2.down)){
                direction = Vector2.down;
            }
            else{
                direction = Vector2.up;
            }
        }
    }

    void MoveSelection(){
        seed = Random.Range(0.0f, 6.0f);
        if (seed < 2.0f){
            MovetoRandom(seed);
        }
        else{
            MovetoPlayer();
        }
    }
    
    bool Valid(Vector2 direction){
        Vector2 current_position = transform.position;
        RaycastHit2D hit_detection = Physics2D.Linecast(current_position + direction, current_position, layer);
        return (hit_detection.collider.tag == GetComponent<Collider2D>().tag);
    }

}