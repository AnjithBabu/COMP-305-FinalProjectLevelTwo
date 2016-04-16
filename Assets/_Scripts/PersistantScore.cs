using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PersistantScore : MonoBehaviour {

    //PRIVATE INSTANCE VARIABLES
    private int _persistantScoreValue;
    private int _persistantLifeValues;
    private GameObject _persistantObject;


    //PUBLIC ACCESS METHODS
    public int ScoreValue
    {
        get
        {
            return _persistantScoreValue;
        }
        set
        {
            this._persistantScoreValue = value;
        }
    }

    public int LivesValue
    {
        get
        {
            return _persistantLifeValues;
        }
        set
        {
            this._persistantLifeValues = value;
        }
    }
    

	// Use this for initialization
	void Start () {
        this._initialize();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }


    //PRIVATE METHODS
    //INITIALIZE METHOD
    private void _initialize()
    {
        this.ScoreValue = 0;
        this.LivesValue = 5;
    }
}
