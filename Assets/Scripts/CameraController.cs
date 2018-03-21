using UnityEngine;

public class CameraController : MonoBehaviour 
{
    [Header("Target")]
    public Transform Target;
    public Vector3 OffsetFromTarget;
    public float Pitch;
    [Header("Zoom")]
    public float ZoomSpeed = 4f;
    public float MinZoom = 5;
    public float MaxZoom = 15;
    [Header("Rotation")]
    public float YawSpeed = 100f;

    private float m_CurZoom = 10;
    private float m_CurYaw = 0;

    private void Update()
    {
        //Zoom
        m_CurZoom -= Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed;
        m_CurZoom = Mathf.Clamp(m_CurZoom, MinZoom, MaxZoom);

        //Rotation
        m_CurYaw -= Input.GetAxis("Horizontal") * YawSpeed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        //Follow target
        transform.position = Target.position - OffsetFromTarget * m_CurZoom;
        transform.LookAt(Target.position + Vector3.up * Pitch);

        //Rotate around target
        transform.RotateAround(Target.position, Vector3.up, m_CurYaw);
    }
}
