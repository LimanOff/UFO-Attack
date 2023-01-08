using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Awake()
    {
        _speed = 0;
    }

    private void Update()
    {
        if (CheckerPlayerStatement.PlayerState == CheckerPlayerStatement.PlayerStatement.Moving)
        {
            _speed = 7;
        }
        if (CheckerPlayerStatement.PlayerState == CheckerPlayerStatement.PlayerStatement.Stay)
        {
            _speed = 0;
        }

        Move();
    }

    private void Move()
    {
        transform.position += -transform.right * _speed * Time.deltaTime;
    }
}
