using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    private void Update()
    {
        Debug.Log(Input.mousePosition);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit hit);
        Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
    }

}
