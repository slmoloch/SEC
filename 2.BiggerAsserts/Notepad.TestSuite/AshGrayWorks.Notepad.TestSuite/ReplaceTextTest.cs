using ApprovalTests.Reporters;
using AshGrayWorks.Notepad.TestFixture.Flows;
using AshGrayWorks.UiTests.Base;
using NUnit.Framework;

namespace AshGrayWorks.Notepad.TestSuite
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter))]
    public class ReplaceTextTest : BaseTest<MainFlow>
    {
        [Test]
        public void ReplaceAllShouldReplaceTheFirstWord()
        {
            Start
                .EnterText("Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.")
                .OpenReplaceDialog()
                    .EnterFindWhat("elit")
                    .EnterReplaceWith("tile")
                    .ReplaceAll()
                    .Close()
                .AssertText("Lorem ipsum dolor sit amet, consectetur adipisicing tile, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.");
        }

        [Test]
        public void ActionsOnReplaceDialogShouldBeEnabledOnlyWhenActionable()
        {
            Start
                .OpenReplaceDialog()
                    .AssertFindNextButtonEnabled(false)
                    .AssertReplaceButtonEnabled(false)
                    .AssertReplaceAllButtonEnabled(false)
                    .AssertCancelButtonEnabled(true)
                    .EnterFindWhat("a")
                    .AssertFindNextButtonEnabled(true)
                    .AssertReplaceButtonEnabled(true)
                    .AssertReplaceAllButtonEnabled(true)
                    .AssertCancelButtonEnabled(true)
                    .EnterFindWhat("")
                    .AssertFindNextButtonEnabled(false)
                    .AssertReplaceButtonEnabled(false)
                    .AssertReplaceAllButtonEnabled(false)
                    .AssertCancelButtonEnabled(true);
        }

        [Test]
        public void ActionsOnReplaceDialogShouldBeEnabledOnlyWhenActionableWithAppovals()
        {
            Start
                .OpenReplaceDialog()
                    .RememberActionStatuses("Initial State")
                    .EnterFindWhat("a")
                    .RememberActionStatuses("'Find What' contains value, so all buttons should be enabled")
                    .EnterFindWhat("")
                    .RememberActionStatuses("When 'Find What' had cleaned, all buttons should to be disabled again");

            Verify();
        }
    }
}
