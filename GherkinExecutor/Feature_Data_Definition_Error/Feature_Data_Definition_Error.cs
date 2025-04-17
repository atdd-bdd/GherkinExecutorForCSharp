namespace gherkinexecutor.Feature_Data_Definition_Error{
using System.IO;
[TestClass]
public class Feature_Data_Definition_Error{
       void Log(string value)
            {
           try
           {
           Directory.CreateDirectory("GherkinExecutor/Feature_Data_Definition_Error");
	       using (var myLog = new StreamWriter("GherkinExecutor/Feature_Data_Definition_Error/log.txt", true))
	           {
	           myLog.WriteLine(value);
		        }
		   }
		   catch (IOException e)
		     	{
			    Console.Error.WriteLine("*** Cannot write to log " + e);
		      	}
		    }

        }
    }



