using UnityEngine;

public class WaypointAI : MonoBehaviour
{
    public GameObject player;
    public GameObject[] Waypoints;
    private int index = 0;

    private float speed = 2.5f;
    private float minDistance = 0.5f;
    private float chasePlayerDistance = 5f;


    void Update()
    {
        if (Vector2.Distance(player.transform.position, transform.position) > chasePlayerDistance)
        {
            Patrol();
        }
        else
        {
            MoveAI(player.transform.position);
        }
    }

    void Patrol()
    {
        MoveAI(Waypoints[index].transform.position);
    }

    void MoveAI(Vector2 targetPosition)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
