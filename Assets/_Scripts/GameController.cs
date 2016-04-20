using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * Controller class for the Ga,e
 * Description : Class that controls the game viz. points earned, lives left etc
 * */
public class GameController : MonoBehaviour {

	//PRIVATE INSTANCE VARIABLES
    private GameObject _scoreTracker;
    private PersistantScore _scoreTrackerScript; 
	private int _scoreValue;
	private int _lifeValues;
    private AudioSource[] _audioSources;
    private AudioSource _menuSound;

	//PUBLIC INSTANCE VARIABLES
	public Text LivesText;
	public Text ScoreText;
	public Text GameoverText;
	public Text HighScoreText;
	public Text FinishGameText;
    public RectTransform GamePanel;
    public Text PromoText;
    public Image LivesIcon;
    public Image CoinIcon;
	public Button RestartButton;
    public Button LevelButton;
	public HeroController heroController;

	//PUBLIC ACCESS METHODS
	public int ScoreValue{
		get { 
			return _scoreValue;
		}
		set { 
			this._scoreValue = value;
			this.ScoreText.text = "Score : " + this._scoreValue;
		}
	}

	public int LivesValue {
		get { 
			return _lifeValues;
		}
		set{
			this._lifeValues = value;
			if (this._lifeValues <= 0) {
				this._endGame ();
			} else {
				this.LivesText.text = "Lives  : " + this._lifeValues;
			}
		}
	}

	// Use this for initialization
	void Start () {
		this._initialize ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//PRIVATE METHODS
	//INITIALIZE METHOD
	private void _initialize(){
        if (SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 2)
        {
            this._audioSources = gameObject.GetComponents<AudioSource>();
            this._menuSound = this._audioSources[0];
        }
        
        this._scoreTracker = GameObject.FindGameObjectWithTag("scoretracker");
        this._scoreTrackerScript = this._scoreTracker.GetComponent<PersistantScore>();
		this.ScoreValue = this._scoreTrackerScript.ScoreValue;
		this.LivesValue = this._scoreTrackerScript.LivesValue;
		this.GameoverText.enabled = false;
		this.HighScoreText.enabled = false;
		this.RestartButton.gameObject.SetActive(false);
        this.LevelButton.gameObject.SetActive(false);
		this.FinishGameText.enabled = false;
        if (this.PromoText != null)
        {
            this.PromoText.enabled = false;
        }
        if (this.GamePanel != null)
        {
            this.GamePanel.gameObject.SetActive(false);
        }
	}

	//THIS METHOD IS CALLED WHEN THE PLAYER HAS LOST ALL HIS LIVES
	private void _endGame(){

        if (this.GamePanel != null)
        {
            this.GamePanel.gameObject.SetActive(true);
        }

		this.HighScoreText.text = "Score : " + this._scoreValue;
		this.GameoverText.enabled = true;
		this.ScoreText.enabled = false;
		this.HighScoreText.enabled = true;
		this.RestartButton.gameObject.SetActive(true);
		this.LivesText.enabled = false;
		this.heroController.gameObject.SetActive(false);
		this.heroController.cameraObject.position = new Vector3 (1,1,-10);
	}

	//PUBLIC METHOD

	//THIS METHOD IS CALLED WHEN THE PLAYER REACHES THE FINISH POINT
	public void finishGame(){

        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            this._scoreTrackerScript.ScoreValue = this._scoreValue;
            this._scoreTrackerScript.LivesValue = this._lifeValues;
            SceneManager.LoadScene(5);
        }
        else
        {
            if (this.GamePanel != null)
            {
                this.GamePanel.gameObject.SetActive(true);
            }
            this.ScoreText.enabled = false;
            this.LivesText.enabled = false;
            this.HighScoreText.text = "Score : " + this._scoreValue;
            this.HighScoreText.enabled = true;
            this.FinishGameText.enabled = true;
            this.LevelButton.gameObject.SetActive(true);
            if (this.PromoText != null)
            {
                this.PromoText.enabled = true;
            }
            if (this.LivesIcon != null)
            {
                this.LivesIcon.enabled = false;
            }
            if (this.CoinIcon != null)
            {
                this.CoinIcon.enabled = false;
            }

            this._scoreTrackerScript.ScoreValue = this._scoreValue;
            this._scoreTrackerScript.LivesValue = this._lifeValues;

            this.heroController.gameObject.SetActive(false);
            this.heroController.cameraObject.position = new Vector3(1, 1, -10);

            if (SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 2)
            {
                this._menuSound.Play();
            }
        }

	}

	//CALLED WHEN THE RESTART BUTTON IS CLICKED. WILL RESTART THE GAME
	public void RestartButtonClick(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

    public void LevelChangeClick()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene(4);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(3);
        }
    }
}
