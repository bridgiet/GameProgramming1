using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameController : MonoBehaviour {
    //PRIVATE INSTANCE VARIABLES
    private int _scoreValue;
    private int _livesValue;

    [SerializeField]
    private AudioSource _gameOverSound;

    //PUBLIC INSTANCE VARIABLES
    public int meteorNumber = 3;
    public MeteorController meteor;
    public SpaceShipController spaceShip;
    public PlanetController planet;
    public Text livesLabel;
    public Text scoreLabel;
    public Text gameOverLabel;
    public Text highSchoolLabel;
    public Button restartButton;

    //PUBLIC ACCESS METHODS
    public int ScoreValue
    {
        get
        {
            return this._scoreValue;
        }

        set
        {
            this._scoreValue = value;
            this.scoreLabel.text = "Score: " + this._scoreValue;
        }
    }

    public int LivesValue
    {
        get
        {
            return this._livesValue;
        }

        set
        {
            this._livesValue = value;
            if (this._livesValue <= 0)
            {
                _endGame();
            }
            else
            {
                this.livesLabel.text = "Lives: " + this._livesValue;
               
            }           
        }
    }

    // Use this for initialization
    void Start () {
        this._initialize();
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //PRIVATE METHODS
    private void _initialize()
    {
        this.ScoreValue = 0;
        this.LivesValue = 5;
        this.gameOverLabel.enabled = false;
        this.highSchoolLabel.enabled = false;
        this.restartButton.gameObject.SetActive(false);
        for(int meteorCount = 0; meteorCount < this.meteorNumber; meteorCount++)
        {
            Instantiate(meteor.gameObject);
        }
    }

    private void _endGame()
    {
        this.highSchoolLabel.text = "High Score: " + _scoreValue;
        this.gameOverLabel.enabled = true;
        this.highSchoolLabel.enabled = true;
        this.scoreLabel.enabled = false;
        this.livesLabel.enabled = false;
        this.restartButton.gameObject.SetActive(true);
        this.spaceShip.gameObject.SetActive(false);
        this.planet.gameObject.SetActive(false);
        this._gameOverSound.Play();
    }

    //PUBLIC METHODS
    public void RestartButtonClick()
    {
        Application.LoadLevel("Main");
    }
}
