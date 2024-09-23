using UnityEngine;

public class Player: MonoBehaviour
{
    public Bullet bulletPrefab;

    public float thrustSpeed = 1.0f;
    
    private Rigidbody2D _rigidbody;

    private bool _thrusting;

    private float _turnDirection;
   
    public float turnSpeed = 1.0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Allows player to move the ship and shoot, and controls thrust speed
    private void Update()
    {
        _thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.UpArrow)) {
            _turnDirection = 1.0f;
        } else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            _turnDirection = -1.0f;
        } else {
            _turnDirection = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            Shoot();
        }
    }

    // Programs turn speed and turn direction
    private void FixedUpdate()
    {
        if (_thrusting) {
            _rigidbody.AddForce(this.transform.up * thrustSpeed);
        }
    
        if (_turnDirection != 0.0f) {
            _rigidbody.AddTorque(_turnDirection * turnSpeed * this.turnSpeed);
        }
    }

    // Spawns bullets
    private void Shoot()
    {
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Checks if Player collides with an Asteroid
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            // Sets Player velocity to zero
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = 0.0f;
            
            // Stops all components involved with the player
            this.gameObject.SetActive(false);

            // This is the bad way to do this but the tutorial used it to keep the code simple. Typically degrades game
            FindObjectOfType<GameManager>().PlayerDied();
        }
    }
    
}
