using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody m_Body;

    [SerializeField]
    float m_JumpForce;
    
    bool m_IsMoving;

    IEnumerator m_ActionCooldown;

    void Start()
    {
        m_Body = GetComponent<Rigidbody>();
        m_ActionCooldown = null;
    }

    public void Jump()
    {
        if (m_IsMoving)
        {
            return;
        }

        m_Body.velocity = Vector3.up * m_JumpForce;
    }

    public void Slide()
    {
        if (m_IsMoving)
        {
            return;
        }
    }

    public void Hollow()
    {
        if (m_IsMoving)
        {
            return;
        }
    }

}
