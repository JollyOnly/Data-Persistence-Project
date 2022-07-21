using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIManager : MonoBehaviour
{
    public InputField input;
    public Text BestScore;


    private void Start()
    {

        GameManager.Instance.LoadData();
        Debug.Log("name: "+ GameManager.Instance.pBsName + " score: "+ GameManager.Instance.pBsScore);
        if(GameManager.Instance.pBsName != null)
        {
            BestScore.text = $"Best Score: {GameManager.Instance.pBsName} - {GameManager.Instance.pBsScore}";
        }
        
        input.text = GameManager.Instance.pBsName;
    }
    public void StartGame()
    {
        GameManager.Instance.pName = input.text;
        SceneManager.LoadScene(1);

    }
    public void QuitGame()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

    }

}
