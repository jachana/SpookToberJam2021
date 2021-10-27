using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] List<Collider2D> _interactables_list;

    void Start()
    {
        _interactables_list = new List<Collider2D>();
    }

    void Update()
    {
        HandleInteractions();
    }

    private void HandleInteractions()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.E))
        {
            foreach (Collider2D interactableObject in _interactables_list)
            {
                interactableObject.GetComponent<IInteractable>().Interact();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //if the object is not already in the list
        if (otherCollider.GetComponent<IInteractable>() != null &&
            !_interactables_list.Contains(otherCollider))
        {
            //add the object to the list
            _interactables_list.Add(otherCollider);
        }
    }

    //called when something exits the trigger
    void OnTriggerExit2D(Collider2D otherCollider)
    {
        //if the object is in the list
        if (otherCollider.GetComponent<IInteractable>() != null &&
            _interactables_list.Contains(otherCollider))
        {
            //remove it from the list
            _interactables_list.Remove(otherCollider);
        }
    }


}
