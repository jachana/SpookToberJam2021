using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Platform : MonoBehaviour, IActivate
{
    [SerializeField]
    protected bool is_active;

    public virtual void Activate()
    {
        is_active = true;
    }

    public virtual void ActivateForSeconds(float time_t)
    {
        StartCoroutine(TemporalToggle(time_t));
    }
    public virtual IEnumerator TemporalToggle(float time_t)
    {
        Enhance();
        yield return new WaitForSecondsRealtime(time_t);
        Diminish();
    }

    public virtual void Deactivate()
    {
        is_active = false;
    }

    void OnCollisionExit2D(Collision2D col)
    {

        col.transform.parent = null;

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        col.transform.parent = transform;
    }


    public abstract void Diminish();
    public abstract void Enhance();

    public virtual void Toggle()
    {
        is_active = !is_active;
    }
}
