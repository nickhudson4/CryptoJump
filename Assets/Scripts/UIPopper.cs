using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIPopper : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public TextMeshProUGUI text;

    private bool popStarted = false;
    private bool isScalingDown = false;
    private int tweenID_SCALE;
    private int tweenID_MOVE;

    void Update()
    {
        if (popStarted)
        {
            if (!isScalingDown)
            {
                if (!LeanTween.isTweening(tweenID_SCALE))
                {
                    tweenID_SCALE = LeanTween.scale(gameObject, new Vector3(0, 0, 0), 0.2f).setEase(LeanTweenType.easeOutElastic).id;
                    isScalingDown = true;
                }
            }
            else 
            {
                if (!LeanTween.isTweening(tweenID_SCALE))
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    public void Pop(float scaleUpTime, float randomMaxZAngle, float upMoveAmount, float upMoveTime)
    {
        transform.localScale = new Vector3 (0, 0, 0);
        tweenID_SCALE = LeanTween.scale(gameObject, new Vector3(1, 1, 1), scaleUpTime).setEase(LeanTweenType.easeOutElastic).id;
        transform.eulerAngles += new Vector3(0, 0, Random.Range(-randomMaxZAngle, randomMaxZAngle));
        tweenID_MOVE = LeanTween.moveY(gameObject, transform.position.y + upMoveAmount, upMoveTime).id;

        popStarted = true;
    }

    public void SetText(string text)
    {
        this.text.text = text;
    }

}
