using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    private Button showLoveButton;
    private Button hideLoveButton;
    private Button countingSceneButton;
    private Button flirtingSceneButton;
    private RectTransform loveMessage;
    private RectTransform wrongAnswer;
    private RectTransform rightAnswer;

    void Awake()
    {
        showLoveButton =  gameObject.GetComponentsInChildren<Button>(true).First(x => x.name.Contains("Show"));
        hideLoveButton =  gameObject.GetComponentsInChildren<Button>(true).First(x => x.name.Contains("Hide"));
        loveMessage = gameObject.GetComponentsInChildren<RectTransform>(true).First(n => n.name.Contains("BorderHelloMessage"));
        wrongAnswer = gameObject.GetComponentsInChildren<RectTransform>(true).First(n => n.name.Contains("WrongAnswer"));
        rightAnswer = gameObject.GetComponentsInChildren<RectTransform>(true).First(n => n.name.Contains("RightAnswer"));

        // Tìm các button để chuyển scene (nếu có trong UI)
        var allButtons = gameObject.GetComponentsInChildren<Button>(true);
        countingSceneButton = allButtons.FirstOrDefault(x => x.name.Contains("Counting"));
        flirtingSceneButton = allButtons.FirstOrDefault(x => x.name.Contains("Flirting"));
    }

    // Start is called before the first frame update
    void Start()
    {
        // Log nền tảng hiện tại để debug
        Debug.Log($"Current Platform: {PlatformSceneManager.GetCurrentPlatform()}");

        showLoveButton.OnClickAsObservable().Subscribe(_ =>
        {
            wrongAnswer.gameObject.SetActive(false);
            rightAnswer.gameObject.SetActive(true);
        }).AddTo(this);

        hideLoveButton.OnClickAsObservable().Subscribe(_ =>
        {
            wrongAnswer.gameObject.SetActive(true);
            rightAnswer.gameObject.SetActive(false);
        }).AddTo(this);

        // Thêm event handlers cho việc chuyển scene
        if (countingSceneButton != null)
        {
            countingSceneButton.OnClickAsObservable().Subscribe(_ =>
            {
                PlatformSceneManager.LoadCountingScene();
            }).AddTo(this);
        }

        if (flirtingSceneButton != null)
        {
            flirtingSceneButton.OnClickAsObservable().Subscribe(_ =>
            {
                PlatformSceneManager.LoadFlirtingScene();
            }).AddTo(this);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Methods để gọi từ UI buttons hoặc từ code khác
    public void GoToCountingScene()
    {
        PlatformSceneManager.LoadCountingScene();
    }

    public void GoToFlirtingScene()
    {
        PlatformSceneManager.LoadFlirtingScene();
    }

    public void GoToMainScene()
    {
        PlatformSceneManager.LoadMainScene();
    }
}
