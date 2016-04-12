using UnityEngine;
using System.Collections;

public class OnHitController : MonoBehaviour {

    public Rigidbody2D explosionPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("fire"))
        {

            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            GameObject.Destroy(gameObject);
        }
    }
}
