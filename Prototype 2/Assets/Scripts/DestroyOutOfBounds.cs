using System;
using ScriptableObjects;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    [SerializeField]
    private GameBounds bounds;

    private Vector3 _upperBounds;
    private Vector3 _lowerBounds;

    private void Awake()
    {
        _upperBounds = bounds.upperBounds;
        _lowerBounds = bounds.lowerBounds;
    }

    private void Update()
    {
        if (!OutOfBounds())
            return;
            
        Destroy(gameObject);

        if (CompareTag("Animal"))
            GameObject.Find("Player")?.GetComponent<PlayerController>()?.RemoveLife();
    }

    private bool OutOfBounds()
    {
        Vector3 pos = transform.position;
        return pos.x < _lowerBounds.x || pos.x > _upperBounds.x ||
               pos.y < _lowerBounds.y || pos.y > _upperBounds.y ||
               pos.z < _lowerBounds.z || pos.z > _upperBounds.z;
    }
    
}
