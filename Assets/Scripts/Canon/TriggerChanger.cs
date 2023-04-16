using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TriggerChanger : MonoBehaviour
{
    [SerializeField] private GameObject shootingTarget;
    [SerializeField] private TextMeshProUGUI targetCountInfo;
    [SerializeField] private Button levelClearedButton;
    [SerializeField] private Button restartLevelButton;
    private int _targetsCount = 3;


    private void Awake()
    {
        levelClearedButton.gameObject.SetActive(false);
        restartLevelButton.gameObject.SetActive(false);
    }

    private void Update()
    {
        targetCountInfo.text = _targetsCount.ToString();
    }


    private void OnTriggerExit(Collider other)
    {
        if ("Target (UnityEngine.GameObject)" == other.gameObject.ToString())
        {
            --_targetsCount;
            if (_targetsCount == 0)
            {
                Debug.Log("Good job, well done");
               levelClearedButton.gameObject.SetActive(true);
               restartLevelButton.gameObject.SetActive(true);
               targetCountInfo.gameObject.SetActive(false);
            }
        }
        
    }
}
