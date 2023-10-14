using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    GameManager gameManager;
    TrackList trackList;
    [SerializeField] public int health;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private int enemyValue;
    [SerializeField] private int enemyDamage;

    private Transform target;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        trackList = FindObjectOfType<TrackList>();

        target = trackList.path[index];
    }

    // Update is called once per frame
    void Update()
    {
        //If the distance between the player and the point is less than 0.1
        if(Vector2.Distance(target.position, transform.position) <= 0.1f) {
            //change directions to the next point
            index++;
            //If they reach the end destroy the game object
            if(index >= trackList.path.Length) {
                gameManager.dmgSound.Play();
                gameManager.lifeTotal -= enemyDamage;
                Destroy(gameObject);
                return;
            }
            //buffer to prevent errors from negative values
            else {
                target = trackList.path[index];
            }
        }
        if(health <= 0) {
            Destroy(gameObject);
            gameManager.currency += enemyValue;
            return;
        }
    }
    private void FixedUpdate() {
        //Direction the enemy needs to go in.
        Vector2 direction = (target.position  - transform.position).normalized;
        //How fast to move with direction.
        rb.velocity = direction * moveSpeed;
    }
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Rock") {
            //audioPlayer.Play();
            health--;
            Destroy(other.gameObject);
        }
    }
}
