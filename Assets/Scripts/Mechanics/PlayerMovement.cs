using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]
    public bool cooldown;

    void Start()
    {
        cooldown = false;
    }
}
