using UnityEngine;
using System.Collections;

public class SpaceShipCollider : MonoBehaviour {
    //PRIVATE INSTANCE VARIABLES
    private AudioSource[] _audioSources;
    private AudioSource _planetSound;
    private AudioSource _meteorSound;

    //PUBLIC INSTANCE VARIABLE;
    public GameController gameController;

	// Use this for initialization
	void Start () {
        this._audioSources = gameObject.GetComponents<AudioSource> ();
        this._planetSound = this._audioSources[1];
        this._meteorSound = this._audioSources[2];
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Planet"))
        {
            this._planetSound.Play();
            this.gameController.ScoreValue += 1;
            if(gameController.ScoreValue == 10)
            {
                this.gameController.LivesValue += 1;
            }
        }
        if (other.gameObject.CompareTag("Meteor"))
        {
            this._meteorSound.Play();
            this.gameController.LivesValue -= 1;
        }
    }
}
