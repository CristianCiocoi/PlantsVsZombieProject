using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameTimer : MonoBehaviour
{
    [Tooltip("Our Level timer in Seconds")]
    [SerializeField] float levelTime = 10f;
    bool triggeredLevelFinished = false;


    private void Update()
    {

        if (triggeredLevelFinished) { return; } //if its finished than return nothing means that you do not execute the code bellow
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);

        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true; 
        }
    
    }



}
