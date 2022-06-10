var target = Argument("target", "Test");
var configuration = Argument("configuration", "Debug");

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .WithCriteria(c => HasArgument("rebuild"))
    .Does(() =>
    {
        CleanDirectory($"../bin/{configuration}");
    });

Task("Build")
    .IsDependentOn("Clean")
    .Does(() =>
    {
        DotNetBuild("../SearchInspectionTool.sln", new DotNetBuildSettings
        {
            Configuration = configuration,
        });
    });

Task("Package")
    .IsDependentOn("Build")
    .Does(() => 
    {
        CreateDirectory($"../bin/{configuration}/package");
        CopyFiles($"../bin/{configuration}/net6.0/*.dll", $"../bin/{configuration}/package");
        CopyFiles($"../bin/{configuration}/net6.0-windows/*.dll", $"../bin/{configuration}/package");
        CopyFiles($"../bin/{configuration}/net6.0-windows/*.json", $"../bin/{configuration}/package");
        CopyFiles($"../bin/{configuration}/net6.0-windows/*.exe", $"../bin/{configuration}/package");
    });

Task("Test")
    .IsDependentOn("Package")
    .Does(() =>
    {
        DotNetTest("../SearchInspectionTool.sln", new DotNetTestSettings
        {
            Configuration = configuration,
            NoBuild = true,
        });
    });

//////////////////////////////////////////////////////////////////////
// EXECUTION
//////////////////////////////////////////////////////////////////////

RunTarget(target);