using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelLoader3 : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;


    void Update()
    {
        if (text1.text == ":4/4" && text2.text == ":3/3" && text3.text == ":1/1")
        {
            SceneManager.LoadScene("Win");
        }
    }
}
