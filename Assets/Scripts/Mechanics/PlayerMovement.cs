using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody m_Body;

    [SerializeField]
    float m_JumpForce;

    [SerializeField]
    float m_ActionCooldownTime;

    bool m_Cooldown;

    IEnumerator m_ActionCooldown;

    void Start()
    {
        m_Body = GetComponent<Rigidbody>();
        m_ActionCooldown = ActioCooldown();
        m_Cooldown = false;
    }

    public void Jump()
    {
        if (!m_Cooldown)
        {
            return;
        }

        m_Body.velocity = Vector3.up * m_JumpForce;

        StartCoroutine(m_ActionCooldown);
    }

    public void Slide()
    {
        if (!m_Cooldown)
        {
            return;
        }
    }

    public void Hollow()
    {
        if (!m_Cooldown)
        {
            return;
        }
    }

    IEnumerator ActioCooldown()
    {
        m_Cooldown = true;

        yield return new WaitForSeconds(m_ActionCooldownTime);

        m_Cooldown = false;

        yield return null;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Floor>())
        {
            StopCoroutine(m_ActionCooldownTime);
            m_Cooldown = false;
        }
    }
}
