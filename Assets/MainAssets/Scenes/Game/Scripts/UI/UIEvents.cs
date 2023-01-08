using YG;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIEvents : MonoBehaviour
{
    public static Action OnJumpButtonTouch;
    public static Action OnStartCountButtonTouch;

    [Header("Buttons")]
    [SerializeField] private Button _jumpButton;
    [SerializeField] private Button _startCountButton;

    [Space]

    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _closePausePanelButton;

    [Space]

    [SerializeField] private Button _rewardRespawnButton;
    [SerializeField] private Button _justRespawnButton;

    [Header("Text")]
    [SerializeField] private Text _title;

    [Header("Animators")]
    [SerializeField] private Animator _titleAnim;
    [SerializeField] private Animator _progressAnim;
    [SerializeField] private Animator _distancePassedAnim;

    [Header("GameObjects for fill")]
    [SerializeField] private GameObject _titleGO;
    [SerializeField] private GameObject _progressGO;
    [SerializeField] private GameObject _distancePassedGO;

    [Header("Panels")]
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _diePanel;

    [SerializeField] private GameObject _winPanel;

    [SerializeField] private DistanceCounter _distanceCounter;

    private void OnEnable()
    {
        OpenOnlyGamePanel();

        _jumpButton.onClick.AddListener(ExecuteJumpDelegate);
        _startCountButton.onClick.AddListener(ExecuteStartCountDelegate);

        _rewardRespawnButton.onClick.AddListener(ShowAD);
        _justRespawnButton.onClick.AddListener(ReloadLevel);

        DeathZone.OnTouchDeadZone += ShowDiePanel;

        YandexGame.OpenFullAdEvent += TIMESTOP;
        YandexGame.CloseFullAdEvent += TIMESTARTUM;
    }

    private void OnDisable()
    {
        _jumpButton.onClick.RemoveListener(ExecuteJumpDelegate);
        _startCountButton.onClick.RemoveListener(ExecuteStartCountDelegate);

        DeathZone.OnTouchDeadZone -= ShowDiePanel;
    }

    private void Start()
    {
        OpenOnlyGamePanel();
    }

    private void TIMESTOP()
    {
        Time.timeScale = 0;
    }

    private void TIMESTARTUM()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (DeathZone.PlayerDeadCounter == 3)
        {
            _rewardRespawnButton.interactable = false;
        }

        if (_distanceCounter.Distance == DistanceOutputer.MaxValueSlider)
        {
            OpenWinPanel();
        }
    }

    #region WorkWithDiePanel
    private void ShowDiePanel()
    {
        _diePanel.SetActive(true);

        _gamePanel.SetActive(false);

        Time.timeScale = 0;
    }
    private void CloseDiePanel()
    {
        _gamePanel.SetActive(true);

        _diePanel.SetActive(false);
    }

    #endregion WorkWithDiePanel

    private void OpenOnlyGamePanel()
    {
        _gamePanel.SetActive(true);

        _diePanel.SetActive(false);
        _winPanel.SetActive(false);
    }

    private void OpenWinPanel()
    {
        _winPanel.SetActive(true);

        _gamePanel.SetActive(false);
        _diePanel.SetActive(false);

        Time.timeScale = 0;
    }

    #region WorkWithDelegatesAndAnimations
    private void ExecuteJumpDelegate()
    {
        OnJumpButtonTouch?.Invoke();
    }

    private void ExecuteStartCountDelegate()
    {
        OnStartCountButtonTouch?.Invoke();

        _titleAnim.Play("Hide");
        _progressAnim.Play("Out");
        _distancePassedAnim.Play("Out");

        _startCountButton.gameObject.gameObject.SetActive(false);

    }

    #endregion WorkWithDelegatesAndAnimations

    private void ShowAD()
    {
        Time.timeScale = 0;
        YandexGame.RewVideoShow(0);
        CloseDiePanel();
    }

    public void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex + 0;

        _distanceCounter.StopCount();

	_rewardRespawnButton.interactable = true;

	DeathZone.PlayerDeadCounter = 0;

        SceneManager.LoadScene(currentScene);
    }

}
