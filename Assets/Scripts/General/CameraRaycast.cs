using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    public float maxDistance = 3f;          // How far the ray can go
    public LayerMask hitLayers;              // Optional: limit what can be hit

    private Interactable current;

    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, hitLayers))
        {
            if (hit.collider.TryGetComponent(out Interactable interactable))
            {
                if (current != interactable)
                {
                    current?.OnExit();   // looked away from old
                    current = interactable;
                    current.OnEntry();      // looking at new
                }
                return;
            }
        }

        if (current != null)
        {
            current.OnExit();
            current = null;
        }
    }
}
