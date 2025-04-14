using UnityEngine;
using TMPro;

public class ScrollCollector3 : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI scoreText;

    [Header("Score")]
    public int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Scroll"))
        {
            score += 1;
            UpdateScoreUI();
            Destroy(other.gameObject);
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = ":" + score +"/4";
        }
    }
}
