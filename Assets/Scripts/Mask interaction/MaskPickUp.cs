using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskPickUp : PickUp, IMyUpdate
{
    [SerializeField] Mask mask;
    private Vector3 rotationAxis = Vector3.up;
    private float rotationSpeed = 90f; // degrees per second


    public void MyUpdate()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);

    }

    protected override void OnPickUp()
    {
        MaskChanger.Instance.UnlockMask(mask);
        MaskChanger.Instance.ChangeMask(mask);
        UpdateManager.Instance.RemoveUpdatable(this);
    }

    private void Start()
    {
        UpdateManager.Instance.AddUpdatable(this);
    }
}
