using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public virtual void DoTheThing()
    {
        Debug.Log("I DID A THING!"); //add a thing to do (LOL)

    }

    public virtual void DoTheOtherThing()
    {
        Debug.Log("I DID ANOTHER THING!");
    }
}
