using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSaveSystem : MonoBehaviour
{
    private string savePath;

    [System.Serializable]
    class SaveData
    {
        public int sceneIndex;
    }

    void Awake()
    {
        savePath = Application.persistentDataPath + "/savefile.json";
    }

    public void SaveScene()
    {
        SaveData data = new SaveData
        {
            sceneIndex = SceneManager.GetActiveScene().buildIndex
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Saved scene index: " + data.sceneIndex);
    }

    public void LoadScene()
    {
        if (File.Exists(savePath))
        {
            // Resume game in case it was paused
            Time.timeScale = 1f;

            string json = File.ReadAllText(savePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("Loading scene index: " + data.sceneIndex);
            SceneManager.LoadScene(data.sceneIndex);
        }
        else
        {
            Debug.LogWarning("No save file found!");
        }
    }
}
