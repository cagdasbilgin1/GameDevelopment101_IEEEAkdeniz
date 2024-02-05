using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDemo : MonoBehaviour
{
    [SerializeField] KeyCode up = KeyCode.W;
    [SerializeField] KeyCode down = KeyCode.S;
    [SerializeField] KeyCode left = KeyCode.A;
    [SerializeField] KeyCode right = KeyCode.D;
    [SerializeField] float moveSpeed;
    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveCube(up, left, down, right);
    }

    void MoveCube(KeyCode up, KeyCode left, KeyCode down, KeyCode right)
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(left))
        {
            horizontal = -1f;
        }
        else if (Input.GetKey(right))
        {
            horizontal = 1f;
        }

        if (Input.GetKey(down))
        {
            vertical = -1f;
        }
        else if (Input.GetKey(up))
        {
            vertical = 1f;
        }

        Vector3 movement = new Vector3(horizontal, vertical, 0) * moveSpeed * Time.deltaTime;
        _rb.AddForce(movement);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter Run");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay Run");

    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit Run");
    }
}
