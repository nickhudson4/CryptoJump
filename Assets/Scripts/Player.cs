using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
	public Rigidbody2D rb;
	public GameObject model;
	[SerializeField] private float horizontalSpeed;
	[SerializeField] private Animator animator;
	private int tweenID = -1;

	[Header("SHOOTING VARS")]
	[SerializeField] private Cannon cannon;
	[SerializeField] private GameObject bulletPrefab;
	[SerializeField] private float shootForce;
	[SerializeField] private float shootCooldown;
	private Counter shootCooldownCounter;

	public bool isImmune = false;

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
		animator.SetTrigger("jump2");
	}

	public void OnStartGameplay()
	{
		rb.isKinematic = false;
		Jump(1200);
	}

	private void HandleInput()
	{
		if (gv.core.gameManager.state == GameManager.State.GAMEPLAY)
		{
			float horiz = Input.GetAxis("Horizontal");
			Vector3 newPos = transform.position + new Vector3 (horiz * Time.deltaTime * horizontalSpeed , 0, 0);
			transform.position = newPos;
			if (horiz > 0){ transform.eulerAngles = new Vector3(0, 180, 0); }
			else if (horiz < 0) { transform.eulerAngles = new Vector3(0, 0, 0); }

			if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
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
