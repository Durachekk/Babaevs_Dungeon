using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockClick : MonoBehaviour
{
    private Camera myCam;

    public LayerMask clickable;
    public LayerMask ground;

    private void Start()
    {
        myCam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
            {
                //if we hit a clickble object
                BlockSelection.Instance.ClickSelect(hit.collider.gameObject);
            }
            else
            {
                //if we dont
                BlockSelection.Instance.DeselectAll();
            }
        }
    }
}
