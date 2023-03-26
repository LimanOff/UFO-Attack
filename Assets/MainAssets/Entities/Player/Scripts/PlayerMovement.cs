using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] private float _jumpForce;

    private void OnEnable()
    {
        UIEvents.OnJumpButtonTouch += Jump;
        UIEvents.OnStartCountButtonTouch += Jump;
    }

    private void OnDisable()
    {
        UIEvents.OnJumpButtonTouch -= Jump;
        UIEvents.OnStartCountButtonTouch -= Jump;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.isKinematic = true;
    }

    private void Update()
    {
        if (CheckerPlayerStatement.PlayerState == CheckerPlayerStatement.PlayerStatement.Stay)
        {
            _rb.isKinematic = true;
        }
        if (CheckerPlayerStatement.PlayerState == CheckerPlayerStatement.PlayerStatement.Moving)
        {
            _rb.isKinematic = false;
        }
    }

    private void Jump()
    {
        _rb.isKinematic = false;

        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }

        _rb.velocity = new Vector2(0,0);
        _rb.AddForce(Vector2.up * _jumpForce,ForceMode2D.Force);
    }

    
}
