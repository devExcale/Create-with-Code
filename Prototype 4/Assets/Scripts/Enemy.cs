using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float speed;

    private Rigidbody _rigidbody;
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = _player.transform.position - transform.position;
        direction = new Vector3(direction.x, 0, direction.z);
        
        _rigidbody.AddForce(speed * direction.normalized);
    }
}
