using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.EventSystems;

public class Timer : MonoBehaviour {
    
    public TextMeshProUGUI textGame;
    public TextMeshProUGUI textEnd;
    

    private TimeSpan _timePlaying;
    private float _elapsedTime;

    void Update() {

        _elapsedTime += Time.deltaTime;
        _timePlaying = TimeSpan.FromSeconds(_elapsedTime);
        string timePlaying = _timePlaying.ToString("mm':'ss'.'ff");
        textGame.text = timePlaying;
        textEnd.text = timePlaying;

    }
    
    
}
