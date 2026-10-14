using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // variables //
   public Rigidbody2D rb;
    public float moveSpeed = 5f;
    private Vector2 movedirection;
    public InputActionReference move;
    public SpriteRenderer color;
    public GameManager gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the Rigidbody2D of the object //
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //add the direction of the movement from the reference of the input manager//
        movedirection = move.action.ReadValue<Vector2>();
    }

    //fixed update is called once every physics frame //
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(x: movedirection.x * moveSpeed, y: movedirection.y * moveSpeed);
    }
    //on collision change the color of the player by a random color//
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //send a debug message to the console when the player collides with an object//
        Debug.Log("hit detected");
        changeColor();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //destroy the collectable when the player collides with it//
        Destroy(collision.gameObject);
        //increase the score by 1//
        gm.score += 1;
        changeColor();
        //call the respawn function from the game manager to spawn a new collectable//
        gm.Respawn();
    }
    private void changeColor()
    {
        //randomly change the color of the player//
        color.color = Random.ColorHSV();
    }
}
