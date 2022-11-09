using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
	[Header("Character Input Values")]
	public Vector2 move;

	public float timeScale = 1.0f;

	public void OnMove(InputValue value)
	{
		MoveInput(value.Get<Vector2>());
	}

	public void OnSpeedUp(InputValue value)
	{
		if (value.isPressed)
		{
			Time.timeScale = timeScale;
		}
		else
		{
			Time.timeScale = 1.0f;
		}
	}

	public void MoveInput(Vector2 newMoveDirection)
	{
		move = newMoveDirection;
	}
}
