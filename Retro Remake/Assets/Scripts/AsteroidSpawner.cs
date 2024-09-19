using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Asteroid asteroidPrefab;

    public float trajectoryVariance = 15.0f;

    public float spawnRate = 2.0f;

    public float spawnDistance = 15.0f;

    public int spawnAmount = 1;

    // Controls repeated spawn of asteroids
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), this.spawnRate, this.spawnRate);
    }

    private void Spawn()
    {
        for (int i = 0; i < this.spawnAmount; i++)
        {
            // Controls where asteroids spawn and in what direction
            Vector3 spawnDirection = Random.insideUnitCircle.normalized * this.spawnDistance;
            Vector3 spawnPoint = this.transform.position + spawnDirection;

            // Controls asteroid rotation
            float variance = Random.Range(-this.trajectoryVariance, this.trajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);

            //Creates asteroid from a class
            Asteroid asteroid = Instantiate(this.asteroidPrefab, spawnPoint, rotation);
            asteroid.size = Random.Range(asteroid.minSize, asteroid.maxSize);
            asteroid.SetTrajectory(rotation * -spawnDirection);
        }

    }
}
