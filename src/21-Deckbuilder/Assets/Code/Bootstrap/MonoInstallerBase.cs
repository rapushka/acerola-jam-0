using Zenject;

namespace Code
{
	public abstract class MonoInstallerBase<TInstaller> : MonoInstaller<TInstaller>
		where TInstaller : MonoInstaller<TInstaller>
	{
		public override void InstallBindings()
		{
			Container.Rebind<SystemsFactory>().AsSingle();
		}
	}
}