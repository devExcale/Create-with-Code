using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;
    
    private float _verticalInput;

    private float DeltaSpeed => speed * Time.fixedDeltaTime;
    private float DeltaRotationSpeed => rotationSpeed * Time.fixedDeltaTime;

    // Update is called once per frame
    void FixedUpdate()
    {
        GetInput();

        transform.Translate(DeltaSpeed * Vector3.forward);
        transform.Rotate(_verticalInput * DeltaRotationSpeed * Vector3.left);
    }

    private void GetInput()
    {
        _verticalInput = Input.GetAxis("Vertical");
    }
}
