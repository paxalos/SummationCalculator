using Game;
using Zenject;
using UnityEngine;
using Savers;

namespace ZenjectInstallers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private CalculatorView calculatorView;

        public override void InstallBindings()
        {
            Container.Bind<CalculatorPresenter>().To<SummationCalculatorPresenter>().AsTransient();
            Container.Bind<ResultsSaver>().To<FileResultsSaver>().AsTransient();
            Container.Bind<InputSaver>().To<PlayerPrefsInputSaver>().AsTransient();
            Container.BindInterfacesAndSelfTo<CalculatorModel>().AsTransient();
            Container.BindInstance(calculatorView).AsSingle();
        }
    }
}