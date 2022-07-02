using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{

    [SerializeField] private Unit selectedUnit;
    // Update is called once per frame
    void Update()
    {
        int mouseButton = 0;
        bool leftMouseDown = Input.GetMouseButtonDown(mouseButton);

        if(leftMouseDown)
        {
            selectedUnit.setWalkTarget(MouseWorld.GetPosition());
        }
    }
}
