using System;
using UnityEngine;

public class FixedVelocity : MonoBehaviour
{

    [SerializeField]
    private Vector3 speed;

    private PlayerController _playerController;

    private void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {

        if (_playerController.GameOver)
            return;

        float x = speed.x * Time.deltaTime;
        float y = speed.y * Time.deltaTime;
        float z = speed.z * Time.deltaTime;
        transform.Translate(new Vector3(x, y, z));
    }
}
