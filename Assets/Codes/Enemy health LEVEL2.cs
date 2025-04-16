using UnityEngine;
using TMPro;

public class EnemyHealthLV2 : MonoBehaviour
{
    public int maxHits = 3;
    public AudioClip deathSound;
    public TextMeshProUGUI scoreText; // ✅ Drag your TMP text object here in the Inspector

    private int currentHits = 0;
    private bool isDead = false;
    private AudioSource audioSource;

    private  int score = 0; // ✅ Shared score across all enemies

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        UpdateScoreUI(); // ✅ In case you want to display the score from the start
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDead) return;

        if (other.CompareTag("My Attack"))
        {
            currentHits++;

            if (currentHits >= maxHits)
            {
                isDead = true;

                if (deathSound != null)
                {
                    audioSource.PlayOneShot(deathSound);
                }

                // ✅ Increase score and update UI
                score++;
                UpdateScoreUI();

                Destroy(gameObject, deathSound != null ? deathSound.length : 0f);
            }
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = ":" + score + "/3";
        }
    }
}
