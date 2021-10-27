using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IActivate
{
    private Rigidbody2D rigidBody;
    private SpriteRenderer sprite;

    private bool isActive;
    [SerializeField] float activeTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        rigidBody.simulated = false;
        sprite.color = Color.cyan;
        isActive = true;
    }

    public void Deactivate()
    {
        rigidBody.simulated = true;
        sprite.color = Color.yellow;
        isActive = false;
    }

    public void Enhance()
    {
        throw new System.NotImplementedException();
    }

    public void Diminish()
    {
        throw new System.NotImplementedException();
    }

    public void Toggle()
    {
        if(isActive)
        {
            Deactivate();
        }
        else
        {
            Activate();
        }
    }

    public void ActivateForSeconds(float time_t)
    {
        if(!isActive)
            StartCoroutine(TemporalActivation(time_t));
    }

    private IEnumerator TemporalActivation(float time_t)
    {
        Activate();

        yield return new WaitForSeconds(time_t);

        Deactivate();
    }
}
