
using System.Collections;
using TMPro;
using UnityEngine;

public class OrderResultUI : MonoBehaviour
{
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private float displayTime = 2f;

    private Coroutine hideRoutine;

    private void Awake()
    {
        if (resultText != null)
            resultText.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        GameEvents.OnFoodServed += ShowResult;
    }

    private void OnDisable()
    {
        GameEvents.OnFoodServed -= ShowResult;
    }

    private void ShowResult(bool correct, RecipeData recipe, int money)
    {
        if (resultText == null) return;

        resultText.gameObject.SetActive(true);
        resultText.text = correct ? "ORDER SUCCESS!" : "ORDER FAILED!";
        resultText.color = correct ? Color.green : Color.red;

        if (hideRoutine != null)
            StopCoroutine(hideRoutine);

        hideRoutine = StartCoroutine(HideAfterDelay());
    }

    private IEnumerator HideAfterDelay()
    {
        yield return new WaitForSecondsRealtime(displayTime);
        resultText.gameObject.SetActive(false);
        hideRoutine = null;
    }
}
