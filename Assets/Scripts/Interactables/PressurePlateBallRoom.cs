using UnityEngine;

public class PressurePlateBallRoom : PressurePlateDelux
{
    public int index;
    protected override void OnDown()
    {
        Ballroom.Instance.Press(index);
        base.OnDown();
    }
    protected override void Start()
    {
        Ballroom.Instance.Add(this);
        base.Start();
    }
    public void Reset()
    {
        isOne = true;
        plate.GetComponent<MeshRenderer>().material = isOne ? oneColor : twoColor;
    }
}
