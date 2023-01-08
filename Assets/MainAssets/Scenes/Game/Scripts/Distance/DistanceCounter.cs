using YG;
using UnityEngine;
using System.Collections;

public class DistanceCounter : MonoBehaviour
{
    public int Distance { get; private set; }

    private void Awake()
    {
        Distance = 0;
    }

    private void OnEnable()
    {
        UIEvents.OnStartCountButtonTouch += StartCount;
        YandexGame.CloseVideoEvent += StartCount;
    }

    private void OnDisable()
    {
        UIEvents.OnStartCountButtonTouch -= StartCount;
        YandexGame.CloseVideoEvent -= StartCount;

        StopCount();
    }

    public void StartCount()
    {
        StartCoroutine(Count());
    }
    public void StopCount()
    {
        StopCoroutine(Count());
    }

    private IEnumerator Count()
    {
        while (Distance != DistanceOutputer.MaxValueSlider)
        {
            Distance++;

            yield return new WaitForSeconds(1f);
        }
    }
}
