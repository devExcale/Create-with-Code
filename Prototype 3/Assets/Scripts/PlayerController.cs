using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{

    private Rigidbody _rigidbody;
    private Animator _animator;
    private AudioSource _audioSource;

    [SerializeField]
    private float jumpForce = 10f;
    [SerializeField]
    private float gravityMultiplier = 1f;
    
    [SerializeField]
    private ParticleSystem collisionParticles;
    [SerializeField]
    private ParticleSystem runningParticles;
    
    [SerializeField]
    private AudioClip jumpSound;
    [SerializeField]
    private AudioClip collisionSound;

    private static readonly int JumpTrig = Animator.StringToHash("Jump_trig");
    private static readonly int DeathB = Animator.StringToHash("Death_b");
    private static readonly int DeathTypeINT = Animator.StringToHash("DeathType_int");

    public bool OnGround { get; private set; }
    public bool GameOver { get; private set; }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityMultiplier;
    }

    private void Update()
    {

        if (GameOver)
            return;

        if (OnGround && Input.GetKeyDown(KeyCode.Space))
            Jump();

    }

    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            
            case "Ground":
                OnGround = true;
                if (!GameOver)
                    runningParticles.Play();
                break;
            
            case "Obstacle":
                OnGameOver();
                break;
        }
    }

    private void OnGameOver()
    {
        Debug.Log("Game Over");
        GameOver = true;
        _animator.SetBool(DeathB, true);
        _animator.SetInteger(DeathTypeINT, 1);
        collisionParticles.Play();
        runningParticles.Stop();
        _audioSource.PlayOneShot(collisionSound);
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
            OnGround = false;
    }

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        _animator.SetTrigger(JumpTrig);
        runningParticles.Stop();
        _audioSource.PlayOneShot(jumpSound);
    }
    
}
