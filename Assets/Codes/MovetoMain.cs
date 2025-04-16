using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMain1Button : MonoBehaviour
{
    // This method can be linked to the button's OnClick event
    public void LoadMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
