using UnityEngine;
using Zenject;

public class GunSettingsInstaller : MonoInstaller
{
    [SerializeField] private GunSettings _gunM107Settings1;
    //[SerializeField] private GunSettings _gunM107Settings2;
    public override void InstallBindings()
    {
        //Container.Bind<IGunCharacter>().FromInstance(_gunM107Settings1);

        // Или dummy-версия
        //Container.Bind<IGunCharacter>().To<GunSettingsBehaviour>().AsSingle();
    }
}