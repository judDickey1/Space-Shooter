using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private int _speed = 8;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + .8f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(_speed * Time.deltaTime * Vector3.up);

        if (transform.position.y > 8.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
