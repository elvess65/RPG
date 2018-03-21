using UnityEngine;

public class Interactable : MonoBehaviour 
{
    public float Radius = 3;
    public Transform InteractionTransform;

    private Transform m_Player;
    private bool m_HasInteracted = false;

    private void Update()
    {
        if (m_Player != null && !m_HasInteracted)
        {
            float dist = Vector3.Distance(m_Player.position, InteractionTransform.position);
            if (dist <= Radius)
            {
                Interact();
                m_HasInteracted = true;
            }
        }
    }

	public virtual void Interact()
	{
		Debug.Log("Interact");
	}

	public void OnFocused(Transform player)
    {
        m_Player = player;
        m_HasInteracted = false;
    }

    public void OnDefocused()
    {
        m_Player = null;
        m_HasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(InteractionTransform.position, Radius);
    }
}
