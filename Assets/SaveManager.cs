using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class SaveManager : MonoBehaviour
{
    private InputField inputField; //ENCAPSULATION

    public static SaveManager Instance;
    /*[HideInInspector]*/ public string name;

    private void Awake()
    {
        inputField = GameObject.Find("InputField").GetComponent<InputField>();

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        name = inputField.text;
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
    }

    public void SaveName()
    {
        SaveData data = new SaveData();
        data.name = name;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            name = data.name;
        }
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
