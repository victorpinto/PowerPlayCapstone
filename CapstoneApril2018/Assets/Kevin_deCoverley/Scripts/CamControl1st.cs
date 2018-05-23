using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl1st : MonoBehaviour {

    // Camera
    [SerializeField] private Camera Cam;
    // Camera Settings
    [SerializeField] private float cameraSpeedY = 2.0f;
    [SerializeField] private float cameraSpeedx = 2.0f;
    // Private
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private Transform Trans;

    private void Start () {
        //Error Check
        if (!Cam)
            Debug.LogError("No Camera Found(CamControl1st: " + gameObject.name + ")");

        // Init
        Trans = transform;
	}
	
	// Update is called once per frame
	private void FixedUpdate () {
        yaw = cameraSpeedx * Input.GetAxis("Mouse X");
        pitch = cameraSpeedY * Input.GetAxis("Mouse Y");
        Trans.Rotate(new Vector3(0.0f, 1.0f, 0.0f) * yaw);
        Cam.transform.Rotate(new Vector3(1.0f, 0.0f, 0.0f) * -pitch);
    }
}
