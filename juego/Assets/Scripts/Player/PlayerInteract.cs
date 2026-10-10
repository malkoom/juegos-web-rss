using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private InputReader input;

    [Header("Collider de proximidad")]
    [SerializeField]
    private SphereCollider proximityTrigger;

    [SerializeField]
    private LayerMask mask;

    private bool canInteract;
    private IInteractable interactableObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (proximityTrigger == null)
            Debug.LogError("PlayerInteract: Proximity collider not set");
    }

    void Interact()
    {
        if (!canInteract)
            return;
        Debug.Log("Interacting");
        interactableObject.Interacted();
    }

    void OnEnable()
    {
        input.InteractEvent += Interact;
    }

    void OnDisable()
    {
        input.InteractEvent -= Interact;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactable"))
        {
            // Chaeck de que no se hagan colisiones atravesando paredes
            Vector3 interactableDir = other.transform.position - transform.position;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, interactableDir, out hit, Mathf.Infinity, mask))
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
