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

    [SerializeField]
    string m_ActionCollisionLayer;

	[SerializeField]
	AudioClip m_SlideAudioClip;

	AudioSource m_AudioSource;

    Vector3 m_DefaultScale;

    void OnEnable()
    {
        m_PlayerMovement = GetComponent<PlayerMovement>();
        m_DefaultScale = transform.localScale;
		m_AudioSource = this.GetComponent<AudioSource> ();
    }

    public void Slide()
    {
		m_AudioSource.clip = m_SlideAudioClip;
        if (m_PlayerMovement.cooldown)
        {
            return;
        }

        m_PlayerMovement.cooldown = true;

        gameObject.layer = LayerMask.NameToLayer(m_ActionCollisionLayer);

        transform.localScale = new Vector3(m_DefaultScale.x, m_ScaleTarget, m_DefaultScale.z);

		m_AudioSource.Play ();
        StartCoroutine(ScaleTimeout());
    }

    IEnumerator ScaleTimeout()
    {
        yield return new WaitForSeconds(m_ScaleTime);

        transform.localScale = m_DefaultScale;

        m_PlayerMovement.RestoreLayerMask();

        m_PlayerMovement.cooldown = false;

        yield return null;
    }
}
