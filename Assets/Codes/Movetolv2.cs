using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;

    void Update()
    {
        if (text1.text == ":1/1" && text2.text == ":1/1")
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
