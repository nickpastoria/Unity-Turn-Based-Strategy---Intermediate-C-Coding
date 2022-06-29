using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    public bool drawDebug = false;
    private void Update()
    {
        Debug.Log(Input.mousePosition);

        CreateRay(out Ray ray, out RaycastHit hit);
        DrawRay(ray, hit);
    }

    private void CreateRay(out Ray ray, out RaycastHit hit)
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
    }

    private void DrawRay(Ray ray, RaycastHit hit)
    {
        if (drawDebug)
        {
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
        }
    }

}
