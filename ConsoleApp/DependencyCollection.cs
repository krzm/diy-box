using Core.Lib;
using Unity;

namespace DiyBox.ConsoleApp
{
    public class DependencyCollection : UnityDependencyCollection
	{
        public DependencyCollection(
			IUnityContainer container) :
				base(container)
		{
        }

		protected override void RegisterDependencyProviders()
        {
            RegisterConsoleInput();
            RegisterConsoleOutput();
			RegisterProgram();
        }

		private void RegisterConsoleInput() => 
			RegisterDependencyProvider<AppInput>();

		private void RegisterConsoleOutput() => 
			RegisterDependencyProvider<AppOutput>();

        private void RegisterProgram() => 
			RegisterDependencyProvider<AppProgram<DiyBoxProgram>>();
    }
}