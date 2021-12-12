using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    private Image image;
    void Start()
    {
        image = GetComponent<Image>();
    }
    void Update()
    {
        if (GameManager.GetState() == GameManager.State.GAMEPLAY || GameManager.GetState() == GameManager.State.READY)
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 viewPort = Camera.main.ScreenToViewportPoint(mousePos);
            if (viewPort.x <= 0f || viewPort.x >= 1f || viewPort.y <= 0f || viewPort.y >= 1f)
            {
                Hide(true);
            }
            else 
            {
                Hide(false);
            }
            transform.position = mousePos;
        }
    }

    public void Set(bool set)
    {
        gameObject.SetActive(set);
    }

    public void Hide(bool hide)
    {
        image.enabled = !hide;
    }
}
