using UnityEngine;
using System.Collections;

public class MonsterOnHitController : MonoBehaviour
{

    public Rigidbody2D explosionPrefab;
    private int noOfHits;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("fire"))
        {
            if (noOfHits > 3)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                GameObject.Destroy(gameObject);
            }
            noOfHits++;
            GameObject.Destroy(GameObject.FindGameObjectWithTag("fire"));
        }
    }
}
