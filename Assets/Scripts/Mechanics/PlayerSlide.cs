using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerSlide : MonoBehaviour
{
    PlayerMovement m_PlayerMovement;

    [SerializeField]
    float m_ScaleTarget;

    [SerializeField]
    float m_ScaleTime;

    Vector3 m_DefaultScale;

    void OnEnable()
    {
        m_PlayerMovement = GetComponent<PlayerMovement>();
        m_DefaultScale = transform.localScale;
    }

    public void Slide()
    {
        if (m_PlayerMovement.cooldown)
        {
            return;
        }

        m_PlayerMovement.cooldown = true;

        transform.localScale = new Vector3(m_DefaultScale.x, m_ScaleTarget, m_DefaultScale.z);

        StartCoroutine(ScaleTimeout());
    }

    IEnumerator ScaleTimeout()
    {
        yield return new WaitForSeconds(m_ScaleTime);

        transform.localScale = m_DefaultScale;
        m_PlayerMovement.cooldown = false;

        yield return null;
    }
}
