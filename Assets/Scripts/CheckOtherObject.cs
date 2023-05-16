using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOtherObject : MonoBehaviour
{
    public bool triggered = false;

    [SerializeField] BlockController blockController;

    private void OnTriggerEnter(Collider other)
    {
        triggered = true;
        blockController.UpdateObject();
    }
    private void OnTriggerExit(Collider other)
    {
        triggered = false;
        blockController.UpdateObject();
    }
}
