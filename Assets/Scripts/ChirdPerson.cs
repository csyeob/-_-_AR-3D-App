using UnityEngine;

public class ChirdPerson : MonoBehaviour
{
    public float azimuth;
    public float elevation;
    public float radius;
    public float speed = 0.5f;

    public Camera controllingCamera;

    void Start()
    {
        if (controllingCamera == null)
            controllingCamera = GetComponentInChildren<Camera>();
        var pos = controllingCamera.transform.localPosition;
        radius = pos.magnitude;
        azimuth = Mathf.Atan2(pos.z, pos.x);
        elevation = Mathf.Acos(pos.y / radius);
        UpdateCameraAsCartesian();
    }

    void Update()
    {
        if (!Input.GetButton("Fire2"))
            return;
        azimuth += Input.GetAxisRaw("Mouse X") * speed;
        elevation += Input.GetAxisRaw("Mouse Y") * speed;
        UpdateCameraAsCartesian();
    }

    private void UpdateCameraAsCartesian()
    {
        var t = radius * Mathf.Sin(elevation);
        var x = t * Mathf.Cos(azimuth);
        var y = radius * Mathf.Cos(elevation);
        var z = t * Mathf.Sin(azimuth);
        controllingCamera.transform.localPosition = new Vector3(x, y, z);
        controllingCamera.transform.LookAt(transform);
    }
}
