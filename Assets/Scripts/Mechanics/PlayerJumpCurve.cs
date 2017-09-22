using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerJumpCurve : MonoBehaviour
{
    [SerializeField]
    AnimationCurve m_JumpTrajectory;

	[SerializeField]
	AudioClip m_JumpAudioClip;

    [SerializeField]
    float m_JumpTime = 1f;

    [SerializeField]
    float m_JumpScale = 1f;

    [SerializeField]
    string m_ActionCollisionLayer;

    PlayerMovement m_PlayerMovement;
	AudioSource m_AudioSource;

    public void OnEnable()
    {
        m_PlayerMovement = GetComponent<PlayerMovement>();
		m_AudioSource = GetComponent<AudioSource> ();
    }

    public void Jump()
    {
		m_AudioSource.clip = m_JumpAudioClip;
        if (m_PlayerMovement.cooldown)
        {
            return;
        }

        m_PlayerMovement.cooldown = true;

        gameObject.layer = LayerMask.NameToLayer(m_ActionCollisionLayer);

        m_PlayerMovement.TriggerAnimation(PlayerMovement.AnimationConditions.jump);

		m_AudioSource.Play ();
        StartCoroutine(JumpFollowCurve());
    }

    IEnumerator JumpFollowCurve()
    {
        float jumpProgress = 0f;
        float restingPosition = transform.position.y;

        Vector3 position = transform.position;

        while (jumpProgress < 1f)
        {
            Vector3 jumpPosition = position;

            jumpPosition.y += m_JumpTrajectory.Evaluate(jumpProgress) * m_JumpScale;

            transform.position = jumpPosition;

            jumpProgress += Time.deltaTime / m_JumpTime;

            yield return new WaitForFixedUpdate();
        }

        transform.position = position;

        m_PlayerMovement.RestoreLayerMask();

        m_PlayerMovement.cooldown = false;

        yield return null;
    }
}
