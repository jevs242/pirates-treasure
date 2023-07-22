using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class WaterManager : MonoBehaviour
{
    private MeshFilter _meshFilter;

    // Start is called before the first frame update
    void Start()
    {
        _meshFilter = GetComponent<MeshFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] vertices = _meshFilter.mesh.vertices;

        for(int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = WaveManager.instance.GetWaveHeight(transform.position.x + vertices[i].x);
        }

        _meshFilter.mesh.vertices = vertices;
        _meshFilter.mesh.RecalculateNormals();
    }
}
