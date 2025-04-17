using UnityEngine;
using TMPro;

public class EnemyAIBoss : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    public float attackRange = 2f;
    public float walkRange = 2f;
    public float walkSpeed = 2f;

    public int health = 10;
    public AudioSource deathSound;
    public TextMeshProUGUI scoreText;
    private static int score = 0;

    private bool isDead = false;

    // 👇 Reference to the Controler script on the same GameObject
    public Controler controlerScript;

    void Update()
    {
        if (isDead) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", true);
        }
        else if (distance <= walkRange)
        {
            animator.SetBool("isAttacking", false);
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
            animator.SetBool("isWalking", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDead) return;

        if (other.CompareTag("My Attack"))
        {
            health--;

            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        isDead = true;
        animator.SetTrigger("Die");

        if (deathSound != null)
        {
            deathSound.Play();
        }

        score++;
        if (scoreText != null)
        {
            scoreText.text =  ":" + score + "/1";
        }

        // 👇 Disable the Controler script
        if (controlerScript != null)
        {
            controlerScript.enabled = false;
        }

        animator.SetBool("isWalking", false);
        animator.SetBool("isAttacking", false);
    }
}
