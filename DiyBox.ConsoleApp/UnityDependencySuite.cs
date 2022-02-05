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

	public override void Register()
	{
		//RegisterConsoleInput();
		//RegisterConsoleOutput();
		RegisterSet<DiyBoxDependencySet>();
		//RegisterProgram();
		base.Register();
	}

	protected override void RegisterConsoleInput() => 
		RegisterSet<AppInput>();

	protected override void RegisterConsoleOutput() => 
		RegisterSet<AppOutput>();

	protected override void RegisterProgram() => 
		RegisterSet<AppProgram<DiyBoxProgram>>();
}