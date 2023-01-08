using YG;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    [SerializeField] private DistanceCounter _distanceCounter;

    public void RecordToLeaderBoard()
    {
        YandexGame.NewLeaderboardScores("HowMuchDistanceCompleted", _distanceCounter.Distance);
    }
}
