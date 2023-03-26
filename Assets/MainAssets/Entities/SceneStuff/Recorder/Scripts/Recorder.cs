using YG;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    [SerializeField] private DistanceCounter _distanceCounter;

    public void RecordToLeaderBoard()
    {
        int currentDistance = _distanceCounter.Distance;

        if(currentDistance > YandexGame.savesData.maxDistance)
        {
            YandexGame.NewLeaderboardScores("HowMuchDistanceCompleted", currentDistance);
            YandexGame.savesData.maxDistance = currentDistance;
        }
    }
}
