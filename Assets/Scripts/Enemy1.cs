using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private float _moveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
        _moveSpeed = 4.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(_moveSpeed * Time.deltaTime * Vector3.down);
        
        if (transform.position.y < -5.5f)
        {
            transform.position = new Vector3(Random.Range(-9, 9), 7.5f, 0);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Player player = other.gameObject.GetComponent<Player>();

        
        if (other.tag == "Player") 
        {
            
            if (player != null)
            {
                player.Damage();
            }
            
            Destroy(this.gameObject);
        }

        if (other.tag == "Laser")
        {
            
            Destroy(other.gameObject);
            
            Destroy(this.gameObject);
        }
    }
}
