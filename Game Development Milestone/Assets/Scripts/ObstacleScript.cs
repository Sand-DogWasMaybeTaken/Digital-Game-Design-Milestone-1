using Unity.VisualScripting;
using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    //variables//
    public Rigidbody2D rb;
    public float rotationSpeed;
    public GameManager gm;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //rotate the obstacle around the z axis//
        rb.transform.Rotate(0, 0, rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //send a message to the console when the spinner hits something//
        Debug.Log("Hit Detected");
        //detect if the player has touched the spinner, put it back to its original position//
        if (collision.gameObject.CompareTag("Player"))
        {
            //respawn the player//
            gm.RespawnPlayer();
            //Deducts a point from the score//
            gm.score--;
        }
    }
}
