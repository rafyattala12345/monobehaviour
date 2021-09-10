using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("General Setting")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpforce = 200f;

    Rigidbody rigidBody;

    [Space]
    [SerializeField] private bool controlledbymouse;

    Vector3 directionmove;
    float inputx, inputy;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        if (controlledbymouse)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float inputx, inputy;
        if (controlledbymouse)
        {
            inputx = Input.GetAxis("Horizontal");
            inputy = Input.GetAxis("Vertical");

            Vector3 normal = Vector3.zero;
            normal.Normalize();

        }
        else
        {
            inputx = Input.GetAxis("Mouse X");
            inputy = Input.GetAxis("Mouse Y");
        }

        Vector3 camFoward = Camera.main.transform.forward * inputy;
        camFoward.y = 0f;
        Vector3 camRight = Camera.main.transform.right * inputx;

        directionmove = (camFoward + camRight);
        rigidBody.AddForce(directionmove * speed);

        if (Input.GetKeyDown(KeyCode.Space))
            rigidBody.AddForce((Vector3.up * jumpforce));

        rigidBody.AddForce((new Vector3(inputx, 0f, inputy)) * speed);

    }
}
