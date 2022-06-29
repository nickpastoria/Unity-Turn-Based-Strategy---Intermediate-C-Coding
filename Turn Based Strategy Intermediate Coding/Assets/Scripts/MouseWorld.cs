using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    public bool drawDebug = false;
    public LayerMask layerMask;
    private void Update()
    {
        Debug.Log(Input.mousePosition);

        CreateRay(out Ray ray, out RaycastHit hit);
        DrawRay(ray, hit);
        transform.position = hit.point;
    }

    private void CreateRay(out Ray ray, out RaycastHit hit)
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask);
    }

    private void DrawRay(Ray ray, RaycastHit hit)
    {
        if (drawDebug)
        {
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
        }
    }

}
