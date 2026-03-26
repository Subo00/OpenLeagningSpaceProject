using UnityEngine;

public abstract class Interactable : MonoBehaviour, IMyUpdate
{

    private PlayerHUD playerHUD = null;

    protected abstract void OnUpdate();
    void IMyUpdate.MyUpdate()
    {
        OnUpdate();
    }
    protected void CommonLogic()
    {
        playerHUD.ShowInteractionOnObject(transform.position);
    }

    protected virtual void Start()
    {
        //Make sure that the gameObject dropPoint is a child of the GO
        //that this script is attached to
        Transform[] temp = gameObject.GetComponentsInChildren<Transform>();
        playerHUD = PlayerHUD.Instance;
    }

    public void OnEntry()
    {
        UpdateManager.Instance.AddUpdatable(this);

    }

    public void OnExit()
    {
        UpdateManager.Instance.RemoveUpdatable(this);
        PlayerHUD.Instance.HideInteraction();
    }
   
}