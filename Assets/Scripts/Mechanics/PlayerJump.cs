using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    float m_JumpForce;

    [SerializeField]
    LayerMask m_ActionCollisionLayer;

    PlayerMovement m_PlayerMovement;

    Rigidbody m_Body;

    bool isJumping;

    public void OnEnable()
    {
        m_PlayerMovement = GetComponent<PlayerMovement>();
        m_Body = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        if (m_PlayerMovement.cooldown)
        {
            return;
        }

        m_PlayerMovement.cooldown = true;

        isJumping = true;

        m_Body.velocity = Vector3.up * m_JumpForce;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isJumping && collision.gameObject.GetComponent<Floor>())
        {
            isJumping = false;
            m_PlayerMovement.cooldown = false;
        }
    }
}
