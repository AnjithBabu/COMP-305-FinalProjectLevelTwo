using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MonsterFireController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if ( this.transform.position.x < 5918f)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
