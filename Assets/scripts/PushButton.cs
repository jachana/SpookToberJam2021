using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushButton : MonoBehaviour, IInteractable
{
    [SerializeField] public UnityEvent callOnInteract;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Interact()
    {
        callOnInteract.Invoke();
        StartCoroutine(ChangeVisualAspect());
    }

    private IEnumerator ChangeVisualAspect()
    {
        GetComponent<SpriteRenderer>().color = Color.green;

        yield return new WaitForSeconds(1);

        GetComponent<SpriteRenderer>().color = Color.red;
    }
}