using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public class AnimationConditions
    {
        public static readonly int jump = Animator.StringToHash("isJumping");
        public static readonly int ducking = Animator.StringToHash("isDucking");
        public static readonly int hollow = Animator.StringToHash("isHollow");
    }

    [HideInInspector]
    public bool cooldown;

    [SerializeField]
    Animator m_Animator;

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

    public void SetAnimationState(int condition, bool value)
    {
        m_Animator.SetBool(condition, value);
    }

    public void TriggerAnimation(int condition)
    {
        m_Animator.SetTrigger(condition);
    }
}
