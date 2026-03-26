using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMaskListener : MonoBehaviour, MaskListener
{
    [SerializeField] private Material redMaterial;
    private Material defaultMaterial;

    private MeshRenderer meshRenderer;
    public void OnMaskChange(Mask mask)
    {
        if(mask == Mask.RED)
        {
            meshRenderer.material = redMaterial;
        }else
        {
            meshRenderer.material = defaultMaterial;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        MaskChanger.Instance.AddListener(this);
        meshRenderer = GetComponent<MeshRenderer>();
        defaultMaterial = meshRenderer.material;
    }
   
}
