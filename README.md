# Gherkin Executor for C#

The Gherkin Executor for C# converts Gherkin files into unit tests.   

See the full documentation at [GherkinExecutorForJava/README.md at main · atdd-bdd/GherkinExecutorForJava · GitHub](https://github.com/atdd-bdd/GherkinExecutorForJava/blob/main/README.md)



This documents the  setup required for C#.    It assumes you have some experience with running unit tests in Visual Studio.   

### Setup

- :Create a MSTest or NUnit test project 

-  Add a folder:   `GherkinExecutor  `

- Go to [GitHub - atdd-bdd/GherkinExecutorForCSharp](https://github.com/atdd-bdd/GherkinExecutorForCSharp)
  
  Download` translate.cs`  [GherkinExecutorForCSharp/Translaste.cs at main · atdd-bdd/GherkinExecutorForCSharp · GitHub](https://github.com/atdd-bdd/GherkinExecutorForCSharp/blob/main/Translaste.cs)
  
  Into `GherkinExecuto`r folder, download starting.feature [GherkinExecutorForCSharp/GherkinExecutor/starting.feature at main · atdd-bdd/GherkinExecutorForCSharp · GitHub ](https://github.com/atdd-bdd/GherkinExecutorForCSharp/blob/main/GherkinExecutor/starting.feature)

- In the `GherkinExecutor `folder, create a `features.tx`t file that contains 

```
starting.feature 
```

        In the same folder, create a` options.tx`t file that is empty 

- Edit the `csproj `file for the project.   

        Add a line in the `PropertyGroup` 

```

    \<StartupObject>GherkinExecutorForCSharp.Translate</StartupObject>
```

- Change the test framework, if necessary, in Translate.cs 

```
  public static readonly string TestFramework = "MSTest";
  // Could be "NUnit" 
```

- Run the program  

        Go to the `Feature_Starting_glue `folder 

        Rename` Feature_Starting_glue.tmp`l to `Feature_Starting_glue.cs `

       Set the `Build Action `to` C# Compile` for this file

- Now` Run Tests`

        You should get one failure on` Feature_Starting` 

At this point, you can implement the production code to make the test pass.

If you add a `Scenario `to the feature file, you need to rerun `Translate`.     If you add new steps, you need to copy the new glue code from the `glue tmpl `file to the glue cs fie.  





options.txt contains the options 

Change the test framework to NUnit 





                                                    
Sequence comparison - add this  line to show how it is 

Must switch the build action to C# compiler after renaming the glue file from tmpl 

Must add in the app.config file the following line to enable the use of the SpecFlow+ Runner

```xml.

This project is a Gherkin Executor for C# that allows you to run Gherkin scenarios in C#.
                                                    
Sequence comparison - add this 

```


