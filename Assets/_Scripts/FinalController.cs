using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalController : MonoBehaviour
{
    private GameObject _scoreTracker;
    private PersistantScore _scoreTrackerScript; 
    public Text HighScoreText;

    // Use this for initialization
    void Start()
    {
        this._scoreTracker = GameObject.FindGameObjectWithTag("scoretracker");
        this._scoreTrackerScript = this._scoreTracker.GetComponent<PersistantScore>();
        this.HighScoreText.text = "Score : " + this._scoreTrackerScript.ScoreValue;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //EventHandler for StartButton Click
    public void MenuButtonClick()
    {
        SceneManager.LoadScene("Menu");
    }

    
}
