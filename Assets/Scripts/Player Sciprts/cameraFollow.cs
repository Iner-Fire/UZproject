using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    private Transform player;
    public float oddalonaKamera;




    void Start()
    {
        
        player = (GameObject.FindGameObjectsWithTag("Player")[0].transform);
    }

    private void Update()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / oddalonaKamera);
    }

    void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.x = player.position.x;
        temp.y = player.position.y;
        transform.position = temp;
        
    }

    
}
