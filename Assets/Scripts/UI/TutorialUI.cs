using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialUI : MonoBehaviour
{
    #region FIELDS
    public static TutorialUI Instance { get; private set; }
    [SerializeField] private Transform welcomeScreenTransform;
    private float welcomeScreenTimer = 5f;
    private string playerPrefsFirstPlay = "IsFirstPlayed";


    [Header("Buttons")]
    [SerializeField] private Button moveUpButton;
    [SerializeField] private Button moveDownButton;
    [SerializeField] private Button moveRightButton;
    [SerializeField] private Button moveLeftButton;
    [SerializeField] private Button interactButton;
    [SerializeField] private Button interactAlternateButton;
    [Header("ButtonsText")]
    [SerializeField] private TextMeshProUGUI moveUpText;
    [SerializeField] private TextMeshProUGUI moveDownText;
    [SerializeField] private TextMeshProUGUI moveRightText;
    [SerializeField] private TextMeshProUGUI moveLeftText;
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private TextMeshProUGUI interactAlternateText;
    #endregion

    #region SUBSCRIPTIONS
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        if (PlayerPrefs.GetInt(playerPrefsFirstPlay, 1) == 0)
        {
            // if it's not the first time a player plays the game, tutorial.gameObject should be disabled and KitchenGameManager.State.TutorialTime always skipped
            KitchenGameManager.Instance.DisableTutorial();
        }
        KitchenGameManager.Instance.OnGameUnpaused += KitchenGameManager_OnGameUnpaused;
        GameInput.Instance.OnInteractAction += GameInput_OnInteract;
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;
        UpdateVisual();
    }
    private void Update()
    {
        welcomeScreenTimer -= Time.deltaTime;
        IsWelcomed(welcomeScreenTimer);

    }
    #endregion

    #region METHODS
    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (KitchenGameManager.Instance.IsInTutorial())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
    private void GameInput_OnInteract(object sender, System.EventArgs e)
    {
        Hide();
        if (KitchenGameManager.Instance.IsInTutorial())
        {
            KitchenGameManager.Instance.SetState(KitchenGameManager.State.WaitingToStart);
        }
    }
    private void KitchenGameManager_OnGameUnpaused(object sender, System.EventArgs e)
    {
        Hide();
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void ShowWelcome()
    {
        welcomeScreenTransform.gameObject.SetActive(true);
    }
    public void HideWelcome()
    {
        welcomeScreenTransform.gameObject.SetActive(false);
    }
    private void UpdateVisual()
    {
        moveUpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up);
        moveDownText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down);
        moveLeftText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        moveRightText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);
        interactText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
        interactAlternateText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact_Alternate);
    }
    private void IsWelcomed(float timer)
    {
        if (timer > 0f)
        {
            ShowWelcome();
            PlayerPrefs.SetInt(playerPrefsFirstPlay, 0);
            PlayerPrefs.Save();
        }
        else
        {
            HideWelcome();
        }
    }
    #endregion
}
