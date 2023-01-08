using YG;
using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    public int Speed;

    private void OnEnable()
    {
	YandexGame.OpenVideoEvent += DestroyEnemy;
    }

    private void OnDisable()
    {
	YandexGame.OpenVideoEvent -= DestroyEnemy;
    }

    private void Update()
    {
        transform.position += transform.right * Speed * Time.deltaTime;
    }

    private void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }
}
