using UnityEngine;

namespace Game
{
	public class Player : MonoBehaviour
	{
		[SerializeField] private float moveForce;

		private Rigidbody rb;
		private Vector2 moveInput;
		private bool jumpInput;
		private Mover mover;

		const float baseMoveSpeed = 0f;
		const float backstopForce = 1;

		private void Awake()
		{
			rb = GetComponent<Rigidbody>();
			mover = FindObjectOfType<Mover>();
		}

		private void Update()
		{
			moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
			if(Input.GetKeyDown(KeyCode.Space)) { jumpInput = true; }
		}

		private void FixedUpdate()
		{
			// Slow too far back
			if (transform.position.x <= mover.BackstopPosition) rb.velocity = new Vector3(rb.velocity.x * 0.1f, rb.velocity.y, rb.velocity.z);

			//Push off back
			float backstopAccel = 1f / (Mathf.Abs(transform.position.x - mover.BackstopPosition) * 10f) * backstopForce * (mover.GameSpeed * 0.5f);
			backstopAccel = Mathf.Min(backstopAccel, 10f);

			// Move 
			if (moveInput.x < 0) moveInput.x = -0.1f;

			//up/down movement too fast
			moveInput.y *= 0.85f;
			
			rb.AddForce(new Vector3(moveInput.x + backstopAccel, 0, moveInput.y) * (moveForce * (mover.GameSpeed * 0.7f)) * (1f - rb.velocity.magnitude * 0.1f));
			if (jumpInput) 
			{ 
				jumpInput = false; 
			}
		}
	}
}