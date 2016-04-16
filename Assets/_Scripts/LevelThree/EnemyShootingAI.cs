using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyShootingAI : MonoBehaviour
{

    public Rigidbody2D enemyBulletPrefab;
    float enemyAttackSpeed = 2f;
    float enemyCooldown;
    public GameObject HeroObject;

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (HeroObject.transform.position.x > 6409f) {

            if (Time.time >= enemyCooldown)
            {
                enemyFire();
            }
        }
    }

    private void enemyFire()
    {
       
        Rigidbody2D prefab = Instantiate(enemyBulletPrefab, new Vector2( this.transform.position.x - 60, this.transform.position.y-50),
        Quaternion.identity) as Rigidbody2D;

        prefab.AddForce(Vector3.left * 500);

        enemyCooldown = Time.time + enemyAttackSpeed; 
    }
}
