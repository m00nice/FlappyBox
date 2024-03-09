using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    public static GameSystem Instance;
    [SerializeField] private CanvasGroup menuCanvasGroup;
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip angyBird;
    [SerializeField] private AudioClip bing;
    
    private int pointsCurrent = 0;
    
    
    
    void Awake()
    {
        Instance = this;
        button.onClick.AddListener((() => Restart()));
    }

    public void AddPoints(int points)
    {
        pointsCurrent += points;
        scoreText.text = pointsCurrent.ToString();
        source.PlayOneShot(bing);
    }

    public void ShowMenu()
    {
        source.PlayOneShot(angyBird);
        menuCanvasGroup.alpha = 1;
        menuCanvasGroup.interactable = true;
        menuCanvasGroup.blocksRaycasts = true;
    }


    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    
}
