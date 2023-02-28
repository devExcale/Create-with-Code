using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerControllerX : MonoBehaviour
{
    
    [SerializeField]
    private GameObject dogPrefab;

    [SerializeField]
    private float fireCooldown;

    private float _lastFire;

    private void OnEnable()
    {
        _lastFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && CanFire())
            Fire();
    }

    private bool CanFire()
    {
        return _lastFire + fireCooldown < Time.time;
    }

    private void Fire()
    {
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        _lastFire = Time.time;
    }
    
}
