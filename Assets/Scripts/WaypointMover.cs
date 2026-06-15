using System.Collections;
//using Unity.Hierarchy;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    public Transform waypointParent;
    public float movespeed;
    public float waittime;
    public bool loopwaypoints = true;
    private Transform[] waypoints;
    private int currentwaypointsindex;
    public bool iswaiting;
    public bool moving = false;
    
    public LayerMask obstacleLayer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        waypoints = new Transform[waypointParent.childCount];
        for (int i = 0; i < waypointParent.childCount; i++)
        {
            waypoints[i] = waypointParent.GetChild(i);
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (iswaiting)
        {
           
            return;
        }
        MovetoWaypoint();

    }

    bool IsPathClear(Vector2 from, Vector2 to)
    {
        Vector2 direction = to - from;
        float distance = direction.magnitude;
        RaycastHit2D hit = Physics2D.Raycast(from, direction.normalized, distance, obstacleLayer);
        return hit.collider == null;
    }

    void MovetoWaypoint()
    {
        Transform target = waypoints[currentwaypointsindex];
        Vector2 direction = (target.position - transform.position).normalized;

        if (!IsPathClear(transform.position, target.position))
        {
            
            return;
        }

        if (direction.magnitude > 0f)
        {
            
        }
        transform.position = Vector2.MoveTowards(transform.position, target.position, movespeed * Time.deltaTime);
        
        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            StartCoroutine(Waitatwaypoint());
        }
    }
    IEnumerator Waitatwaypoint()
    {

        iswaiting = true;
        
        yield return new WaitForSeconds(waittime);
        currentwaypointsindex = loopwaypoints ? (currentwaypointsindex + 1) % waypoints.Length : Mathf.Min(currentwaypointsindex + 1, waypoints.Length - 1);
        iswaiting = false;

    }
}