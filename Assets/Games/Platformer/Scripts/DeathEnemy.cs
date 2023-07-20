using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("1");
        if (collision.gameObject.tag == ("Enemy"))
        {
            Debug.Log("2");
            collision.gameObject.SetActive(false);
        }
    }
}
