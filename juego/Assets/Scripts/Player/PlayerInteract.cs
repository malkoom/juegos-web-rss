using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private InputReader input;

    [Header("Collider de proximidad")]
    [SerializeField]
    private SphereCollider proximityTrigger;

    private bool canInteract;
    private IInteractable interactableObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (proximityTrigger == null)
            Debug.LogError("PlayerInteract: Proximity collider not set");
    }

    bool Interact()
    {
        if (!canInteract)
            return false;

        interactableObject.Interacted();

        return true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            // Chaeck de que no se hagan colisiones atravesando paredes
            Vector3 interactableDir = other.transform.position - transform.position;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, interactableDir, out hit, Mathf.Infinity))
            {
                if (hit.transform.CompareTag("Interactable"))
                {
                    Debug.Log("Can interact with " + hit.transform.gameObject.name);
                    canInteract = true;
                    interactableObject = hit.transform.gameObject.GetComponent<IInteractable>();
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            canInteract = false;
            interactableObject = null;
        }
    }
}
