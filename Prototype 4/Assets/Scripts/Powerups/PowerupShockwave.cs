using System;
using ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Powerups
{
    public class PowerupShockwave : Powerup
    {

        private PowerupShockwaveData _data;

        protected override void OnEnable()
        {
            base.OnEnable();
            _data = (PowerupShockwaveData)Data;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
                DoShockwave();
        }

        private void DoShockwave()
        {
            Vector3 pos = transform.position;
            float distance = 2f;
            int n = 8;

            float randomRotation = Random.Range(0f, 360f);

            for (int i = 0; i < n; i++)
            {
                // Normalise angle so that it starts
                // generating projectiles from the top
                float angle = 360f * i / n + randomRotation;
                float angleRad = (float)(angle * Math.PI / 180d);

                // Rotate clockwise instead of anticlockwise (negative sin/cos)
                float x = pos.x + Mathf.Cos(angleRad) * distance;
                float z = pos.z + Mathf.Sin(angleRad) * distance;
            
                Vector3 projectilePos = new Vector3(x, pos.y, z);
                Quaternion rotation = Quaternion.Euler(0, -angle + 90, 0);

                Instantiate(_data.ProjectilePrefab, projectilePos, rotation).name = "Proj." + i;
            }
        }


    }
}