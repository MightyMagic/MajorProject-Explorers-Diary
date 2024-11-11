using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningParticles : MonoBehaviour
{
    public Rigidbody2D rb;                      // The Rigidbody component
    public ParticleSystem sandParticles;     // The Particle System to play
    public float raycastDistance = 1f;        // Distance for the ground check
    public LayerMask groundLayer;             // Layer mask for what is considered ground

    [SerializeField] AudioSource playerSource;
    [SerializeField] AudioClip runClip;

    private void Start()
    {
        sandParticles.Stop();
    }

    void Update()
    {
        // Check if the Rigidbody's x speed is greater than 0
        bool isMoving = Mathf.Abs(rb.linearVelocity.x) > 1f;

        // Check if the character is grounded using a Raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, groundLayer); 
        bool isGrounded = hit.collider != null;

        // Play or stop the particle system based on the checks
        if (isMoving && isGrounded)
        {
            if (!sandParticles.isPlaying)
            {
                sandParticles.Play();

                playerSource.clip = runClip;
                playerSource.Play();
            }
        }
        else
        {
            if (sandParticles.isPlaying)
            {
                sandParticles.Stop();

                playerSource.Stop();
            }
        }
    }
}
