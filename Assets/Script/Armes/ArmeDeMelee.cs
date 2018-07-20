
using UnityEngine;

public class ArmeDeMelee : Arme
{
	#region Variables (public)



	#endregion

	#region Variables (private)



	#endregion
	public override void Attaquer()
	{
		m_pMaitre.m_pAnimator.SetTrigger("Attaque");
	}
}
