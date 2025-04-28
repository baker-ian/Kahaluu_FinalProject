<!--
 *File Name: HandlingSumQueries.cs

* Name: Ian Baker, Zulqarnayan Hossain, Leah T slassie, Mariah Jenkins
* email: bakerin@mail.uc.edu, hossaizn@mail.uc.edu, tslassll@mail.uc.edu, jenkim3@mail.uc.edu
* Assignment Number: Final Project
* Due Date:  4/29/2025
* Course #/Section: IS3050-001
* Semester/Year:   Spring 2025
* Brief Description of the assignment:  This assignment included the team creating a project in Visual Studio that is a web page displaying 4 different Leetcode problems and their solutions. The languages used to build the web page are C# and ASP.Net.

* Brief Description of what this module does. Defines the user interface, displaying clickable problem cards and a dynamic area to show problem details and results.
* Citations: https://chat.openai.com/
	     https://claude.ai/ 
-->
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Kahaluu_FinalProject.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Kahaluu LeetCode Solutions</title>

    <!-- Bootstrap CSS -->
    <link 
      href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" 
      rel="stylesheet" 
      integrity="sha384-9ndCyUaIbzAi2FUVXJi0CjmCapSmO7SnpJef0486qhLnuZ2cdeRhO02iuK6FUUVM" 
      crossorigin="anonymous" />

    <style>
        /* Card styling */
        .problem-card {
          border: none;
          border-radius: 0.5rem;
          color: white;
          height: 100%;
          display: flex;
          flex-direction: column;
          justify-content: space-between;
          cursor: pointer;
          transition: transform .2s;
        }
        .problem-card:hover {
          transform: scale(1.05);
        }
        .problem-card .card-header {
          font-size: 1.25rem;
          font-weight: bold;
          padding: 1rem;
        }
        .problem-card .card-body {
          flex-grow: 1;
          padding: 1rem;
        }
        .badge-diff {
          display: inline-block;
          background: rgba(255,255,255,0.8);
          color: #333;
          border-radius: 1rem;
          padding: 0.25rem 1rem;
          font-size: 0.875rem;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4">

         <!-- Page Header -->
         <div class="text-center mb-4">
             <h1 class="display-4">Kahaluu LeetCode Problems</h1>
             <p class="lead">
                 Team Members: Ian Baker, Leah T Slassie, Mariah Jenkins, Zulqarnayan Hossain
             </p>
         </div>

            <!-- row of 4 problem cards -->
            <div class="row mb-4">

              <!-- Problem 2569 -->
              <div class="col-md-3 mb-3">
                <asp:LinkButton runat="server" CssClass="text-decoration-none" OnClick="ProblemCard_Click" CommandArgument="1">
                  <div class="card problem-card bg-primary">
                    <div class="card-header text-center">Problem 2569</div>
                    <div class="card-body text-center">Handling Sum Queries After Update</div>
                    <div class="card-footer text-center bg-transparent border-0 mb-2">
                      <span class="badge-diff">Hard</span>
                    </div>
                  </div>
                </asp:LinkButton>
              </div>

              <!-- Problem 1330 -->
              <div class="col-md-3 mb-3">
                <asp:LinkButton runat="server" CssClass="text-decoration-none" OnClick="ProblemCard_Click" CommandArgument="2">
                  <div class="card problem-card bg-success">
                    <div class="card-header text-center">Problem 1330</div>
                    <div class="card-body text-center">Reverse Subarray To Maximize Array Value</div>
                    <div class="card-footer text-center bg-transparent border-0 mb-2">
                      <span class="badge-diff">Hard</span>
                    </div>
                  </div>
                </asp:LinkButton>
              </div>

              <!-- Problem 1316 -->
              <div class="col-md-3 mb-3">
                <asp:LinkButton runat="server" CssClass="text-decoration-none" OnClick="ProblemCard_Click" CommandArgument="3">
                  <div class="card problem-card bg-danger">
                    <div class="card-header text-center">Problem 1316</div>
                    <div class="card-body text-center">Distinct Echo Substrings</div>
                    <div class="card-footer text-center bg-transparent border-0 mb-2">
                      <span class="badge-diff">Hard</span>
                    </div>
                  </div>
                </asp:LinkButton>
              </div>

              <!-- Problem 3276 -->
              <div class="col-md-3 mb-3">
                <asp:LinkButton runat="server" CssClass="text-decoration-none" OnClick="ProblemCard_Click" CommandArgument="4">
                  <div class="card problem-card" style="background: #4dd0e1;">
                    <div class="card-header text-center">Problem 3276</div>
                    <div class="card-body text-center">Select Cells in Grid with Maximum Value</div>
                    <div class="card-footer text-center bg-transparent border-0 mb-2">
                      <span class="badge-diff">Hard</span>
                    </div>
                  </div>
                </asp:LinkButton>
              </div>

            </div>

            <!-- details panel (initially hidden) -->
            <asp:Panel ID="pnlProblem" runat="server" Visible="false">
              <div class="card">
                <div class="card-header bg-success text-white">
                  <h4>Problem Details</h4>
                </div>
                <div class="card-body">
                  <h5>Description</h5>
                  <pre><asp:Literal ID="litProblemDescription" runat="server" /></pre>

                  <h5 class="mt-3">Test Case</h5>
                  <pre><asp:Literal ID="litTestCase" runat="server" /></pre>

                  <!-- Solution Result -->
                  <div class="mt-4">
                    <h5>Solution Result</h5>
                    <pre><asp:Literal ID="litSolutionResult" runat="server" /></pre>
                  </div>

                  <!-- Explanation -->
                  <div class="mt-3">
                    <h6>Explanation</h6>
                    <pre><asp:Literal ID="litExplanation" runat="server" /></pre>
                  </div>

                </div>
              </div>
            </asp:Panel>

        </div>

        <!-- Bootstrap JS bundle -->
        <script 
          src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js" 
          integrity="sha384-geWF76RCwLtnZ8qwWowPQNguL3RmwHVBC9FhGdlKrxdiJJigb/j/68SIy3Te4Bkz" 
          crossorigin="anonymous">
        </script>
    </form>
</body>
</html>
