using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    
    public GameObject[] objects;
    public Vector2 spawnValues;
    public float waitForStart;
    public int minWait;
    public int mostWait;
    public bool stop;
    
    private int _randomObject;
    private Vector2 _spawnPosition;
    private float _waitForSpawn;
    
    public float[]speedPhase = {4f,5f,6f};

    void Start() {
        StartCoroutine(ObjectSpawner());
        StartCoroutine(NewPhase(10));
    }

    private IEnumerator NewPhase(int no) {
        int i = 0;
        while(i < no) {
            for (int x = 0; x < speedPhase.Length; x++) {
                speedPhase[x] = speedPhase[x] + 1f;
            }
            yield return new WaitForSeconds(10f);
            i++;
        }
        
    }

    void Update() {
        _waitForSpawn = Random.Range(minWait, mostWait + 1);
        float timePassed = Time.time;
    }
    
    IEnumerator ObjectSpawner() {

        yield return new WaitForSeconds(waitForStart);

        while (!stop) {

            _randomObject = Random.Range(0, objects.Length);

            if (transform.gameObject.CompareTag("TreeSpawner")) {
                _spawnPosition = new Vector2(spawnValues.x, spawnValues.y);
            }
            else {
                _spawnPosition = new Vector2(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y + 1));
            }

            GameObject o = Instantiate(objects[_randomObject], _spawnPosition, gameObject.transform.rotation);
            o.AddComponent<ObjectMove>();
            
            
            if (o.CompareTag("Cloud")) {
                o.GetComponent<ObjectMove>().speed = speedPhase[0];
            }
            else if (o.CompareTag("Tree")) {
                o.GetComponent<ObjectMove>().speed = speedPhase[1];
            }
            else if (o.CompareTag("Enemy")) {
                o.GetComponent<ObjectMove>().speed = speedPhase[2];
            }

            yield return new WaitForSeconds(_waitForSpawn);
        }
    }
}
