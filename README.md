# Gherkin Executor for C#

The Gherkin Executor for C# converts Gherkin files into unit tests.   

See the full documentation at [GitHub - atdd-bdd/GherkinExecutorBase: This is the base for Gherkin Executor containing Documentation and Examples](https://github.com/atdd-bdd/GherkinExecutorBase)

You can see an example of a featurex file at:

https://github.com/atdd-bdd/GherkinExecutorForCSharp/blob/main/GherkinExecutor/examples.featurex

The generated code, as well as the altered glue file are in this directory:: [

[GherkinExecutorForCSharp/GherkinExecutor/Feature_Examples at main · atdd-bdd/GherkinExecutorForCSharp · GitHub](https://github.com/atdd-bdd/GherkinExecutorForCSharp/tree/main/GherkinExecutor/Feature_Examples)

This documents the  setup required for C#.    It assumes you have some experience with running unit tests in Visual Studio.   

### Setup

- Create a MSTest or NUnit test project (or you can use an existing test project)

-  Add a folder:   `GherkinExecutor  `

- Go to [GitHub - atdd-bdd/GherkinExecutorForCSharp](https://github.com/atdd-bdd/GherkinExecutorForCSharp)
  Into `GherkinExecutor` folder:
  Download` translate.cs`  [GherkinExecutorForCSharp/Translaste.cs at main · atdd-bdd/GherkinExecutorForCSharp · GitHub](https://github.com/atdd-bdd/GherkinExecutorForCSharp/blob/main/Translaste.cs)
  Download starting.featurex [GherkinExecutorForCSharp/GherkinExecutor/starting.featurex at main · atdd-bdd/GherkinExecutorForCSharp · GitHub ](https://github.com/atdd-bdd/GherkinExecutorForCSharp/blob/main/GherkinExecutor/starting.featurex)

- In the `GherkinExecutor `folder, create a `features.txt` file that contains 

```
starting.featurex 
```

        In the same folder, create a `options.txt` file that is empty 

- Edit the `csproj `file for the project.   

        Add a line in the `PropertyGroup` 

```

    <StartupObject>GherkinExecutorForCSharp.Translate</StartupObject>
```

- Change the test framework, if necessary, in `Translate.cs` 

```
  public static readonly string TestFramework = "MSTest";
  // Could be "NUnit" 
```

- Run the program.  When it has executed: 

        Go to the `Feature_Starting_glue `folder 

        Rename` Feature_Starting_glue.tmp`l to `Feature_Starting_glue.cs `

       Set the `Build Action `to` C# Compiler` for this file

- Now` Run Tests`

        You should get one failure on` Feature_Starting` 

At this point, you can implement the production code to make the test pass.

If you add a `Scenario `to the feature file, you need to rerun `Translate`.     If you add new steps, you need to copy the new glue code from the `glue tmpl `file to the` glue cs` fie.  



If you want to compare two lists of objects, you can use the following.  Replace `ClassName `with the actual data class:
           bool result = expectedList.SequenceEqual(actualList, new ClassName.ClassNameComparer());
            Console.WriteLine("SequenceEqual: " + result);
