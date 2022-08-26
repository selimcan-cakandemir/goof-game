using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour {

    public float speed;
    private Vector3 _velocity;
    private Vector3 _displacement;
    
    void Start() {
        Destroy(gameObject,10f);
    }

    
    void Update() {
        _velocity = new Vector3(-1, 0f, 0f) * speed;
        _displacement = _velocity * Time.deltaTime;
        transform.localPosition += _displacement;
    }
}
