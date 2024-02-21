using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerMid : MonoBehaviour
{
    public float TargetTime;
    public float StartTime;
    TextMeshProUGUI TimerCount;
    int timerCount;
    // Start is called before the first frame update
    void Start()
    {
        TimerCount = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        StartTime = StartTime - Time.deltaTime;

        if (StartTime < TargetTime)
        {
            StartTime = 0;
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = (currentSceneIndex - 2) % SceneManager.sceneCountInBuildSettings;
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {

        }
        TimerCount.text = StartTime.ToString("f2");
    }
}
