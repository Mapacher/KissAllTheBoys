using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//CODIGO REUTILIZABLE PARA MOVER UN OBJETO ENTRE WAYPOINTS
public class waypointFollower : MonoBehaviour
{
    [SerializeField]private GameObject[] waypoints;//para poder pasar los waypoints desded unity, así este código es reutilizable
    private int currentWaypointIndex = 0;

    private float speed = 2f;

    private void Update()
    {
        //si la distancia es mejor que .1 cambia el waypoint hacia el que se mueve
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
