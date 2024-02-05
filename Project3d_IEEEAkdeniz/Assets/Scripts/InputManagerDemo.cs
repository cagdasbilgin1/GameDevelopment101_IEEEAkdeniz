using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerDemo : MonoBehaviour
{
    [SerializeField] GameObject greenCube;
    [SerializeField] GameObject redCube;
    [SerializeField] float moveSpeed;

    private void Update()
    {
        MoveCube(greenCube, KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D);
        MoveCube(redCube, KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow);
    }

    void MoveCube(GameObject cube, KeyCode up, KeyCode left, KeyCode down, KeyCode right)
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(left))
        {
            horizontal = -1f;
        }else if (Input.GetKey(right))
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
        cube.transform.Translate(movement);
    }
}
