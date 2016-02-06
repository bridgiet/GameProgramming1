using UnityEngine;
using System.Collections;

public class SpaceShipController : MonoBehaviour {
    //PUBLIC INPUT VARIABLES
    public float speed = 5f;

    //PRIVATE INPUT VARIABLES
    private float _playerInput;
    private Transform _transform;
    private Vector2 _currentPosition;

	// Use this for initialization
	void Start () {
        this._transform = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        this._currentPosition = this._transform.position;
        this._playerInput = Input.GetAxis("Vertical");

        //Moving up
        if (this._playerInput > 0)
        {
            this._currentPosition += new Vector2(0, this.speed);
        }

        //Moving down
        if (this._playerInput < 0)
        {
            this._currentPosition -= new Vector2(0, this.speed);
        }

        this._checkBounds();
	}

    //PRIVATE METHODS
    private void _checkBounds()
    {
        //Setting Boundries
        if (this._currentPosition.y > 212)
        {
            this._currentPosition.y = 212;
        }
        if (this._currentPosition.y < -212)
        {
            this._currentPosition.y = -212;
        }
        this._transform.position = this._currentPosition;
    }
}
