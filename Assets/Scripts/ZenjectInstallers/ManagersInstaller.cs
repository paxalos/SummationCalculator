using Managers;
using Zenject;
using UnityEngine;

namespace ZenjectInstallers
{
    public class ManagersInstaller : MonoInstaller
    {
        [SerializeField] private PopupsManager popupsManagerPrefab;

        public override void InstallBindings()
        {
            Container.Bind<PopupsManager>().FromComponentInNewPrefab(popupsManagerPrefab).AsSingle();
        }
    }
}