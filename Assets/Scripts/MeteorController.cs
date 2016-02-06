using UnityEngine;
using System.Collections;

public class MeteorController : MonoBehaviour {

    //PUBLIC INSTANCE VARIABLES
    public float minHorizontalSpeed = 5f;
    public float maxHorizontalSpeed = 10f;
    public float minVerticalSpeed = -2f;
    public float maxVerticalSpeed = 2f;

    //PRIVATE INSTANCE VARIABLES
    private Transform _transform;
    private Vector2 _currentPosition;
    private float _horizontalSpeed;
    private float _verticalDrift;

    // Use this for initialization
    void Start()
    {
        //Make a reference with the transform component
        this._transform = gameObject.GetComponent<Transform>();

        //Reset the planet sprite to the left
        this.Reset();
    }

    // Update is called once per frame
    void Update()
    {
        this._currentPosition = this._transform.position;
        this._currentPosition -= new Vector2(this._horizontalSpeed, this._verticalDrift);
        this._transform.position = this._currentPosition;

        if (this._currentPosition.x <= -353)
        {
            this.Reset();
        }
    }

    void Reset()
    {
        this._horizontalSpeed = Random.Range(this.minHorizontalSpeed, this.maxHorizontalSpeed);
        this._verticalDrift = Random.Range(this.minVerticalSpeed, this.maxVerticalSpeed);
        float yPosition = Random.Range(-225f, 225f);
        this._transform.position = new Vector2(353f, yPosition);
    }
}
