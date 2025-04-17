using GherkinExecutorForCSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GherkinExecutor
{
    [TestClass]
    public class TestTagFilter
    {
        [TestMethod]
        public void TestNoTag()
        {
            Assert.IsTrue(Translate.TagFilterEvaluator.ShouldExecute(new HashSet<string> { "@A" }, ""), "Should execute when no filter");
        }

        [TestMethod]
        public void TestSingleTag()
        {
            Assert.IsTrue(Translate.TagFilterEvaluator.ShouldExecute(new HashSet<string> { "@A" }, "@A"), "Should execute when @A is present");
            Assert.IsFalse(Translate.TagFilterEvaluator.ShouldExecute(new HashSet<string> { "@B" }, "@A"), "Should NOT execute when @A is missing");
        }

        [TestMethod]
        public void TestAndCondition()
        {
            Assert.IsTrue(Translate.TagFilterEvaluator.ShouldExecute(new HashSet<string> { "@A", "@B" }, "@A AND @B"), "Should execute when @A and @B are present");
            Assert.IsFalse(Translate.TagFilterEvaluator.ShouldExecute(new HashSet<string> { "@A" }, "@A AND @B"), "Should NOT execute when @B is missing");
            Assert.IsFalse(Translate.TagFilterEvaluator.ShouldExecute(new HashSet<string> { "@B" }, "@A AND @B"), "Should NOT execute when @A is missing");
        }

        [TestMethod]
        public void TestOrCondition()
        {
            Assert.IsTrue(Translate.TagFilterEvaluator.ShouldExecute(new HashSet<string> { "@A" }, "@A OR @B"), "Should execute when @A is present");
            Assert.IsTrue(Translate.TagFilterEvaluator.ShouldExecute(new HashSet<string> { "@B" }, "@A OR @B"), "Should execute when @B is present");
            Assert.IsFalse(Translate.TagFilterEvaluator.ShouldExecute(new HashSet<string> { "@C" }, "@A OR @B"), "Should NOT execute when neither @A nor @B is present");
        }

        [TestMethod]
        public void TestNotCondition()
        {
            Assert.IsFalse(Translate.TagFilterEvaluator.ShouldExecute(new HashSet<string> { "@A" }, "NOT @A"), "Should NOT execute when @A is present");
            Assert.IsTrue(Translate.TagFilterEvaluator.ShouldExecute(new HashSet<string> { "@B" }, "NOT @A"), "Should execute when @A is missing");
            Assert.IsFalse(Translate.TagFilterEvaluator.ShouldExecute(new HashSet<string> { "@B", "@C" }, "NOT @B"), "Should NOT execute when @B is present");
        }

        [TestMethod]
        public void TestComplexExpression()
        {
            Assert.IsTrue(Translate.TagFilterEvaluator.ShouldExecute(new HashSet<string> { "@A", "@B" }, "@A AND @B OR @C"), "Should execute when @A and @B are present");
            Assert.IsTrue(Translate.TagFilterEvaluator.ShouldExecute(new HashSet<string> { "@C" }, "@A AND @B OR @C"), "Should execute when @C is present");
            Assert.IsFalse(Translate.TagFilterEvaluator.ShouldExecute(new HashSet<string> { "@D" }, "@A AND @B OR @C"), "Should NOT execute when no valid group matches");

            Assert.IsFalse(Translate.TagFilterEvaluator.ShouldExecute(new HashSet<string> { "@A", "@B" }, "NOT @A AND NOT @B"), "Should NOT execute when both @A and @B are present");
            Assert.IsTrue(Translate.TagFilterEvaluator.ShouldExecute(new HashSet<string> { "@C" }, "NOT @A AND NOT @B"), "Should execute when @A and @B are missing");
        }
    }
}