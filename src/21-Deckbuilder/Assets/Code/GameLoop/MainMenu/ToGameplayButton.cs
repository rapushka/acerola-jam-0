using UnityEngine.SceneManagement;

namespace Code
{
	public class ToGameplayButton : ButtonBase
	{
		protected override void OnClick() => SceneManager.LoadScene("Scenes/Gameplay Scene");
	}
}