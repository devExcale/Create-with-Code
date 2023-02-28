using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{

    private float _startingPosition;
    private float _offset;
    
    // Start is called before the first frame update
    void Start()
    {
        _startingPosition = transform.position.x;
        _offset = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if (pos.x < _startingPosition - _offset)
            transform.position = new Vector3(_startingPosition, pos.y, pos.z);
    }
}
