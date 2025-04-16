using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelLoader2 : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;

    void Update()
    {
        if (text1.text == ":3/3" && text2.text == ":3/3")
        {
            SceneManager.LoadScene("Level3");
        }
    }
}
