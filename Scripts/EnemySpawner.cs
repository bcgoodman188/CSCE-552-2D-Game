using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject waveButton;
    public GameObject enemy;
    public GameObject fastEnemy;
    public GameObject bigEnemy;
    public Transform spawnPoint;
    public int bigMan = 0;
    private int typeEnemy;
    private float survive = 27.0f;
    private float timeToSurvive = 0.0f;
    private float wait = 0.5f;
    private float timer = 0.0f;
    public AudioSource nextWaveAudio;

    [SerializeField] public int wave;
    public int mobs = 0;

    void Update()
    {
        if(Input.GetButtonDown("Jump")) {
            startNextWave();
        }
        /*
        if(timeTillNextWave > waitTillNextWave) {
            wave++;
            nextWave();
            timeTillNextWave = 0.0f;
            Debug.Log(mobs);
        }
        */
        timer += Time.deltaTime;
        //timeTillNextWave += Time.deltaTime;
        //Debug.Log(timer);
        if(timer > wait && mobs != 0){
            spawnMob();
            mobs--;
        }
        if(mobs == 0 && wave != 15) {
            getButton();
        }
        if(mobs == 0 && wave == 15) {
            timeToSurvive += Time.deltaTime;
            if(timeToSurvive > survive) {
                getButton();
            }
        }
    }

    void spawnMob() {
        typeEnemy = Random.Range(0,3);
        if(typeEnemy == 0) {
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        }
        if(typeEnemy == 1 && wave > 5 && wave < 14) {
            Instantiate(fastEnemy, spawnPoint.position, spawnPoint.rotation);
        }
        if(typeEnemy == 2 && wave > 7 && wave < 14 && bigMan != 5) {
            bigMan++;
            Instantiate(bigEnemy, spawnPoint.position, spawnPoint.rotation);
        }
        else if(typeEnemy == 2 && wave > 10) {
            Instantiate(bigEnemy, spawnPoint.position, spawnPoint.rotation);
        }
        else {
            if(wave < 14){
                Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            }
            if(wave > 14) {
                Instantiate(bigEnemy, spawnPoint.position, spawnPoint.rotation);
            }
        }
        timer = 0.0f;
    }

    public void startNextWave() {
        bigMan = 0;
        if(mobs == 0) {
            waveButton.SetActive(false);
            nextWaveAudio.Play();
            wave++;
            //mobs = Mathf.RoundToInt(Mathf.Exp(wave) + 9);
            mobs = Mathf.RoundToInt(5*wave);
            Debug.Log("The next wave has " + mobs + " mobs!");
            timer = 0.0f;
        }
        else {
            Debug.Log("Let this wave finish first!");
        }
    }
    void getButton() {
        waveButton.SetActive(true);
    }
}
