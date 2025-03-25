Feature: Data Definition


Scenario Simple Comparison 
Given table is # ListOfObject ATest 
| anInt  | aString    | aDouble  |
| 1      | something  | 1.2      |
When compared to # ListOfObject ATest Compare 
| aString    | 
| something  | 
Then result is 
| true | 
When compared to # ListOfObject ATest Compare 
| aString         | 
| something else  | 
Then result is 
| false| 


# will create an internal class name 
Data ATest 
| Name     | Default  | Datatype  | Note  |
| anInt    | 0        | Int       |       |
| aString  | ~        | String    |       |
| aDouble  | 4.0      | Double    |       |

# will create a .tmpl file for Existing 

Data TestIn Existing 
| Name    | Default  | Datatype  | Note  |
| aValue  | 0        | int       |       |
| bValue  | ~        | String    |       |
| cValue  | 4.0      | double    |       |



