using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (this.transform.position.x > 5200f || this.transform.position.x < -759f)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
