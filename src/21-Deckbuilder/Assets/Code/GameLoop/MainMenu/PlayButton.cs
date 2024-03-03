using UnityEngine.SceneManagement;

namespace Code
{
	public class PlayButton : ButtonBase
	{
		protected override void OnClick() => SceneManager.LoadScene("Scenes/Gameplay Scene");
	}
}