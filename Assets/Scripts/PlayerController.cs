using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask MovementMask;
    public Interactable FocusObj;

    private Camera m_Camera;
    private PlayerMotor m_Motor;

	void Start () 
    {
        m_Camera = Camera.main;
        m_Motor = GetComponent<PlayerMotor>();
	}
	
	void Update () 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitResult;

            if (Physics.Raycast(ray, out hitResult, 100, MovementMask))
            {
                m_Motor.MoveToPoint(hitResult.point);
                RemoveFocus();
            }
        }

		if (Input.GetMouseButtonDown(1))
		{
			Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitResult;

			if (Physics.Raycast(ray, out hitResult, 100))
			{
                Interactable obj = hitResult.collider.GetComponent<Interactable>();
                if (obj != null)
                {
                    SetFocus(obj);
                }
			}
		}
	}

    void SetFocus(Interactable obj)
    {
        if (FocusObj != obj)
        {
            if (FocusObj != null)
                FocusObj.OnDefocused();

            FocusObj = obj;
			obj.OnFocused(transform);
			m_Motor.FollowTarget(obj);
        }
    }

    void RemoveFocus()
    {
        if (FocusObj != null)
        {
            FocusObj.OnDefocused();
            FocusObj = null;
        }

        m_Motor.StopFollowingTarget();
    }
}
