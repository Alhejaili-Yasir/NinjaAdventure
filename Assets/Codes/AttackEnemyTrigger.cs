using UnityEngine;

public class AttackColliderHandler : MonoBehaviour
{
    public Collider attackCollider;            // Assign in Inspector
    public Animator animator;                  // Your character's Animator
    public string attackStateName = "attack";  // Name of the animation state
    public float enableStartTime = 0.2f;       // When to enable collider (0 to 1)
    public float enableEndTime = 0.6f;         // When to disable collider

    private bool isColliderActive = false;

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // Check if current state is the attack animation
        if (stateInfo.IsName(attackStateName))
        {
            float normalizedTime = stateInfo.normalizedTime % 1f;

            // Enable collider during the specified portion of the animation
            if (normalizedTime >= enableStartTime && normalizedTime <= enableEndTime)
            {
                if (!isColliderActive)
                {
                    attackCollider.enabled = true;
                    isColliderActive = true;
                }
            }
            else
            {
                if (isColliderActive)
                {
                    attackCollider.enabled = false;
                    isColliderActive = false;
                }
            }
        }
        else
        {
            // Make sure collider is off when not attacking
            if (attackCollider.enabled)
            {
                attackCollider.enabled = false;
                isColliderActive = false;
            }
        }
    }
}
