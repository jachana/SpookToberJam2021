using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float playerSpeed = 10f;

    [SerializeField] List<Collider2D> interactablesList;

    // Start is called before the first frame update
    void Start()
    {
        interactablesList = new List<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(Input.GetButtonDown("Fire1"))
        {
            foreach(Collider2D interactableObject in interactablesList)
            {
                interactableObject.GetComponent<IInteractable>().Interact();
            }
        }
    }

    private void Move()
    {
        float horizontalDirection = Input.GetAxis("Horizontal");
        transform.Translate(horizontalDirection * playerSpeed * Time.deltaTime, 0, 0);
    }

 
    //called when something enters the trigger
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
}
