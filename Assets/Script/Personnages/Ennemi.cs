
using UnityEngine;
using UnityEngine.AI;

public class Ennemi : Personnage
{
	#region Variables (public)

	public NavMeshAgent m_pNavMeshAgent = null;


	public Personnage m_pCible = null;
	public float m_fDistanceDarret = 0.0f;

	#endregion

	#region Variables (private)

	

	#endregion

	private void Start()
	{
		m_pNavMeshAgent.speed = m_fSpeed;
		m_pNavMeshAgent.stoppingDistance = m_fDistanceDarret;
	}

	private void Update()
	{
		if (m_pCible == null)
			return;   // on est sur d'avoir une cible 
		MoveCharacter();

		if (m_pNavMeshAgent.velocity == Vector3.zero)
		{
			Attaquer();
		}
	}

	private void LateUpdate()
	{
		if (m_pAnimator != null)
			AnimeMarche();
	}
	protected override void Attaquer()
	{
		Vector3 tDirection = (m_pCible.transform.position - transform.position).normalized;

		transform.forward = (m_pCible.transform.position - transform.position).normalized;
		 
		base.Attaquer();
	}

	protected override void MoveCharacter()

	{
		Vector3 tDirection = (m_pCible.transform.position - transform.position).normalized;

		RaycastHit tHit;

		if (Physics.Raycast(transform.position + Vector3.up, tDirection, out tHit, 300.0f, LayerMask.GetMask("Personnage"), QueryTriggerInteraction.Collide))
		{
			Vector3 tDestination = tHit.point - Vector3.up - (m_pNavMeshAgent.radius * tDirection); // notre largeur, vers l'arrière
			m_pNavMeshAgent.SetDestination(tDestination);
		}
	}

	private void AnimeMarche()
	{
		m_pAnimator.SetBool("Bouge", m_pNavMeshAgent.velocity != Vector3.zero);
	}

}