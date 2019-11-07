Imports GleamTech.Examples
Imports GleamTech.VideoUltimate

Public Class DefaultPage
    Inherits Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        exampleExplorer.VersionTitle = "v" & VideoUltimateConfiguration.AssemblyInfo.FileVersion.ToString()

        exampleExplorer.Examples = New ExampleBase() {
            New Example() With {
		        .Title = "Overview", 
		        .Url = "Overview.aspx", 
		        .SourceFiles = New String() {"Overview.aspx", "Overview.aspx.vb"}, 
		        .DescriptionFile = "Descriptions/Overview.html" 
	        },
            New Example() With {
		        .Title = "Reading video frames", 
		        .Url = "Reading.aspx", 
		        .SourceFiles = New String() {"Reading.aspx", "Reading.aspx.vb"}, 
		        .DescriptionFile = "Descriptions/Reading.html" 
	        }
        }

        exampleExplorer.ExampleProjectName = "ASP.NET Web Forms (VB)"
        exampleExplorer.ExampleProjects = ExamplesConfiguration.LoadExampleProjects(Server.MapPath("~/App_Data/ExampleProjects.json"))

    End Sub

End Class