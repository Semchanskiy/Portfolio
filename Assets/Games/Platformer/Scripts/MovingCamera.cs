using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    void Start()
    {
        transform.position = new Vector3 (Player.transform.position.x , Player.transform.position.y, -10);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (Player.transform.position.x, Player.transform.position.y, -10 );
    }
}
