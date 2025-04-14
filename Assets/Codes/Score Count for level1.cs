using UnityEngine;
using TMPro;

public class ScrollCollector : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI scoreText;

    [Header("Score")]
    public int score = 0;

    [Header("Audio")]
    public AudioSource collectSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Scroll"))
        {
            score += 1;
            UpdateScoreUI();

            if (collectSound != null && !collectSound.isPlaying)
            {
                collectSound.Play();
            }

            Destroy(other.gameObject);
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = ":" + score + "/1";
        }
    }
}
