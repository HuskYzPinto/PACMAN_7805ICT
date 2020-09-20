using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Movement_Pacman : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 0.1f;
    private Vector2 destination = Vector2.zero;
    private Vector2 new_destination = Vector2.zero;
    private Vector2 current_destination = Vector2.zero;
    public LayerMask layer;
    void Start()
    {
       current_destination = transform.position; 
       destination = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "GameOver" || SceneManager.GetActiveScene().name == "Victory"){
            this.enabled = false;
        }
        
        Vector2 current_pos = transform.position;
        Vector2 next_position =(current_pos+new_destination);

        destination = Vector2.MoveTowards(transform.position, current_destination, speed);
        GetComponent<Rigidbody2D>().MovePosition(destination);
        //if (Valid(current_destination)){
        //    transform.Translate(current_destination.x*speed, current_destination.y*speed, 0);
            
        //} else{
        //    transform.Translate(0, 0, 0);
            //print ("You're stuck");
        //}
        
        if (Input.GetAxis("Vertical")>0) new_destination = Vector2.up;
        if (Input.GetAxis("Vertical")<0) new_destination = Vector2.down;
        if (Input.GetAxis("Horizontal")>0) new_destination = Vector2.right;
        if (Input.GetAxis("Horizontal")<0) new_destination = Vector2.left;
        if (Valid(new_destination)){
            print ("isthisworkign");
            current_pos = new Vector2(Mathf.Round(current_pos.x), Mathf.Round(current_pos.y));
            destination = current_pos+new_destination;
            SetAnimation(new_destination);
            current_destination = new_destination;
        }
    }
    bool CheckSpot(Vector2 destination)
    {
        Vector2 current_position = transform.position;
        return ((destination.x == current_position.x)&&(destination.y == current_position.y));
    }
    bool Valid(Vector2 direction)
    {
        Vector2 current_position = transform.position;
        print ("Current position"+current_position);
        print ("Direction"+direction);
        print ("next tile:"+(current_position+direction));
        Vector2 next_position =(current_position+direction);

        Collider2D walls = GameObject.FindWithTag("Wall").GetComponent<BoxCollider2D>();
        //return !Physics2D.OverlapBox(next_position, new Vector2(1,1), 0f, layer);
        //return !walls.bounds.Contains(current_position+direction);
        RaycastHit2D hit_detection = Physics2D.Linecast(next_position, current_position, layer);
        //print ("Collided with"+ hit_detection.collider);
        print ("test"+Valid(direction));
        return (hit_detection.collider == !walls);

    }

    void SetAnimation(Vector2 dest)
    {
        Vector2 direction = dest;
        GetComponent<Animator>().SetFloat("X", direction.x);
        GetComponent<Animator>().SetFloat("Y", direction.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("GameOver"));
        }
    }
}


