using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EnemyHealthLV2 : MonoBehaviour
{
    public int maxHits = 3;
    public AudioClip deathSound;
    public TextMeshProUGUI scoreText; // ✅ Drag your TMP text object here in the Inspector

    private int currentHits = 0;
    private bool isDead = false;
    private AudioSource audioSource;

    private static int score = 0; // ✅ Shared score across all enemies
    private static bool sceneInitialized = false;

    void Awake()
    {
        // Reset score only once per scene load
        if (!sceneInitialized)
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
            sceneInitialized = true;
        }
    }

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

    // Called automatically when the scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        score = 0;
        sceneInitialized = false; // reset for next scene load
    }

    void OnDestroy()
    {
        // Clean up the event subscription
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
