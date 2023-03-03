using System;
using ScriptableObjects;
using UnityEngine;

namespace Powerups
{
    public class PowerupSmash : Powerup
    {

        private PowerupSmashData _data;
        private Rigidbody _rigidbody;
        
        [SerializeField]
        private bool _onGround;
        private bool _active;

        private int _ignoreRaycastMask;

        private void Awake()
        {
            _ignoreRaycastMask = ~LayerMask.GetMask("Ignore Raycast");
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            _rigidbody = GetComponent<Rigidbody>();
            _data = (PowerupSmashData)Data;
        }

        private void Update()
        {
            // Guard Clause: continue only on LeftShift and when on ground
            if (!_onGround || !Input.GetKeyDown(KeyCode.LeftShift))
                return;

            _active = true;
            
            _rigidbody.AddForce(6 * Vector3.up, ForceMode.Impulse);
            
        }

        private void FixedUpdate()
        {
            // Guard Clause: continue only when active
            if (!_active)
                return;

            // Accelerate down
            if (_rigidbody.velocity.y < 0f)
                _rigidbody.AddForce(Vector3.down, ForceMode.Impulse);
        }

        private void Smash()
        {
            Debug.Log("Smash");
            
            // Find all objects in smash radius
            Vector3 pos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(pos, _data.Radius, _ignoreRaycastMask);
            
            Debug.Log($"Found {colliders.Length} colliders");
            
            foreach (Collider collider in colliders)
            {
                // Ignore objects without physics and player
                Rigidbody otherRb = collider.attachedRigidbody;
                if (otherRb == null || otherRb == _rigidbody)
                    continue;

                Vector3 distance = collider.transform.position - pos;
                float strength = distance.magnitude / _data.Radius;
                
                Debug.Log($"Distance: {distance}");
                Debug.Log($"Strength: {strength}");

                otherRb.AddForce(_data.Intensity * strength * distance.normalized, ForceMode.Impulse);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                if (_active)
                {
                    Smash();
                }
                
                _onGround = true;
                _active = false;
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _onGround = true;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _onGround = false;
            }
        }
    }
}