using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public Transform rockSpawnPoint;
    public GameObject rockPrefab;
    public float rockSpeed = 10;
    private bool canAttack = true;
    [SerializeField] public float coolDown;
    private Transform closetsenemy;
    public bool enemyInRange = false;
    public List <GameObject> targets = new List<GameObject>();
    public AudioSource rockAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    IEnumerator waiter() {
        canAttack = false;
        yield return new WaitForSecondsRealtime(coolDown);
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(targets.Count > 0) {
            attackFirstEnemy();
        }
    }
    void attackFirstEnemy() {
        if(canAttack == false) {
            return;
        }
        else {
            var rock = Instantiate(rockPrefab, rockSpawnPoint.position, rockSpawnPoint.rotation);
            Destroy(rock, 0.5f);
            rockAudio.Play();
            if(targets[0] != null) {
            Vector2 direction = (targets[0].transform.position - rockSpawnPoint.position).normalized;
            rock.GetComponent<Rigidbody2D>().velocity = direction * rockSpeed;
            }
            else {
                return;
            }
        }

        StartCoroutine(waiter());
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy")) {
            targets.Add(other.gameObject);
            enemyInRange = true;
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Enemy")) {
            targets.Remove(other.gameObject);
            enemyInRange = false;
        }
    }
}
