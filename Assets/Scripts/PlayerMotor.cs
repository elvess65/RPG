using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour 
{
    private NavMeshAgent m_Agent;
    private Transform m_Traget;

    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (m_Traget != null)
        {
            MoveToPoint(m_Traget.position);
            FaceTarget();
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        m_Agent.SetDestination(point);
    }

	public void FollowTarget(Interactable target)
	{
        m_Agent.stoppingDistance = target.Radius * 0.8f;
        m_Agent.updateRotation = false;
        m_Traget = target.InteractionTransform;
	}

	public void StopFollowingTarget()
	{
        m_Agent.stoppingDistance = 0;
        m_Agent.updateRotation = true;
        m_Traget = null;
	}

    void FaceTarget()
    {
        Vector3 dir = (m_Traget.position - transform.position).normalized;
        Quaternion rot = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 5);
    }
}
