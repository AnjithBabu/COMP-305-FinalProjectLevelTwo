using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FireControllerLvlThree : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            if (this.transform.position.x < -559f || this.transform.position.x > 7081f)
            {
                GameObject.Destroy(gameObject);
            }
        }
        else
        {

            if (this.transform.position.x > 5200f || this.transform.position.x < -759f)
            {
                GameObject.Destroy(gameObject);
            }
        }
    }
}
