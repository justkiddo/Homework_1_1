using UnityEngine;
using UnityEngine.UI;

public class ButtonsLogic : MonoBehaviour
{

    [SerializeField] private Button restartButton;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button mainMenuExitButton;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private FirstPersonMovement fpm;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource stepsSound;
    private bool _paused;
    private GameObject _newPausePanel;
    private static readonly int IsGameOver = Animator.StringToHash("IsGameOver");

    private void Awake()
    { 
        pausePanel.SetActive(false); 
        continueButton.onClick.AddListener(Unpause);
        restartButton.onClick.AddListener(HorrorLoadScenes.RestartLevel);
        mainMenuExitButton.onClick.AddListener(HorrorLoadScenes.OpenMainMenu);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && _paused == false)
        {
            Pause();
            
        } else if (Input.GetKeyDown(KeyCode.Escape) && _paused)
        {
            Unpause();
        }
        
    }
    
    private void Pause()
    {
        if (!_animator.GetBool(IsGameOver))
        {
            pausePanel.SetActive(true);
            stepsSound.Stop();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
            fpm.enabled = false;
        }
    }

    public void Unpause()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        fpm.enabled = true;
    }
    
    
}
