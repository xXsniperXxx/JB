
using UnityEngine;

public class CameraPersonnage : MonoBehaviour
{
	#region Variables (public)
	public PersonnageJoueurbg m_pTarget = null;// p = pointeur, il peut etre 0
	public float m_fDistanceDeSuivi = 0.0f;

	#endregion

	#region Variables (private)



	#endregion

	private void LateUpdate()
	{
		if (m_pTarget != null)
		Follow();
// pour jmp : nouvelle fonction , input. Getbutton(down)("Jump") 
	}

	private void Follow()
	{
		Vector3 tNouvellePosition = m_pTarget.transform.position + Vector3.up - (transform.forward) * m_fDistanceDeSuivi;
		// Gameobject Get : Tres utile 
		transform.position = tNouvellePosition;
		

	}
}

