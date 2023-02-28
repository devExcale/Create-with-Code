using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{

    [SerializeField]
    private Camera[] cameras;

    [SerializeField]
    private string changeButton;

    private int _index;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (Camera cam in cameras)
            cam.enabled = false;

        _index = 0;
        cameras[_index].enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Execute method only on Camera Change
        if (!Input.GetButtonDown(changeButton))
            return;
        
        // Disable current camera
        cameras[_index].enabled = false;
        
        // Get camera and enable it
        _index = ++_index % cameras.Length;
        cameras[_index].enabled = true;

    }
}
