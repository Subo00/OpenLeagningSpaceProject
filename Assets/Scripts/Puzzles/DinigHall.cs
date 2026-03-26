using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinigHall : Trigger
{
    [SerializeField] private PressurePlateDelux[] platesON;
    [SerializeField] private PressurePlateDelux[] platesOFF;
    [SerializeField] private GameObject wall;
    public void CheckPlates()
    {
        foreach (var plate in platesON)
        {
            if (plate.isOne) return;
        }

        foreach (var plates in platesOFF)
        {
            if (!plates.isOne) return;
        }

        Debug.Log("WE MADE IT");
        Destroy(wall);
    }

    public override void DoTheThing()
    {
        CheckPlates();
        //base.DoTheOtherThing();
    }

}
