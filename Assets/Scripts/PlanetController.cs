using UnityEngine;
using System.Collections;

public class PlanetController : MonoBehaviour {
    //PUBLIC INSTANCE VARIABLES
    public float speed = 5f;

    //PRIVATE INSTANCE VARIABLES
    private Transform _transform;
    private Vector2 _currentPosition;

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
        this._currentPosition -= new Vector2(this.speed, 0);
        this._transform.position = this._currentPosition;

        if (this._currentPosition.x <= -362)
        {
            this.Reset();
        }
    }

    void Reset()
    {
        float yPosition = Random.Range(-198f, 198f);
        this._transform.position = new Vector2(362f, yPosition);
    }
}
