using Patterns.ServiceLocator;
using UnityEngine;

public class InteractableBox : MonoBehaviour, IInteractable
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() { }

    public void Interacted()
    {
        Debug.Log("Interacted with box");
        ServiceLocator.Instance.GetService<DialogManager>().StartDialog("D1");
    }
}
