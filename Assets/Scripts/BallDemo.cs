using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallDemo : MonoBehaviour
{
    [SerializeField] KeyCode up = KeyCode.W;
    [SerializeField] KeyCode down = KeyCode.S;
    [SerializeField] KeyCode left = KeyCode.A;
    [SerializeField] KeyCode right = KeyCode.D;
    [SerializeField] float moveSpeed;
    [SerializeField] GameManager gameManager;


    Rigidbody _rb;
    Material _material;

    public Material Material => _material;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _material = GetComponent<MeshRenderer>().material;
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

        Vector3 movement = new Vector3(horizontal, 0f, vertical) * moveSpeed * Time.deltaTime;
        _rb.AddForce(movement);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Cube>(out var cube))
        {
            if (cube.Material.color.CompareRGB(_material.color)) return;

            gameManager.UpdateColorCount(_material, cube.IsPaintedBefore);
            cube.Paint(_material);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GameArea"))
        {
            gameManager.EliminateBall(this);
        }
    }
}
