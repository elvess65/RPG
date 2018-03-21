using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour
{
	public float LockomotionAnimationSmoothTime = 0.1f; 
	
	private Animator m_PlayerAnimator;
	private NavMeshAgent m_Agent;	
	
	// Use this for initialization
	void Start ()
	{
		m_Agent = GetComponent<NavMeshAgent>();
		m_PlayerAnimator = GetComponentInChildren<Animator>();

	}
	
	// Update is called once per frame
	void Update ()
	{
		float speedPercent = m_Agent.velocity.magnitude / m_Agent.speed;
		m_PlayerAnimator.SetFloat("speedPercent", speedPercent, LockomotionAnimationSmoothTime, Time.deltaTime);
	}
}
