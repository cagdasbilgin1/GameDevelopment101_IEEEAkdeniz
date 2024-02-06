using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    MeshRenderer _meshrenderer;
    bool _isPaintedBefore;

    public bool IsPaintedBefore => _isPaintedBefore;

    public Material Material => _meshrenderer.material;

    private void Start()
    {
        _meshrenderer = GetComponent<MeshRenderer>();
    }

    public void Paint(Material mat)
    {
        _meshrenderer.material = mat;
        _isPaintedBefore = true;
    }
}
