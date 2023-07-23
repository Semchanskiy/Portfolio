using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    private PlatformerPlayer Player;
    void Start()
    {
        FindPlayer();
    }

    public void FindPlayer()
    {
        Player = FindObjectOfType<PlatformerPlayer>();
        transform.position = new Vector3 (Player.transform.position.x , Player.transform.position.y, -10);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (Player.transform.position.x, Player.transform.position.y, -10 );
    }
}
