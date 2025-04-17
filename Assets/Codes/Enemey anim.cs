using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    public float attackRange = 2f;
    public float walkRange = 2f;
    public float walkSpeed = 2f;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", true);
            // Face the player or stop moving
        }
        else if (distance <= walkRange)
        {
            animator.SetBool("isAttacking", false);
            animator.SetBool("isWalking", true);
            // Move toward the player
        }
        else
        {
            animator.SetBool("isAttacking", false);
            animator.SetBool("isWalking", false);
        }

    }


}