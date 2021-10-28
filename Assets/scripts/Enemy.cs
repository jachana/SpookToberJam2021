using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private FieldOfView field_of_view;

    // Start is called before the first frame update
    void Start()
    {
        field_of_view.SetAimDirecion(Vector3.left);
    }

    // Update is called once per frame
    void Update()
    {
        field_of_view.SetOrigin(transform.position);
    }
}
