using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string pName { get; set; }
    public string pBsName { get; set; }
    public int pScore { get; set; }
    public int pBsScore { get; set; }

    public class Player
    {
        public string name;
        public int score;
    }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveData()
    {
        if (pBsScore < pScore)
        {
            Player player = new Player();
            player.name = pName;
            player.score = pScore;
            string json = JsonUtility.ToJson(player);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
        
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Player player = JsonUtility.FromJson<Player>(json);

            pBsName = player.name;
            pBsScore = player.score;
        }
    }
}
