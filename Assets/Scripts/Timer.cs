using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeDuration = 20;

    private float timer;

    private TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        timer = 20;
    }

    private void Update() {
        if(timer > 0) {
            UpdateTimerDisplay(timer);
        } else {
            endOfTimer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
    }

    private void UpdateTimerDisplay(float time) {
        timerText.text = timer.ToString();
    }

    private void endOfTimer() {

    }
}
