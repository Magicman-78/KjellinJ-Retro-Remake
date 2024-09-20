using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 500.0f;
    
    public float maxLifetime = 10.0f;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Adds the force and speed of the bullets
    public void Project(Vector2 direction)
    {
        _rigidbody.AddForce(direction * this.speed);

        Destroy(this.gameObject, this.maxLifetime);
    }

    // Destroys bullets when it collides with the anything
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
