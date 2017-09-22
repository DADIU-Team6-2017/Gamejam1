using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerHollow : MonoBehaviour
{
    PlayerMovement m_PlayerMovement;

    bool m_IsHollow;

    Rigidbody m_Body;

    [SerializeField]
    float m_HollowHoverHeight;

    public void OnEnable()
    {
        m_PlayerMovement = GetComponent<PlayerMovement>();
        m_Body = GetComponent<Rigidbody>();
        m_IsHollow = false;
    }

    public void StartHollow()
    {
        if (m_PlayerMovement.cooldown)
        {
            return;
        }

        m_IsHollow = true;
        StartCoroutine(KeepHollow());
    }

    public void StopHollow()
    {
        m_IsHollow = false;
    }

    IEnumerator KeepHollow()
    {
        while (m_IsHollow)
        {
            Vector3 position = transform.position;

            position.y = m_HollowHoverHeight;

            transform.position = position;

            yield return new WaitForFixedUpdate();
        }

        m_Body.velocity = -Vector3.up * 10f;

        m_PlayerMovement.cooldown = false;

        yield return null;
    }
}
