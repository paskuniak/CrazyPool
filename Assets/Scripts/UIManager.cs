using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private const string BestScoreKey = "BestScore";

    [SerializeField] 
    private PlayerController player = null;
    
    [SerializeField] 
    private TextMeshProUGUI scoreText = null;
    
    [SerializeField] 
    private TextMeshProUGUI timeText = null;
    
    [SerializeField] 
    private TextMeshProUGUI bestScoreText = null;
    
    [SerializeField] 
    private UITempDisplay instructions = null;
    
    [SerializeField] 
    private UITempDisplay timeAdded = null;
    
    [SerializeField] 
    private Fireworks fireworks = null;
    
    [SerializeField] 
    private AbstractTweener[] menuUIElements = null;
    
    [SerializeField] 
    private AbstractTweener[] gameUIElements = null;

    private GameState gameState;
    private int score;
    private int timeInSeconds;

    internal void SetState(GameState state)
    {

        gameState = state;
        switch (gameState)
        {
            case GameState.Menu:
                UpdateBestScore();
                SetUIElementsVisible(menuUIElements, true);
                SetUIElementsVisible(gameUIElements, false);
                break;
            case GameState.Game:
                StartGame();
                SetUIElementsVisible(menuUIElements, false);
                SetUIElementsVisible(gameUIElements, true);
                break;
            default:
                break;
        }
    }

    private void Start()
    {
        UpdateBestScore();
    }

    private void UpdateBestScore()
    {
        bestScoreText.text = GetBestScore().ToString();
    }

    private int GetBestScore()
    {
        if (PlayerPrefs.HasKey(BestScoreKey))
        {
            return PlayerPrefs.GetInt(BestScoreKey);
        }
        return 0;
    }

    private void SetUIElementsVisible(AbstractTweener[] menuUIElements, bool visible)
    {
        for (int i = 0; i < menuUIElements.Length; i++)
        {
            menuUIElements[i].SetVisible(visible);
        }
    }

    private void UpdateUI()
    {
        string seconds = (timeInSeconds % 60) < 10 ? $"0{timeInSeconds % 60}" : (timeInSeconds % 60).ToString();
        timeText.text = $"{timeInSeconds / 60}:{seconds}";
        scoreText.text = score.ToString();
    }

    private void StartGame()
    {
        score = 0;
        instructions.Show(2);
        UpdateUI();
    }

    internal void EndGame()
    {
        int bestScore = GetBestScore();
        if (score > bestScore)
        {
            PlayerPrefs.SetInt(BestScoreKey, score);
            SFXPlayer.PlayClip(SFX.HighScore);
            fireworks.Play();
        }
        SetState(GameState.Menu);
    }

    internal void AddScore(int v)
    {
        score += v;
        if (score < 0)
        {
            score = 0;
        }
        UpdateUI();
    }

    internal void UpdateTime(int v)
    {
        timeInSeconds = v-1;
        UpdateUI();
    }

    internal void NotifyAddTime()
    {
        timeAdded.Show(0.75f);
    }

    public void OnSliderMove(float value)
    {
        if (gameState == GameState.Game)
        {
            player.SetXPositionTarget(value);
        }
    }

    public void PlayClicked()
    {
        GameManager.Instance.StartGame();
    }

}
