#if UNITY_EDITOR
using System;
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
            targetPlatform = BuildTarget.Android
        };
        testRunnerApi.Execute(new ExecutionSettings(filter)
        {
            runSynchronously = true,
            playerHeartbeatTimeout = Int32.MaxValue
        });
        var tester = new RuntimeTester();
        testRunnerApi.RegisterCallbacks(tester);
    }

    public void RunStarted(ITestAdaptor testsToRun)
    {
    }

    public void RunFinished(ITestResultAdaptor result)
    {
        Debug.Log($"Results : {result.ToXml().OuterXml}");
        EditorApplication.Exit(0);
    }

    public void TestStarted(ITestAdaptor test)
    {
    }

    public void TestFinished(ITestResultAdaptor result)
    {
    }
}
#endif