using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballroom : Trigger
{
    static public Ballroom Instance;

    private List<PressurePlateBallRoom> plates;

    public GameObject objectToSpawn;

    public int[] correctOrder;
    int index = 0;

    private void Awake()
    {
        Instance = this;
        plates = new List<PressurePlateBallRoom>();
    }


    public void Add(PressurePlateBallRoom plate)
    { plates.Add(plate); }

    public void Press(int plateId)
    {
        if (plateId == correctOrder[index])
        {
            index++;
            if (index == correctOrder.Length)
            {
                Debug.Log("Sequence correct!");
                objectToSpawn.SetActive(true);
                index = 0;
            }
        }
        else
        {
            index = 0;
        }
    }

    public void Reset()
    {
        index = 0; // reset on wrong press

        foreach (PressurePlateBallRoom plate in plates)
        {
            plate.Reset();
        }
    }


    public override void DoTheThing()
    {
        Reset();
    }
}
