using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Rigidbody2D rb;
	public GameObject model;
	[SerializeField] private float horizontalSpeed;
	private int tweenID = -1;

	[Header("SHOOTING VARS")]
	[SerializeField] private Cannon cannon;
	[SerializeField] private GameObject bulletPrefab;
	[SerializeField] private float shootForce;
	[SerializeField] private float shootCooldown;
	private Counter shootCooldownCounter;

	public float scale1;
	public float time1;
	public float scale2;
	public float time2;
	public float time3;

	void Start()
	{
		shootCooldownCounter = new Counter(shootCooldown, true);
	}
	
	void Update() 
	{
		if (gv.core.gameManager.state == GameManager.State.GAMEPLAY)		
		{
			HandleInput();
			if (IsOutOfBounds())
			{
				gv.core.gameManager.OnLevelLose();
			}
		}
		else if (gv.core.gameManager.state == GameManager.State.GAMEPLAY_END)
		{
			if (!LeanTween.isTweening(tweenID))
			{
				gv.core.gameManager.OnLevelWin();
				Set(false);
			}
		}
	}

	public void Jump(float force)
	{
		rb.velocity = Vector2.zero;
		rb.AddForce(Vector2.up * force);

		// LeanTween.rotateAround(model.gameObject, Vector3.forward, 360, 0.7f).setEase(LeanTweenType.easeOutCubic);
		var seq = LeanTween.sequence();
		seq.append(LeanTween.scaleY(model, scale1, time1));
		seq.append(LeanTween.scaleY(model, scale2, time2));
		seq.append(LeanTween.scaleY(model, 0.2f, time3));
	}

	public void OnStartGameplay()
	{
		rb.isKinematic = false;
	}

	private void HandleInput()
	{
		if (gv.core.gameManager.state == GameManager.State.GAMEPLAY)
		{
			float horiz = Input.GetAxis("Horizontal");
			Vector3 newPos = transform.position + new Vector3 (horiz * Time.deltaTime * horizontalSpeed , 0, 0);
			if (newPos.x > gv.core.cameraController.screenBoundLeft && newPos.x < gv.core.cameraController.screenBoundRight)
			{ 
				transform.position = newPos;
			}

			if (Input.GetMouseButton(0))
			{
				if (shootCooldownCounter.isOver())
				{

					Vector3 mouseScreenPos = Input.mousePosition;
					mouseScreenPos.z = -gv.core.cameraController.transform.position.z;
					Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mouseScreenPos);
					Vector3 shootDir = (worldPoint - transform.position).normalized;
					cannon.Shoot(shootDir);
					Bullet bullet = Instantiate(bulletPrefab, cannon.shootFrom.position, Quaternion.identity).GetComponent<Bullet>();
					bullet.rb.AddForce(shootDir * shootForce);
				}
				shootCooldownCounter.incriment();
			}
			else
			{
				shootCooldownCounter.reset(true);
			}
			if (Input.GetMouseButtonUp(0))
			{
				cannon.ResetRotation();
			}
		}
	}

	public void OnHitLastPlatform(Platform platform)
	{
		LeanTween.cancel(gameObject);
		rb.isKinematic = true;
		tweenID = LeanTween.moveY(gameObject, transform.position.y + 20, 2).setEase(LeanTweenType.easeOutCubic).id;
		LeanTween.rotateAround(model.gameObject, Vector3.forward, 360, 0.7f).setEase(LeanTweenType.easeOutCubic);

	}

	private bool IsOutOfBounds()
	{
		if (transform.position.y < gv.core.cameraController.screenBoundBottom || transform.position.x < gv.core.cameraController.screenBoundLeft-1 || transform.position.x > gv.core.cameraController.screenBoundRight+1)
		{
			return true;
		}
		return false;
	}

	public void Set(bool set)
	{
		gameObject.SetActive(set);
	}
}
