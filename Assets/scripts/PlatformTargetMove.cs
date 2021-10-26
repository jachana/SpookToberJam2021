using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTargetMove : Platform
{
    [SerializeField]
    float speed = 1;

    [SerializeField]
    Transform desired_position;
    Vector3 starting_position, target_position;

    public override void Diminish()
    {
        target_position = starting_position;
    }

    public override void Enhance()
    {
        target_position = desired_position.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        starting_position = transform.position;
        target_position = starting_position;
    }

    // Update is called once per frame
    void Update()
    {
        if (is_active)
        {
            transform.position = Vector3.Lerp(transform.position, target_position, Time.deltaTime * speed);
        }
    }
}
