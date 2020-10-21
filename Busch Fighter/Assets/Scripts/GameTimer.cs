using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our Level Timer in Seconds")]
    [SerializeField] float levelTimer = 10;
    bool triggeredLevelFinished = false;


    void Update()
    {
        if (triggeredLevelFinished) { return; }

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTimer;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTimer);

        if (timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;

        }
    }
}
