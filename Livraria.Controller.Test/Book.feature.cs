﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.3.0.0
//      SpecFlow Generator Version:2.3.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Livraria.Controller.Test
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Book")]
    public partial class BookFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Book.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Book", "\tIn order to maintain the book inventory\r\n\tAs a user i want to create, update, de" +
                    "lete, and select books so that \r\n\tSo that i will be able to maintain the book in" +
                    "ventory", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Insert a valid book")]
        [NUnit.Framework.TestCaseAttribute("\'test\'", "\'test\'", null)]
        [NUnit.Framework.TestCaseAttribute("\'test name\'", "\'test author\'", null)]
        [NUnit.Framework.TestCaseAttribute("\'123 test\'", "\'123 test\'", null)]
        public virtual void InsertAValidBook(string name, string author, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Insert a valid book", exampleTags);
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
  testRunner.Given(string.Format("I have entered name {0} into the book page", name), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
       testRunner.And(string.Format("I have also entered author {0} into book page", author), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
      testRunner.When("I press add", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
      testRunner.Then("the result should be success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Edit a book")]
        [NUnit.Framework.TestCaseAttribute("1", "\'new test\'", "\'new value\'", null)]
        [NUnit.Framework.TestCaseAttribute("1", "\'new name\'", "\'new test\'", null)]
        [NUnit.Framework.TestCaseAttribute("1", "\'new value\'", "\'123\'", null)]
        public virtual void EditABook(string id, string name, string author, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Edit a book", exampleTags);
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
  testRunner.Given(string.Format("I have entered id {0} into the book page", id), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
    testRunner.And(string.Format("I have entered name {0} into the book page", name), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
       testRunner.And(string.Format("I have also entered author {0} into book page", author), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
      testRunner.When("I press Save", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 23
      testRunner.Then("the result should be success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Delete a book")]
        [NUnit.Framework.TestCaseAttribute("1", null)]
        public virtual void DeleteABook(string id, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete a book", exampleTags);
#line 31
this.ScenarioSetup(scenarioInfo);
#line 32
  testRunner.Given(string.Format("I have entered id {0} into the book page", id), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 33
      testRunner.When("I press Delete", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 34
      testRunner.Then("the result should be success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Select books by code")]
        [NUnit.Framework.TestCaseAttribute("1", null)]
        [NUnit.Framework.TestCaseAttribute("2", null)]
        [NUnit.Framework.TestCaseAttribute("3", null)]
        public virtual void SelectBooksByCode(string id, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Select books by code", exampleTags);
#line 40
this.ScenarioSetup(scenarioInfo);
#line 41
   testRunner.Given(string.Format("I have entered id {0} into the book page", id), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 42
   testRunner.When("I press Find", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 43
      testRunner.Then("the result should be success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Select books by name")]
        [NUnit.Framework.TestCaseAttribute("\'test\'", null)]
        [NUnit.Framework.TestCaseAttribute("\'te\'", null)]
        [NUnit.Framework.TestCaseAttribute("\'t\'", null)]
        public virtual void SelectBooksByName(string name, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Select books by name", exampleTags);
#line 51
this.ScenarioSetup(scenarioInfo);
#line 52
   testRunner.Given(string.Format("I have entered name {0} into the book page", name), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 53
   testRunner.When("I press Find", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 54
      testRunner.Then("the result should be success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Select books by author")]
        [NUnit.Framework.TestCaseAttribute("\'test\'", null)]
        [NUnit.Framework.TestCaseAttribute("\'te\'", null)]
        [NUnit.Framework.TestCaseAttribute("\'t\'", null)]
        public virtual void SelectBooksByAuthor(string author, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Select books by author", exampleTags);
#line 62
this.ScenarioSetup(scenarioInfo);
#line 63
   testRunner.Given(string.Format("I have entered author {0} into book page", author), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 64
   testRunner.When("I press Find", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 65
      testRunner.Then("the result should be success", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
