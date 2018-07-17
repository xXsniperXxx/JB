
using UnityEngine;

public class PersonnageJoueurbg : MonoBehaviour
{
	#region Variables (public)

	public float m_fHp = 10;

	public float m_fSpeed = 20.0f;

	#endregion

	#region Variables (private)



	#endregion




	private void Update()
	{
		MoveCharacter();

	}

	private void MoveCharacter()
	{
		float fHorizontal = Input.GetAxis("Horizontal");
		float fVertical = Input.GetAxis("Vertical");

		Vector3 tDirection = new Vector3(fHorizontal, 0.0f, fVertical);


		
		

		if (tDirection != Vector3.zero)
		{

			tDirection.Normalize();

			Vector3 tDeplacement = tDirection * (m_fSpeed * Time.deltaTime); // deplacement de 1 en profondeur 

			transform.position += tDeplacement;

			transform.forward = tDirection;


		}


	}

}