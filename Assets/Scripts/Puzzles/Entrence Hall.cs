using UnityEngine;

public class EntrenceHall : MonoBehaviour, IMyUpdate
{
    [SerializeField] private Rottator[] rotators;
    [SerializeField] private Trigger door;

    private void Start()
    {
        if (UpdateManager.Instance == null) Debug.Log("KAKO?!");
        UpdateManager.Instance.AddUpdatable(this);
    }
    public void MyUpdate()
    {
        foreach (var rotator in rotators)
        {
            if (rotator.state != State.SOUTH) return;
        }

        door.DoTheThing();
        UpdateManager.Instance.RemoveUpdatable(this);
    }
}
