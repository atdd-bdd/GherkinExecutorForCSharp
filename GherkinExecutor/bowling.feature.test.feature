Feature: Bowling 

Scenario: A Game 
Given frame values are 
|         | 1  | 2  | 3  | 4  | 5  | 6  | 7  | 8  | 9  | 10  |
| Roll1   |    |    |    |    |    |    |    |    |    |     |
| Roll2   |    |    |    |    |    |    |    |    |    |     |
When rolls are 
|  3 | 6  | 7  | 3  |  10 | 10  | 10  | 
Then frame values become 
|        | 1  | 2  | 3   | 4   | 5  | 6   | 7  | 8  | 9  | 10  |
| Roll1  | 3  | 7  | 10  | 10  | 10 |     |    |    |    |     |
| Roll2  | 6  | 3  |     |     |    |    |    |    |    |     |
And next roll is for 
| Frame      | 6   |
| Roll       | 1   |
| Remaining  | 10  |
And game complete is 
| false | 

Domain Term:  Roll 
0 to 10   and TBD  (not yet rolled) 
Have an adder (to add two rolls)   returne TBD if sum is TBD 
♠space can represent a TBD  

Scenario: 
Given values for current frame are: 
| Roll1 | 7 | 
| Roll2 }   |
Then next roll is for 
| Roll       | 2  |
| Remaining  | 3  |

Given frame values are
|        | 1  | 2  | 3   | 4   | 5  | 6  | 7  | 8  | 9  | 10  |
| Roll1  | 3  | 7  | 10  | 10  | 10 |    |    |    |    |     |
| Roll2  | 6  | 3  |     |     |    |    |    |    |    |     |
Then frame scores are :
|        | 1  | 2  | 3    | 4    | 5  | 6  | 7  | 8  | 9  | 10  |
| Score  | 9  | 20 | 30   | TBD  | TBD|    |    |    |    |     |

Given frame scores are: 
|        | 1  | 2  | 3    | 4    | 5  | 6  | 7  | 8  | 9  | 10  |
| Score  | 9  | 20 | 30   | TBD  |TBD |    |    |    |    |     |
Then frame values are: 
|        | 1  | 2   | 3  | 4  | 5  | 6  | 7  | 8  | 9  | 10  |
| Mark1  | 3  | 7   |    |    |    |    |    |    |    |     |
| Mark2  | 6  | /   | X  | X  | X  |    |    |    |    |     |
| Mark3  |    |     |    |    |    |    |    |    |    |     |
| Score  | 9  | 29  | 59 |    |    |    |    |    |    |     |


# Display 
Given frame values are: 
|        | 1  | 2   | 3  | 4  | 5  | 6  | 7  | 8  | 9  | 10  |
| Mark1  | 3  | 7   |    |    |    |    |    |    |    |     |
| Mark2  | 6  | /   | X  | X  | X  |    |    |    |    |     |
| Mark3  |    |     |    |    |    |    |    |    |    |     |
| Score  | 9  | 29  | 58 |    |    |    |    |    |    |     |
And And next roll is for 
| Frame      | 6  |
| Roll       | 1  |
| Remaining  | 10 |
Then display should look like: 
#  Picture here 
#  Show the input display 


# Display rules

Scenario: 
Given next roll is for 
| Frame      | 6   |
| Roll       | 1   |
| Remaining  | 10  |
And game complete is 
| false | 
Then inputs are enabled:
| 0     | 1     | 2     | 3           | 4     | 5     | 6     | 7     | 8     | 9     | 10     | /     | X    |
| true  | true  | true  | true  true  | true  | true  | true  | true  | true  | true  | true   | false | true |
And new game is enabled
| false | 

Given next roll is for 
| Frame      | 6  |
| Roll       | 2  |
| Remaining  | 3  |
And game complete is 
| false | 
Then inputs are enabled:
| 0     | 1     |       | 3     | 4      | 5      | 6      | 7      | 8      | 9      | 10     | /     | X      |
| true  | true  | true  | true  | false  | false  | false  | false  | false  | false  | false  | true  | false  |
And new game is enabled
| false | 

Given next roll is for 
| Frame      | 6  |
| Roll       | 2  |
| Remaining  | 3  |
And inputs are enabled:
| 0     | 1     |       | 3     | 4      | 5      | 6      | 7      | 8      | 9      | 10     | /     | X      |
| true  | true  | true  | true  | false  | false  | false  | false  | false  | false  | false  | true  | false  |
Then inputs return
| 0  | 1  | 2  | 3  | /  |
| 0  | 1  | 2  | 3  | 3  |




Given game complete is 
| true | 
Then inputs are enabled:
| 0      | 1      |        | 3      | 4      | 5      | 6      | 7      | 8      | 9      | 10     | /      | X      |
| false  | false  | false  | false  | false  | false  | false  | false  | false  | false  | false  | false  | false  |
And new game is enabled
| true | 
