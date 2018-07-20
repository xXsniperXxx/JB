
using UnityEngine;

public class PersonnageJoueurbg : Personnage
{
	#region Variables (public)
	
	public Rigidbody m_pMonRigidbody = null;
	public float m_fVitesseDeSaut = 200.0f;
	#endregion

	#region Variables (private)

	#endregion


	private void Update()
	{
		MoveCharacter();
		Jump();
		Attaquer();
	}

	override protected void MoveCharacter()
	{
		float fHorizontal = Input.GetAxis("Horizontal");
		float fVertical = Input.GetAxis("Vertical");

		Vector3 tDirection = new Vector3(fHorizontal, 0.0f, fVertical);

		if (tDirection != Vector3.zero)
		{

			
			tDirection = CameraPersonnage.Instance.transform.TransformDirection(tDirection);
			tDirection.y = 0.0f;
			if (tDirection.sqrMagnitude != 0.0f)
				tDirection.Normalize();
			else
				tDirection = transform.forward; 

			Vector3 tDeplacement = tDirection * (m_fSpeed * Time.deltaTime); // deplacement de 1 en profondeur 
			m_pMonRigidbody.MovePosition (transform.position + tDeplacement);
			

			transform.forward = tDirection;
		}
	}

	private void Jump()
	{
		if (Input.GetButtonDown("Jump"))
		{
			Vector3 tSaut = Vector3.up * m_fVitesseDeSaut;
			m_pMonRigidbody.AddForce(tSaut, ForceMode.Impulse);
		}

	}

	override protected void Attaquer()
	{
		if (Input.GetButton("Fire1"))
		{
			Vector3 tDirectionDattaque = Input.mousePosition; // on stock la position de la souris 
			tDirectionDattaque.x /= Screen.width; // on transforme de (x=1920, y=1080) à (x=1, y=1)
			tDirectionDattaque.y /= Screen.height;

			tDirectionDattaque -= new Vector3(0.5f, 0.5f, 0.5f); // on le prend par rapport au centre de l ecran (donc (x=5, y=0.5))
			tDirectionDattaque.z = tDirectionDattaque.y;
			tDirectionDattaque.y = 0.0f;

			tDirectionDattaque = CameraPersonnage.Instance.transform.TransformDirection(tDirectionDattaque);
			tDirectionDattaque.y = 0.0f;

			if (tDirectionDattaque != Vector3.zero)
				transform.forward = tDirectionDattaque.normalized;

			base.Attaquer();



		}


	}

}