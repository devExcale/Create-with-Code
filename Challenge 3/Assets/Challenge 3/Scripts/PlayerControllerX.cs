using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{

    [SerializeField]
    private float floatForce;
    [SerializeField]
    private float gravityModifier = 1.5f;
    
    [SerializeField]
    private ParticleSystem explosionParticle;
    [SerializeField]
    private ParticleSystem fireworksParticle;
    
    [SerializeField]
    private AudioClip moneySound;
    [SerializeField]
    private AudioClip explodeSound;
    [SerializeField]
    private AudioClip boingSound;

    private Rigidbody _rigidbody;
    private AudioSource _audioSource;
    
    public bool GameOver { get; private set; }


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();

        // Apply a small upward force at the start of the game
        _rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
        
        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        Vector3 pos = transform.position;
        if (pos.y > 14f)
            transform.position = new Vector3(pos.x, 14, pos.z);
        else if (pos.y < 1.5f)
        {
            transform.position = new Vector3(pos.x, 1.5f, pos.z);
            _rigidbody.AddForce(20  * Vector3.up, ForceMode.Impulse);
            _audioSource.PlayOneShot(boingSound);
        }
        
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !GameOver)
            _rigidbody.AddForce(Vector3.up * floatForce);
    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            // if player collides with bomb, explode and set gameOver to true
            case "Bomb":
                explosionParticle.Play();
                _audioSource.PlayOneShot(explodeSound, 1.0f);
                GameOver = true;
                Debug.Log("Game Over!");
                Destroy(other.gameObject);
                break;
            
            // if player collides with money, fireworks
            case "Money":
                fireworksParticle.Play();
                _audioSource.PlayOneShot(moneySound, 1.0f);
                Destroy(other.gameObject);
                break;
        }
    }

}
