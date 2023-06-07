#if UNITY_EDITOR
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.TestTools.TestRunner.Api;
using UnityEngine;

public class RuntimeTester : ICallbacks
{
    [MenuItem("Homa/test")]
    public static void Test()
    {
        Debug.Log("Launching Tests");
        var testRunnerApi = ScriptableObject.CreateInstance<TestRunnerApi>();
        var filter = new Filter()
        {
            testMode = TestMode.PlayMode,
            targetPlatform = BuildTarget.StandaloneOSX
        };
        testRunnerApi.Execute(new ExecutionSettings(filter));
        var tester = new RuntimeTester();
        testRunnerApi.RegisterCallbacks(tester);
    }

    public void RunStarted(ITestAdaptor testsToRun)
    {
    }

    public void RunFinished(ITestResultAdaptor result)
    {
        Debug.Log($"Results : {result.ToXml().OuterXml}");
    }

    public void TestStarted(ITestAdaptor test)
    {
    }

    public void TestFinished(ITestResultAdaptor result)
    {
    }
}
#endif