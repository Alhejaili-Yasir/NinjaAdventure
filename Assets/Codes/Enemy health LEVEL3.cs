using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public int maxHits = 3;
    public AudioClip deathSound;
    public TextMeshProUGUI scoreText; // ✅ Drag your TMP text object here in the Inspector

    private int currentHits = 0;
    private bool isDead = false;
    private AudioSource audioSource;

    private static int score = 0; // ✅ Shared across all enemies
    private static bool scoreInitialized = false; // ✅ Prevents multiple resets on scene load

    void Start()
    {
        if (!scoreInitialized)
        {
            score = 0;
            scoreInitialized = true;
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        UpdateScoreUI();
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

                score++;
                UpdateAllScoreUIs();

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

    void UpdateAllScoreUIs()
    {
        EnemyHealth[] allEnemies = FindObjectsByType<EnemyHealth>(FindObjectsSortMode.None);
        foreach (var enemy in allEnemies)
        {
            enemy.UpdateScoreUI();
        }
    }
}
