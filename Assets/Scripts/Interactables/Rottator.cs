using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State { SOUTH, WEST, NORTH, EAST };


public class Rottator : Trigger
{
    public State state;

    protected virtual void Start()
    {
        transform.Rotate(0f, (int)state * 90f, 0f);
    }
    public override void DoTheThing()
    {
        switch(state)
        {
            case State.NORTH:
                state = State.EAST;
                break;
            case State.SOUTH:
                state = State.WEST;
                break;
            case State.WEST:
                state = State.NORTH;
                break;
            case State.EAST:
                state = State.SOUTH;
                break;
        }
        transform.Rotate(0f, 90f, 0f);
    }

    public override void DoTheOtherThing()
    {
        transform.Rotate(0f, -90f, 0f);
    }
}
