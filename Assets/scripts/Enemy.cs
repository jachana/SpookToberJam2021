using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private FieldOfView field_of_view;
    [SerializeField] private List<PatrolPoint> patrol_points;
    [SerializeField] private float speed = 1f;

    private int current_patrol_point = 0;
    private bool is_idle = false;
    private SpriteRenderer sprite;

    [System.Serializable]
    public struct PatrolPoint
    {
        public Vector2 destination;
        public float idle_time_after_arrival;
        public Vector2 facing_direction;
    }

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();

        if(patrol_points.Count == 0)
        {
            PatrolPoint currentPoint = new PatrolPoint();
            currentPoint.destination = transform.position;
            currentPoint.facing_direction = Vector2.right;

            patrol_points.Add(currentPoint);
        }

        FaceDirection(patrol_points[current_patrol_point].facing_direction);
    }

    // Update is called once per frame
    void Update()
    {
        field_of_view.SetOrigin(transform.position);

        Patrol();
    }

    private void Patrol()
    {
        if (!is_idle)
        {
            Move(speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, patrol_points[current_patrol_point].destination) == 0)
            {
                is_idle = true;
                StartCoroutine(WaitForNextPoint());
            }

        }
    }

    private void FaceDirection(Vector2 direction)
    {
        if(direction.x > 0)
        {
            sprite.flipX = false;
            field_of_view.SetAimDirecion(Vector2.right);
        }
        else
        {
            sprite.flipX = true;
            field_of_view.SetAimDirecion(Vector2.left);
        }
    }

    private void Move(float distance)
    {
        transform.position = Vector3.MoveTowards(transform.position, patrol_points[current_patrol_point].destination, distance);
        Vector2 direction = new Vector2(patrol_points[current_patrol_point].destination.x - transform.position.x, 0);
        FaceDirection(direction);
    }

    private IEnumerator WaitForNextPoint()
    {
        FaceDirection(patrol_points[current_patrol_point].facing_direction);
        yield return new WaitForSeconds(patrol_points[current_patrol_point].idle_time_after_arrival);

        current_patrol_point = (current_patrol_point + 1) % patrol_points.Count;
        is_idle = false;
    }
}
