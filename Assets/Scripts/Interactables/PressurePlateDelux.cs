using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateDelux : PressurePlate
{
    [SerializeField] protected Material oneColor;
    [SerializeField] protected Material twoColor;
    public bool isOne = true;

    protected override void Start()
    {
        base.Start();
    }
    protected override void OnDown()
    {
        isOne = !isOne;
        plate.GetComponent<MeshRenderer>().material = isOne? oneColor : twoColor;
        base.OnDown();
    }
}
