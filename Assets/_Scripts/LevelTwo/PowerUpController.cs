using UnityEngine;
using System.Collections;

public class PowerUpController : MonoBehaviour {

    private Transform _transform;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        this._transform = gameObject.GetComponent<Transform>();

        this._transform.Rotate(Vector3.forward * -90, 5);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Destroy(gameObject);
        }
    }
}
