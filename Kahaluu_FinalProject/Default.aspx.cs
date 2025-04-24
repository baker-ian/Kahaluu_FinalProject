using System;
using System.Web.UI.WebControls;
using Kahaluu_FinalProject.LeetCode;

namespace Kahaluu_FinalProject
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlProblem.Visible = false;
            }
        }

        /// <summary>
        /// Handles clicks from any of the four problem cards.
        /// CommandArgument holds the problem ID (1–4).
        /// </summary>
        protected void ProblemCard_Click(object sender, EventArgs e)
        {
            var link = sender as LinkButton;
            if (link == null) return;

            if (int.TryParse(link.CommandArgument, out int problemId))
            {
                DisplayProblem(problemId);
            }
        }

        /// <summary>
        /// Shows the description, test case, solution result, and an explanation.
        /// </summary>
        private void DisplayProblem(int id)
        {
            pnlProblem.Visible = true;

            switch (id)
            {
                case 1:
                    var p1 = new HandlingSumQueries();
                    litProblemDescription.Text = p1.GetProblemDescription();
                    litTestCase.Text = p1.GetTestCase();
                    var out1 = p1.SolveTestCase();
                    litSolutionResult.Text = "[" + string.Join(", ", out1) + "]";

                    litExplanation.Text =
                        "Built a segment tree to flip bits in nums1, " +
                        "applied the addition queries to nums2, " +
                        "and collected each sum for the type-3 queries.";
                    break;

                case 2:
                    var p2 = new ReverseSubarray();
                    litProblemDescription.Text = p2.GetProblemDescription();
                    litTestCase.Text = p2.GetTestCase();
                    int out2 = p2.SolveTestCase();
                    litSolutionResult.Text = out2.ToString();

                    litExplanation.Text =
                        "Calculated the base array value, " +
                        "evaluated all possible single reversals for maximum gain, " +
                        "and added that gain to the initial total.";
                    break;

                case 3:
                    var p3 = new DistinctEchoSubstrings();
                    litProblemDescription.Text = p3.GetProblemDescription();
                    litTestCase.Text = p3.GetTestCase();
                    int out3 = p3.SolveTestCase();
                    litSolutionResult.Text = out3.ToString();

                    litExplanation.Text =
                        "Used a rolling-hash approach to detect and count " +
                        "all distinct substrings that form an 'a+a' pattern.";
                    break;

                case 4:
                    var p4 = new SelectCellsInGrid();
                    litProblemDescription.Text = p4.GetProblemDescription();
                    litTestCase.Text = p4.GetTestCase();
                    int out4 = p4.SolveTestCase();
                    litSolutionResult.Text = out4.ToString();

                    litExplanation.Text =
                        "Sorted each row by value, then greedily picked " +
                        "the highest unused values across rows to maximize sum.";
                    break;

                default:
                    litProblemDescription.Text = "Unknown problem.";
                    litTestCase.Text = "";
                    litSolutionResult.Text = "";
                    litExplanation.Text = "";
                    break;
            }
        }
    }
}
