using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskDisabler : MonoBehaviour
{
    private MaskChanger maskChanger;

    private void Start()
    {
        maskChanger = MaskChanger.Instance;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            maskChanger.SetCanChange(false);
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            maskChanger.SetCanChange(true);
        }
    }
}
