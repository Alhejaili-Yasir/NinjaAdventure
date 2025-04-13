using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("attack");
        }
    }
}
