using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckRotater : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector3 rotation;

    private void Update()
    {
        transform.Rotate(speed * rotation * Time.deltaTime);
    }
}
