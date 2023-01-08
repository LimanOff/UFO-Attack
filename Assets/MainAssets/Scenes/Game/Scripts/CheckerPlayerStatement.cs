using UnityEngine;
using UnityEngine.UI;

public class CheckerPlayerStatement : MonoBehaviour
{
    public static PlayerStatement PlayerState { get; set; }

    [Header("Text")]
    [SerializeField] private Text _title;

    [Header("Animators")]
    [SerializeField] private Animator _titleAnim;
    [SerializeField] private Animator _progressAnim;
    [SerializeField] private Animator _distancePassedAnim;

    private int _counter = 0;

    private void Start()
    {
        PlayerState = PlayerStatement.Stay;
        HideUI();
    }

    private void OnEnable()
    {
        if (_counter != 0)
        {
            ShowUI();
        }

        PlayerState = PlayerStatement.Moving;

        UIEvents.OnJumpButtonTouch += ChangeStatementToMoving;
        UIEvents.OnStartCountButtonTouch += ChangeStatementToMoving;
    }

    private void OnDisable()
    {
        PlayerState = PlayerStatement.Stay;

        UIEvents.OnJumpButtonTouch -= ChangeStatementToMoving;
        UIEvents.OnStartCountButtonTouch -= ChangeStatementToMoving;

        _title.gameObject.gameObject.SetActive(false);
    }

    private void ChangeStatementToMoving()
    {
        PlayerState = PlayerStatement.Moving;
        _counter++;
    }

    private void ShowUI()
    {
        _progressAnim.Play("Out");
        _distancePassedAnim.Play("Out");
    }

    private void HideUI()
    {
        _titleAnim.Play("Jiggle");
        _progressAnim.Play("Hide");
        _distancePassedAnim.Play("Hide");
    }
    public enum PlayerStatement
    {
        Moving,
        Stay
    }
}
