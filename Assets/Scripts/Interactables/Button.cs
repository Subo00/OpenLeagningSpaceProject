using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{
    [SerializeField] private Trigger trigger;
    private float timer = 0f;
    private float delay = 1f;
    public Vector3 startingPos;
    public Vector3 endingPos;
    protected override void OnUpdate()
    {
        CommonLogic();
        timer += Time.deltaTime;

        if (Input.GetKey(KeyCode.E) && timer >= delay)
        {
            timer = 0f;
            if(trigger != null) trigger.DoTheThing();
        }

    }
    protected override void Start()
    {
        startingPos = transform.position;
        endingPos = startingPos;
        endingPos.y -= 0.05f;
        base.Start();
    }

}
