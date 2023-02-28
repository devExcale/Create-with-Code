using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    private PlayerControllerX _playerControllerScript;
    private float _leftBound = -10;

    // Start is called before the first frame update
    void Start()
    {
        _playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerControllerScript.GameOver)
            return;

        // If game is not over, move to the left
        transform.Translate(speed * Time.deltaTime * Vector3.left, Space.World);

        // If object goes off screen that is NOT the background, destroy it
        if (transform.position.x < _leftBound && !gameObject.CompareTag("Background"))
            Destroy(gameObject);
    }
}
