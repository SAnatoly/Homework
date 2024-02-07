using GameInput;
using ShootEmUp;

namespace Zenject.Installer
{
    public sealed class LevelInstaller: MonoInstaller
    {
        public MoveComponent character;
        
        public override void InstallBindings()
        {
            CharacterBind();
        }

        private void CharacterBind()
        {
            Container.Bind<CharacterAttackController>().AsCached().NonLazy();
            Container.BindInterfacesAndSelfTo<KeyboardInput>().AsCached();
            Container.Bind<MoveComponent>().FromInstance(character).AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<CharacterMoveAgent>().AsCached();
            Container.BindInterfacesAndSelfTo<CharacterAttackAgent>().AsCached();
            Container.Bind<CharacterMoveController>().AsCached().NonLazy();
        }
    }
}