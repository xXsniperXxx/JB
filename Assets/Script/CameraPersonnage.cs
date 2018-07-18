
using UnityEngine;

public class CameraPersonnage : MonoBehaviour
{
	#region Variables (public)
	public PersonnageJoueurbg m_pTarget = null;// p = pointeur, il peut etre 0
	static public CameraPersonnage Instance = null;
	public float m_fDistanceDeSuivi = 0.0f;
	public float m_fVitesseDeRotation = 0.0f;
	#endregion

	#region Variables (private)



	#endregion

	private void Awake()
	{
		if (CameraPersonnage.Instance != null)
		{
			if (CameraPersonnage.Instance != this)

			Debug.LogError("Attention,il y a deux CameraPersonnage dans la scene");
				Destroy(this);

			return;
		}

		CameraPersonnage.Instance = this;
	}

		private void Update()
	{
		TournerCamera();

	}


	private void LateUpdate()
	{
		if (m_pTarget != null)
			Follow();
		// pour jmp : nouvelle fonction , input. Getbutton(down)("Jump") 

	}

	private void Follow()
	{
		
		// Gameobject Get : Tres utile 
		
		
		Vector3 tNouvellePositionCamera = m_pTarget.transform.position + Vector3.up - (transform.forward * m_fDistanceDeSuivi);
		transform.position = tNouvellePositionCamera;
	}


	private void TournerCamera()
	{
		float fMouseX = Input.GetAxis("Mouse X");

		if (fMouseX != 0.0f)
		
			transform.RotateAround(m_pTarget.transform.position, Vector3.up, fMouseX * (m_fVitesseDeRotation * Time.deltaTime));
		

		float fMouseY = Input.GetAxis("Mouse Y");

		if (fMouseY != 0.0f)
		
		
			transform.RotateAround(m_pTarget.transform.position, transform.right, fMouseY * (-m_fVitesseDeRotation * Time.deltaTime));

			
		

	}

}