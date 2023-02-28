using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
// ReSharper disable All

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed;

    [SerializeField]
    private GameBounds bounds;
    private Vector3 _upperBounds;
    private Vector3 _lowerBounds;

    [SerializeField]
    private GameObject projectile;

    [SerializeField]
    private int score = 0;
    [SerializeField]
    private int lives = 3;

    private float DeltaSpeed => speed * Time.deltaTime;

    private float _horizontalInput;
    private float _forwardInput;
    private bool _isShooting;

    private void Awake()
    {
        _upperBounds = bounds.upperBounds;
        _lowerBounds = bounds.lowerBounds;
    }

    void Update()
    {
        GetInput();

        Move();
        BoundPlayer();

        if (_isShooting)
            Shoot();
        
    }

    private void GetInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");
        _isShooting = Input.GetKeyDown(KeyCode.Space);
    }

    private void Move()
    {
        transform.Translate(_horizontalInput * DeltaSpeed * Vector3.right);
        transform.Translate(_forwardInput * DeltaSpeed * Vector3.forward);
    }

    private void BoundPlayer()
    {
        Vector3 pos = transform.position;
        float x = Mathf.Clamp(pos.x, _lowerBounds.x, _upperBounds.x);
        float y = Mathf.Clamp(pos.y, _lowerBounds.y, _upperBounds.y);
        float z = Mathf.Clamp(pos.z, _lowerBounds.z, _upperBounds.z);
        transform.position = new Vector3(x, y, z);
    }

    private void Shoot()
    {
        Transform tran = transform;
        Instantiate(projectile, tran.position, tran.rotation, transform);
    }

    public void AddScore(int score)
    {
        this.score += score;
        Debug.Log("Score: " + this.score);
    }

    public void RemoveLife()
    {
        lives--;
        Debug.Log("Lives: " + lives);

        if (lives <= 0)
            Debug.Log("Game Over");
    }
    
}
