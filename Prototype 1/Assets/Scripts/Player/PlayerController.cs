using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField]
        private float speed = 5f;

        [SerializeField]
        private float turnSpeed = 0f;

        [SerializeField]
        public ControlsSet controls;

        private float _horizontalInput;
        private float _forwardInput;
    
        private float DeltaSpeed => speed * Time.deltaTime;
        private float DeltaTurnSpeed => turnSpeed * Time.deltaTime;


        private void Update()
        {
            GetInput();
            Move();
        }

        private void GetInput()
        {
            _horizontalInput = Input.GetAxis(controls.HorizontalAxis);
            _forwardInput = Input.GetAxis(controls.VerticalAxis);
        }

        private void Move()
        {
            transform.Translate(_forwardInput * DeltaSpeed * Vector3.forward);
            transform.Rotate(Vector3.up, _horizontalInput * DeltaTurnSpeed);
        }
    }
}
