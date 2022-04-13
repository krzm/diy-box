using Config.Wrapper.Unity;
using DiyBox.Core;
using Serilog.Wrapper.Unity;
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
	
	protected override void RegisterAppData()
    {
        RegisterSet<AppLoggerSet>();
        RegisterSet<AppConfigSet>();
    }

	protected override void RegisterConsoleInput() => 
		RegisterSet<AppInput>();

	protected override void RegisterConsoleOutput() => 
		RegisterSet<DescriptorSet>();

	protected override void RegisterProgram() => 
		RegisterSet<AppProgram<DiyBoxProgram>>();
}