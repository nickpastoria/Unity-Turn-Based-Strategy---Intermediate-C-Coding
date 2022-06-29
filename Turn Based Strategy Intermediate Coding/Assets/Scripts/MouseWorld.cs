using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    public bool drawDebug = false;
    private void Update()
    {
        Debug.Log(Input.mousePosition);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit);
        DrawRay(ray, hit);
    }

    private void DrawRay(Ray ray, RaycastHit hit)
    {
        if (drawDebug)
        {
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
        }
    }

}
