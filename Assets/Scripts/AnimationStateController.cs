using NUnit.Framework;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int IsWalkingHash = Animator.StringToHash("IsWalking");
    int IsRunningHash = Animator.StringToHash("IsRunning");
    int IsJumpingHash = Animator.StringToHash("IsJumping");
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(animator);
    }

    // Update is called once per frame
    void Update()
    {
        bool IsRunning = animator.GetBool(IsRunningHash);
        bool IsWalking = animator.GetBool(IsWalkingHash);
        bool IsJumping = animator.GetBool(IsJumpingHash);
        
        bool ForwardPress = Input.GetKey("w");
        bool RunPress = Input.GetKey("left shift");
        bool JumpPress = Input.GetKeyDown("space");

        if (!IsWalking && ForwardPress)
        {
            animator.SetBool(IsWalkingHash, true);
        }
        if (IsWalking && !ForwardPress)
        {
            animator.SetBool(IsWalkingHash, false);
        }

        if (!IsRunning && (ForwardPress && RunPress))
        {
            animator.SetBool(IsRunningHash, true);
        }

        if (IsRunning && (!ForwardPress || !RunPress))
        {
            animator.SetBool(IsRunningHash, false);
        }

        if (!IsJumping && JumpPress)
        {
            animator.SetBool(IsJumpingHash, true);
        }

        if (IsJumping && !JumpPress)
        {
            animator.SetBool(IsJumpingHash, false);
        }

        if (IsWalking && JumpPress)
        {
            animator.SetBool(IsWalkingHash, false);
        }

        if (IsWalking && JumpPress)
        {
            animator.SetBool(IsJumpingHash, true);
        }
    }
}