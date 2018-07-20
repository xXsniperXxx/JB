
using UnityEngine;

abstract public class Personnage : MonoBehaviour
{
	#region Variables (public)

	public Animator m_pAnimator = null;
	public Arme m_pArme = null;
	public float m_fHp = 10;
	public float m_fSpeed = 20.0f;

	#endregion

	#region Variables (private)



	#endregion


	abstract protected void MoveCharacter();

	/// <summary>
	/// Lancez l'attaque de mon arme si elle existe 
	/// </summary>

	virtual protected void Attaquer()
	{
		m_pArme?.Attaquer();
	}
}
