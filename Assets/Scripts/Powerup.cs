using UnityEngine;

public class Powerup : MonoBehaviour
{

    [SerializeField]
    private int _moveSpeed = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move down at speed of 3
        transform.Translate(_moveSpeed * Time.deltaTime * Vector3.down);
        //leave screen, destroy object
        if (transform.position.y < -6f)
        {
            Destroy(this.gameObject);
        }
    }

    //check for collision
    private void OnTriggerEnter2D(Collider2D other)
    {

        Player player = other.gameObject.GetComponent<Player>();


        if (other.tag == "Player")
        {

            if (player != null)
            {
                //call method from player to set tripleshot to true
                Destroy(this.gameObject);
            }

            
        }

        
    }
}
