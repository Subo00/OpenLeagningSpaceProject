using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Trigger
{

    public override void DoTheThing()
    {
        Destroy(gameObject);
    }
}
