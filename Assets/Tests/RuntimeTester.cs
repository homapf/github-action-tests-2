#if UNITY_EDITOR
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.TestTools.TestRunner.Api;
using UnityEngine;

public class RuntimeTester : ICallbacks
{
    private bool results = false;
    
    [MenuItem("Homa/test")]
    public static void Test()
    {
        Debug.Log("Launching Tests");
        var testRunnerApi = ScriptableObject.CreateInstance<TestRunnerApi>();
        var filter = new Filter()
        {
            testMode = TestMode.PlayMode,
            targetPlatform = BuildTarget.Android
        };
        testRunnerApi.Execute(new ExecutionSettings(filter));
        var tester = new RuntimeTester();
        testRunnerApi.RegisterCallbacks(tester);
        while (!tester.results)
        {
            Task.Delay(25);
        }
    }

    public void RunStarted(ITestAdaptor testsToRun)
    {
    }

    public void RunFinished(ITestResultAdaptor result)
    {
        Debug.Log($"Results : {result.ToXml().OuterXml}");
        results = true;
    }

    public void TestStarted(ITestAdaptor test)
    {
    }

    public void TestFinished(ITestResultAdaptor result)
    {
    }
}
#endif