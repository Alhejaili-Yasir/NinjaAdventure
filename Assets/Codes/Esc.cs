using UnityEngine;

public class EscapeToggle : MonoBehaviour
{
    public GameObject objectToActivate1;
    public GameObject objectToActivate2;

    public GameObject objectToDeactivate1;
    public GameObject objectToDeactivate2;
    public GameObject objectToDeactivate3;
    public GameObject objectToDeactivate4;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

            // Toggle time scale (pause or resume game)
            Time.timeScale = isPaused ? 0f : 1f;

            // Toggle objects
            objectToActivate1?.SetActive(isPaused);
            objectToActivate2?.SetActive(isPaused);

            objectToDeactivate1?.SetActive(!isPaused);
            objectToDeactivate2?.SetActive(!isPaused);
            objectToDeactivate3?.SetActive(!isPaused);
            objectToDeactivate4?.SetActive(!isPaused);

            // Toggle cursor state
            Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = isPaused;
        }
    }
}
