using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    private SphereControlScript sphereControlScript;
    private int pickupValue;
    private AudioSource audioSource;

    // Reference to the particle system prefab
    public GameObject particlePrefab;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        pickupValue = 1;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something entered: " + other.ToString() + " at time: " + Time.time.ToString());

        if (other.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Pickups")
            {
                audioSource.Play();
                // Emit particles at the current position before moving
                EmitParticles();

                // Move the pickup to a new random location
                var position = new Vector3(Random.Range(-2.0f, 0.0f), 0.5f, Random.Range(-2.0f, 2.0f));
                transform.position = position;

                // Set pickupValue to a random number between 1 and 5
                pickupValue = Random.Range(1, 6);
            }
        }
    }

    // Method to emit particles at the pickup's position
    private void EmitParticles()
    {

        // Instantiate the particle system at the current position and rotation
        GameObject particles = Instantiate(particlePrefab, transform.position, Quaternion.identity);

        // Access the ParticleSystem component from the instantiated prefab
        ParticleSystem ps = particles.GetComponent<ParticleSystem>();

        // Explicitly play the particle system
        ps.Play();

        // Destroy the particle system after its duration to clean up the scene
        Destroy(particles, 2f); // Adjust the duration to match the particle system's lifetime
    }

    public int GetPickupValue()
    {
        return pickupValue;
    }
}
