using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    private int canUpgrade = 0;
    public GameObject T1tower;
    public GameObject T2tower;
    public GameObject upgradedTower;
    public GameObject spawnT1;
    public GameObject spawnT2;

    public Transform T1SpawnLocation;
    public Transform T2SpawnLocation;
    public Transform T3SpawnLocation;

    // Start is called before the first frame update
    GameManager gameManager;

    public AudioSource firstSound;
    public AudioSource secondSound;
    public AudioSource thirdSound;

    private void Start() {
        gameManager = FindObjectOfType<GameManager>();

    }
    public void OnClickReaction() {
        if(gameManager.currency >= 100 && gameObject.GetComponent<SpriteRenderer>().enabled == true && canUpgrade == 0) {
            firstSound.Play();
            canUpgrade++;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //var clone = Instantiate(tower, location.position, location.rotation);
            CreateT1();
            gameManager.currency = gameManager.currency - 100;
            Debug.Log(gameManager.currency);
        }
        else if(gameManager.currency >= 300 && gameObject.GetComponent<SpriteRenderer>().enabled == false && canUpgrade == 1) {
            secondSound.Play();
            canUpgrade++;
            DestroyT1();
            CreateT2();
            gameManager.currency = gameManager.currency - 300;
            Debug.Log(gameManager.currency);
        }
        else if(gameManager.currency >= 500 && gameObject.GetComponent<SpriteRenderer>().enabled == false && canUpgrade == 2) {
            thirdSound.Play();
            canUpgrade++;
            DestroyT2();
            Instantiate(upgradedTower, T3SpawnLocation.position, T3SpawnLocation.rotation);
            gameManager.currency = gameManager.currency - 500;
            Debug.Log(gameManager.currency);
        }
        else {
            Debug.Log("Insufficient Funds");
        }
    }
    public void CreateT1(){
        spawnT1 = Instantiate(T1tower, T1SpawnLocation.position, T1SpawnLocation.rotation);
    }
    public void CreateT2() {
        spawnT2 = Instantiate(T2tower, T2SpawnLocation.position, T2SpawnLocation.rotation);
    }

    public void DestroyT1() {
        Destroy(spawnT1);
    }
    public void DestroyT2() {
        Destroy(spawnT2);
    }
}
