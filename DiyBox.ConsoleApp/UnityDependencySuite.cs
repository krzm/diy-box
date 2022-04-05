using Unity;

namespace DiyBox.ConsoleApp;

public class UnityDependencySuite 
	: DIHelper.Unity.UnityDependencySuite
{
	public UnityDependencySuite(
		IUnityContainer container) :
			base(container)
	{
	}
	
	protected override void RegisterConsoleInput() => 
		RegisterSet<AppInput>();

	protected override void RegisterConsoleOutput() => 
		RegisterSet<AppOutput>();

	protected override void RegisterProgram() => 
		RegisterSet<AppProgram<DiyBoxProgram>>();
}