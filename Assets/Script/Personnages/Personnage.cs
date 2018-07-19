
using UnityEngine;

abstract public class Personnage : MonoBehaviour
{
	#region Variables (public)

	
	public Arme m_pArme = null;
	public float m_fHp = 10;
	public float m_fSpeed = 20.0f;

	#endregion

	#region Variables (private)



	#endregion


	abstract protected void MoveCharacter();
	abstract protected void Attaquer();
}
