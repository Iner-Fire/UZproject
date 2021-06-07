using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MovementController : MonoBehaviour
{
    private CollisionTest collisionTest;
    private AIDestinationSetter aisetter;

    void Start()
    {
        
        collisionTest = GetComponent<CollisionTest>();
        aisetter = GetComponent<AIDestinationSetter>();
        collisionTest.enabled = true;
        aisetter.enabled = false;
    }
    void Update()
    {
        /*if (Mathf.Abs(playerPosition.transform.position.x - minoPosition.transform.position.x) < 1 && Mathf.Abs(playerPosition.transform.position.y - minoPosition.transform.position.y) < 1)  #odleglosc od gracza 
        {
            varGameObject.GetComponent<CollisionTest>().enabled = false;
            varGameObject.GetComponent < AIPath(2D, 3D) > ().enabled = true;
            varGameObject.GetComponent < AI Destination Setter(Script)> ().enabled = true;
            TimeLeft = 5;
        }
        else
        {
            TimeLeft -= time.deltatime;
            if (TimeLeft <= 0)
            {
                varGameObject.GetComponent<CollisionTest>().enabled = true;
                varGameObject.GetComponent < AIPath(2D, 3D) > ().enabled = false;
                varGameObject.GetComponent < AI Destination Setter(Script)> ().enabled = false;
            }
        }*/
        if (Input.GetKeyUp(KeyCode.Space))
        {
            aisetter.enabled = !aisetter.enabled;
        }
    }
}
