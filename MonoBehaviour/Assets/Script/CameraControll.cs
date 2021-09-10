using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Zooming Setting")]
    [SerializeField] float minZoomRange = 0.75f;
    [SerializeField] float maxZoomRange = 2.5f;

    GameObject m_targetedLook;
    Vector3 CameraOffset;

    Vector3 smootVelocity;
    Vector3 smootVeloLook;
    Vector2 zoomValue;


    void Start()
    {
        m_targetedLook = GameObject.FindGameObjectWithTag("Player");

        CameraOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        zoomValue += -Input.mouseScrollDelta;
        zoomValue.y = Mathf.Clamp(zoomValue.y, minZoomRange, maxZoomRange);

        Vector3 camOffset = m_targetedLook.transform.position + (CameraOffset * zoomValue.y);
        transform.position = Vector3.SmoothDamp(transform.position, camOffset, ref smootVelocity, 0.25f, 65, Time.unscaledDeltaTime);

        Vector3 directionToLook = (m_targetedLook.transform.position - transform.position).normalized;
        Quaternion eulerLook = Quaternion.LookRotation(Vector3.SmoothDamp(transform.forward, directionToLook, ref smootVeloLook, 0.5f, 65, Time.unscaledDeltaTime));
        transform.rotation = eulerLook;
    }
}
