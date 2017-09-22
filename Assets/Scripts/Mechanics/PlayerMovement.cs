using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]
    public bool cooldown;

    LayerMask m_DefaultLayerMask;

    void Start()
    {
        cooldown = false;
        m_DefaultLayerMask = gameObject.layer;
    }

    public void RestoreLayerMask()
    {
        gameObject.layer = m_DefaultLayerMask.value;
    }
}
