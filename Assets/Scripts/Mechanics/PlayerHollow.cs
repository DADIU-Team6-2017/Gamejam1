using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerHollow : MonoBehaviour
{
    [SerializeField]
    float m_HollowHoverHeight;

    [SerializeField]
    AnimationCurve m_JumpTrajectory;

    [SerializeField]
    float m_JumpTime = 1f;

    [SerializeField]
    string m_ActionCollisionLayer;

	[SerializeField]
	AudioClip m_HollowAudioClip;

	AudioSource m_AudioSource;

    PlayerMovement m_PlayerMovement;

    bool m_IsHollow;

    Rigidbody m_Body;

    bool m_IsJumping;

    public void OnEnable()
    {
        m_PlayerMovement = GetComponent<PlayerMovement>();
        m_Body = GetComponent<Rigidbody>();
        m_IsHollow = false;
		m_AudioSource = GetComponent<AudioSource> ();
    }

    public void StartHollow()
    {
		m_AudioSource.clip = m_HollowAudioClip;
        if (m_PlayerMovement.cooldown)
        {
            return;
        }

        m_IsJumping = true;

        m_PlayerMovement.cooldown = true;

        m_PlayerMovement.SetAnimationState(PlayerMovement.AnimationConditions.hollow, true);

		m_AudioSource.Play ();
        StartCoroutine(KeepHollow());
    }

    public void StopHollow()
    {
        m_IsJumping = false;
        m_IsHollow = false;
        m_PlayerMovement.SetAnimationState(PlayerMovement.AnimationConditions.hollow, false);
    }

    IEnumerator KeepHollow()
    {
        float jumpProgress = 0f;

        Vector3 restingPosition = transform.position;

        while (m_IsJumping || jumpProgress > 0f)
        {
            Vector3 position = restingPosition;

            position.y += m_JumpTrajectory.Evaluate(jumpProgress) * m_HollowHoverHeight;

            transform.position = position;

            float deltaJumpProgress = Time.deltaTime / m_JumpTime;

            if (!m_IsJumping)
            {
                deltaJumpProgress = -deltaJumpProgress;
            }

            if (jumpProgress > 0.95f)
            {
                gameObject.layer = LayerMask.NameToLayer(m_ActionCollisionLayer);
            }
            else
            {
                m_PlayerMovement.RestoreLayerMask();
            }

            jumpProgress += deltaJumpProgress;

            jumpProgress = Mathf.Clamp01(jumpProgress);

            yield return new WaitForFixedUpdate();
        }

        m_PlayerMovement.cooldown = false;

        yield return null;
    }
}
