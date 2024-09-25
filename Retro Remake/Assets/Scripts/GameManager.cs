using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;

    public ParticleSystem explosion;

    public float respawnTime = 3.0f;

    public float respawnInvulnerabilityTime = 3.0f;

    public int lives = 3;

    public int score = 0;

    public void AsteroidDestroyed(Asteroid asteroid)
    {
        this.explosion.transform.position = asteroid.transform.position;
        this.explosion.Play();

        if (asteroid.size < 0.75) {
            score += 100;
        } else if (asteroid.size < 1.2f) {
            score += 50;
        } else {
            score += 25;
        }
    }

    public void PlayerDied()
    {
        this.explosion.transform.position = this.player.transform.position;
        this.explosion.Play();

        // Subtracts one life if player dies
        this.lives--;

        // Respawns player after the programmed respawnTime (which is 3.0f)
        if (this.lives <= 0) { 
        } else {
            Invoke(nameof(Respawn), this.respawnTime);
        }

    }

    // Respawns player at (0,0) and re-activates player's components
    private void Respawn()
    {
        this.player.transform.position = Vector3.zero;
        this.player.gameObject.layer = LayerMask.NameToLayer("Ignore Collisions");
        this.player.gameObject.SetActive(true);

        Invoke(nameof(TurnOnCollisons), this.respawnInvulnerabilityTime);
    }

    private void TurnOnCollisons()
    {
        this.player.gameObject.layer = LayerMask.NameToLayer("Player");
    }

    private void GameOver()
    {
        this.lives = 3;
        this.score = 0;

        Invoke(nameof(Respawn), this.respawnTime);
    }
}
