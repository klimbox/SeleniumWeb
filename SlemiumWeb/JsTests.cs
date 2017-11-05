using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSTest;
using JSTest.ScriptLibraries;

namespace SlemiumWeb
{
    [TestClass]
    public class JsTests
    {
        static private readonly TestScript TestScript = new TestScript();

        [ClassInitialize]
        static public void ClassSetUpScriptTests(TestContext tc)
        {
            TestScript.AppendFile(@"CalcScript.js");
            TestScript.AppendBlock(new JsAssertLibrary());
        }


        [DataTestMethod]
        [DataRow("5 + 3", "8")]
        [DataRow("85 - 17", "68")]
        [DataRow("3 * 4", "12")]
        [DataRow("4 / 2", "2")]
        [DataRow("5 / 0", "undefined")]

        [TestMethod]
        public void TestCount(string input, string exp)
        {
            TestScript.RunTest($"assert.equal({exp}, CountFromString('{input}'));");
        }
    }
}
