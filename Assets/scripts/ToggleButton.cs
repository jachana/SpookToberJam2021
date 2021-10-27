using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleButton : MonoBehaviour, IInteractable
{

    bool isActive = false;

    [SerializeField] public UnityEvent callOnInteract;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Interact()
    {
        if (!isActive)
        {
            Activate();
        }
        else
        {
            Deactivate();
        }
        isActive = !isActive;
    }

    private void Activate()
    {
        callOnInteract.Invoke();
        GetComponent<SpriteRenderer>().color = Color.green;
        transform.parent.transform.rotation = Quaternion.Euler(0, 0, 135f);
    }

    private void Deactivate()
    {
        callOnInteract.Invoke();
        GetComponent<SpriteRenderer>().color = Color.red;
        transform.parent.transform.rotation = Quaternion.Euler(0, 0, 45f);
    }

}
