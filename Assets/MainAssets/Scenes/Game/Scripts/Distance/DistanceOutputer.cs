using UnityEngine;
using UnityEngine.UI;

public class DistanceOutputer : MonoBehaviour
{
    [SerializeField] private Text _counter;
    [SerializeField] public Slider _distancePassed;

    [SerializeField] private DistanceCounter _distanceCounter;

    public static int MaxValueSlider { get; private set; }

    private void Awake()
    {
        MaxValueSlider = (int)_distancePassed.maxValue;
    }

    private void Update()
    {
        Output();
    }

    private void Output()
    {
        _counter.text = "Пройдено: " + _distanceCounter.Distance;
        _distancePassed.value = _distanceCounter.Distance;
    }
}
