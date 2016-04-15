using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ShootingControllerLvlThree : MonoBehaviour
{

    public Rigidbody2D bulletPrefab;
    public HeroController heroController;
    float attackSpeed = 0.5f;
    float cooldown;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (heroController.firingEnabled)
        {
            if (Time.time >= cooldown)
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    fire();
                }
            }
        }
    }

    private void fire()
    {
        if(SceneManager.GetActiveScene().buildIndex == 4) {

            Rigidbody2D prefab = Instantiate(bulletPrefab, new Vector2(


                (heroController._facingRight ? this.transform.position.x +30 : this.transform.position.x - 39), this.transform.position.y),
                Quaternion.identity) as Rigidbody2D;

            if (heroController._facingRight)
            {
                prefab.AddForce(Vector3.right * 500);
            }
            else
            {
                prefab.transform.Rotate(Vector3.forward * -180);
                prefab.AddForce(Vector3.left * 500);
            }

            cooldown = Time.time + attackSpeed;

        }else{

            Rigidbody2D prefab = Instantiate(bulletPrefab, new Vector2(this.transform.position.x + 30, this.transform.position.y),
                Quaternion.identity) as Rigidbody2D;

            if (heroController._facingRight)
            {
                prefab.AddForce(Vector3.right * 500);
            }
            else
            {
                prefab.transform.Rotate(Vector3.forward * -180);
                prefab.AddForce(Vector3.left * 500);
            }

            cooldown = Time.time + attackSpeed;
        }
    }
}
