using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{

    [SerializeField] private Unit selectedUnit;

    [SerializeField] private LayerMask mouseLayerMask;
    // Update is called once per frame
    void Update()
    {
        int leftMouse = 0;
        int rightMouse = 1;
        bool leftMouseDown = Input.GetMouseButtonDown(leftMouse);
        bool rightMouseDown = Input.GetMouseButtonDown(rightMouse);

        if(leftMouseDown)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, this.mouseLayerMask);
            if(hit.collider != null)
            {
                Unit unit = hit.collider.GetComponent<Unit>();
                if(unit != null)
                {
                    this.selectedUnit = unit;
                }
            }
            else 
            {
                this.selectedUnit = null;
            }
        }

        if(rightMouseDown)
        {
            if(this.selectedUnit != null)
            {
                this.selectedUnit.setWalkTarget(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }
    }
}
