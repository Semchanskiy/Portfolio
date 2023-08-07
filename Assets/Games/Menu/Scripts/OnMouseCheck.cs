using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseCheck : MonoBehaviour
{
    [SerializeField] GameObject _sprite;

    void OnMouseEnter()
    {
        _sprite.SetActive(true);
    }
    void OnMouseExit()
    {
        _sprite.SetActive(false);
    }
}
