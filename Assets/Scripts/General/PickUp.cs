using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPickUp();
            Destroy(this.gameObject);
        }
    }

    protected virtual void OnPickUp()
    {
        return;
    }
}
