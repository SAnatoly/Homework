using ShootEmUp;
using Zenject;

public sealed class BootstrapInstaller : MonoInstaller<BootstrapInstaller>
{
   public override void InstallBindings()
   {
      Container.Bind<ILogger>().To<Logger>().AsSingle().NonLazy();
      Container.Bind<CharacterAttackAgent>().AsSingle().NonLazy();
   }
}
