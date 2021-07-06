using Core;
using Unity;

namespace DiyBox.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			var dependencyProvider = new DiyBoxDependencyProvider(new UnityContainer().AddExtension(new Diagnostic()));
			dependencyProvider.RegisterDependencies();
			var app = dependencyProvider.Container.Resolve<IConsoleApp>();
			app.Main(args);
		}
	}
}