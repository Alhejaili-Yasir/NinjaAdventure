using UnityEngine;

public class ActivateObjectOnInput : MonoBehaviour
{
    public GameObject objectToActivate; // Drag and drop the object here
    public float activeDuration = 0.5f; // Duration for how long it stays active

    private bool isActivating = false;

    void Update()
    {
        if (!isActivating && (Input.GetKeyDown(KeyCode.R) || Input.GetMouseButtonDown(0)))
        {
            StartCoroutine(ActivateForTime());
        }
    }

    private System.Collections.IEnumerator ActivateForTime()
    {
        isActivating = true;
        objectToActivate.SetActive(true);
        yield return new WaitForSeconds(activeDuration);
        objectToActivate.SetActive(false);
        isActivating = false;
    }
}
