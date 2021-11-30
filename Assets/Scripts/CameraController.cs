using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public enum Mode
    {
        NONE,
        PLAYERFOLLOW
    }
    public Mode mode = Mode.NONE;

    private Vector3 velocity = Vector3.zero;
    [HideInInspector] public int tweenID = -1;

    [Header("CAMERA FOLLOW VARS")]
    public Transform camFollowTarget;
    public bool smoothFollow;
    public Vector3 camFollowOffset;
    public Vector3 levelStartPos;
    public float snapTime; //Only for smoothFollow;

    //MISC SETTINGS
    [HideInInspector] public float screenBoundLeft;
    [HideInInspector] public float screenBoundRight;
    [HideInInspector] public float screenBoundBottom;
    [HideInInspector] public  float screenBoundTop;

    public void OnLevelStart()
    {
        camFollowTarget = gv.core.gameManager.playerManager.player.transform;
        mode = CameraController.Mode.PLAYERFOLLOW;
        transform.position = gv.core.cameraController.levelStartPos;
        Vector2 xBounds = Utils.GetScreenXBounds(0);
        screenBoundLeft = xBounds.x;
        screenBoundRight= xBounds.y; 
        Vector2 yBounds = Utils.GetScreenYBounds(0); 
        screenBoundBottom = yBounds.x;
        screenBoundTop = yBounds.y;

        // Utils.PlaceDebugBlock(new Vector3(xBounds.x, 0, 0));
        // Utils.PlaceDebugBlock(new Vector3(xBounds.y, 0, 0));
        // Vector2 yBounds = Utils.GetScreenYBounds(0);
        // Utils.PlaceDebugBlock(new Vector3(0, yBounds.x, 0));
        // Utils.PlaceDebugBlock(new Vector3(0, yBounds.y, 0));
    }

    void Update()
    {
        switch (mode) 
        {
            case Mode.PLAYERFOLLOW:
            {
                Vector3 targetPos = camFollowTarget.position + camFollowOffset;
                targetPos.x = 0;
                if (targetPos.y < transform.position.y){ targetPos.y = transform.position.y; }
                if (targetPos.y != transform.position.y) //Update vertical screen bounds
                { 
                    Vector2 yBounds = Utils.GetScreenYBounds(0); 
                    screenBoundBottom = yBounds.x;
                    screenBoundTop = yBounds.y;
                }
                if (smoothFollow)
                {
                    transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, snapTime);
                }
                else 
                {
                    transform.position = targetPos;
                }
                break;
            }
        }
    }

    public void SetCamFollowTarget(Transform target)
    {
        this.camFollowTarget = target;
    }

    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(C_Shake(duration, magnitude));
    }

    public IEnumerator C_Shake(float duration, float magnitude)
    {
        Vector3 orignalPosition = transform.position;
        float elapsed = 0f;
        
        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.position = orignalPosition;
    }
}


