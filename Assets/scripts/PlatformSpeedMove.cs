using System.Collections;
using UnityEngine;

public class PlatformSpeedMove : Platform
{
    [SerializeField]
    float speed;

    [SerializeField]
    Vector3 movement_vector;

    Vector3 initial_position;
    float clock, enhancment_multiplier = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        initial_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_active)
        {
            clock += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(transform.position, initial_position + movement_vector * Mathf.Sin(clock), .5f);
        }
    }

    public override void Enhance()
    {
        speed *= enhancment_multiplier;
    }

    public override void Diminish()
    {
        speed /= enhancment_multiplier;
    }
}
