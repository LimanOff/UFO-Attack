using YG;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerRewarder : MonoBehaviour
{
    Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        YandexGame.CloseVideoEvent += RestartPlayerPosition;
	    YandexGame.ErrorVideoEvent += RestartPlayerPosition;
    }

    private void OnDisable()
    {
        YandexGame.CloseVideoEvent -= RestartPlayerPosition;
	    YandexGame.ErrorVideoEvent -= RestartPlayerPosition;
    }

    private void RestartPlayerPosition()
    {
        Time.timeScale = 1;
        _rb.velocity = new Vector2(0,0);
        transform.position = new Vector2(0f, 16f);
        transform.rotation = Quaternion.Euler(0f, 0f, -10f);
    }
}
