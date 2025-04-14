using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    #region Sigleton
    public static PlayerManager instance;

    void Awake ()
    {
        instance = this;
    }
    #endregion

    public GameObject player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
