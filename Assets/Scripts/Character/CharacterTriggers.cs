using System;
using UnityEngine;
using UnityEngine.UI;


public class CharacterTriggers : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private MovementForPlayer _movementForPlayer;
    [SerializeField] private GameObject deathCam;
    [SerializeField] private GameObject mainCam;
    [SerializeField] private GameObject pausePanelPrefab;
    [SerializeField] private Transform pausePanelPosition;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button continueButton;
    
    private static readonly int IsDead = Animator.StringToHash("IsDead");
    private bool paused;
    private GameObject newPausePanel;
    
    private void Awake()
    {
        exitButton.onClick.AddListener(CharacterLoadScenes.OpenMainMenu);
        restartButton.onClick.AddListener(CharacterLoadScenes.RestartLevel);
        continueButton.onClick.AddListener(Unpause);   // почему-то не работает, пока не выяснил
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            Pause();
        } else if (Input.GetKeyDown(KeyCode.Escape) && paused)
        {
            Unpause();
        }
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger(IsDead);
            _movementForPlayer.enabled = false;
            mainCam.SetActive(false);
            deathCam.SetActive(true);
        }
    }

    private void Pause()
    {
            newPausePanel = Instantiate(pausePanelPrefab, pausePanelPosition.position, Quaternion.identity);
            newPausePanel.SetActive(true);
            paused = true;
            Time.timeScale = 0f;
    }

    public void Unpause()
    {
            paused = false;
            newPausePanel.SetActive(false);
            Destroy(newPausePanel);
            Time.timeScale = 1f;
    }
}
