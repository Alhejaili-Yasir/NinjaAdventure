using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel1Button : MonoBehaviour
{
    // This method can be linked to the button's OnClick event
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
}
