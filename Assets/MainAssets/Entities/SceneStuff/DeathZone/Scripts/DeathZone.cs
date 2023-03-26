using System;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public static Action OnTouchDeadZone;
    public static int PlayerDeadCounter = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            KillPlayer();
        }
    }

    private void KillPlayer()
    {
        PlayerDeadCounter++;
        OnTouchDeadZone?.Invoke();
    }
}
