
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTitre : MonoBehaviour
{
	#region Variables (public)

	public string m_sNomDeLaScene = null;
	
	#endregion

#region Variables (private)



	#endregion

	public void LancerJeu()
	{
		SceneManager.LoadScene(m_sNomDeLaScene);
	}

	public void QuittezJeu()
	{
		Application.Quit();
	}

}
