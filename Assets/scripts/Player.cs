using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float playerSpeed = 10f;

    private void HandleInput()
    {
        float horizontalDirection = Input.GetAxis("Horizontal");
        transform.Translate(horizontalDirection * playerSpeed * Time.deltaTime, 0, 0);
    }

    #region InteractionCode
    [SerializeField] List<Collider2D> interactablesList;

    void Start()
    {
        interactablesList = new List<Collider2D>();
    }

    void Update()
    {
        //HandleInput();
        HandleInteractions();
    }

    private void HandleInteractions()
    {
        if (Input.GetButtonDown("Fire1")||Input.GetKeyDown(KeyCode.E))
        {
            foreach (Collider2D interactableObject in interactablesList)
            {
                interactableObject.GetComponent<IInteractable>().Interact();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //if the object is not already in the list
        if (otherCollider.GetComponent<IInteractable>() != null &&
            !interactablesList.Contains(otherCollider))
        {
            //add the object to the list
            interactablesList.Add(otherCollider);
        }
    }

    //called when something exits the trigger
    void OnTriggerExit2D(Collider2D otherCollider)
    {
        //if the object is in the list
        if (otherCollider.GetComponent<IInteractable>() != null &&
            interactablesList.Contains(otherCollider))
        {
            //remove it from the list
            interactablesList.Remove(otherCollider);
        }
    }
    #endregion


}
