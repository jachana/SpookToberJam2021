using UnityEngine;

public class PlatformDistanceMove : Platform
{
    [SerializeField]
    float speed;

    [SerializeField]
    Vector3 movement_vector;

    Vector3 initial_position;
    float clock, enhancment_multiplier = 1.2f;

    void Start()
    {
        initial_position = transform.position;
    }

    void Update()
    {
        if (is_active)
        {
            clock += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(transform.position, initial_position + movement_vector * Mathf.Sin(clock), .5f);
        }
    }

    public override void Diminish()
    {
        movement_vector /= enhancment_multiplier;
    }

    public override void Enhance()
    {
        movement_vector *= enhancment_multiplier;
    }
}
