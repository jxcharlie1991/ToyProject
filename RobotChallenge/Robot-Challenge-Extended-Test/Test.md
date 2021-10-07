# Robot Challenge Extended Test
1. The first command only allows PLACE commands, so there would be three types invalid first command that cause the alarming
```
MOVE

OUTCOME: INVALID

PLACE 3,2,MOVE

OUTCOME: INVALID

PLACE 5,5,EAST

OUTCOME: INVALID
```
![First Invalid Command](https://github.com/jxcharlie1991/ToyProject/blob/main/RobotChallenge/Robot-Challenge-Extended-Test/FirstInvalidCommand.png)
2. The following command allows all the commands, except invalid command
```
PLACE 3,4,EAST
LEFT
LETT

OUTCOME: INVALID
```
![Invalid Command](https://github.com/jxcharlie1991/ToyProject/blob/main/RobotChallenge/Robot-Challenge-Extended-Test/InvalidCommand.png)
3. If MOVE command require the robot falls off the table, there would be alarming
```
PLACE 2,3,EAST
MOVE
MOVE
MOVE

OUTCOME: INVALID
```
![Falling Command](https://github.com/jxcharlie1991/ToyProject/blob/main/RobotChallenge/Robot-Challenge-Extended-Test/FallingCommand.png)
4. When user inputs the invalid command, the program would give alarming, then ignore the invalid command.
```
PLACE 3,4,EAST
LEFT
LETT

OUTCOME: INVALID
REPORT

OUTCOME: 3,4,NORTH  ACTIVE
```

```
PLACE 1,2,NORTH
MOVE
MOVE
MOVE

OUTCOME: INVALID
LEFT
MOVE
REPORT

OUTCOME: 0,4,WEST  ACTIVE
```

![Invalid Command Would Ignore](https://github.com/jxcharlie1991/ToyProject/blob/main/RobotChallenge/Robot-Challenge-Extended-Test/InvalidCommandWouldIgnore.png)

![Falling Command Would Ignore](https://github.com/jxcharlie1991/ToyProject/blob/main/RobotChallenge/Robot-Challenge-Extended-Test/FallingCommandWouldIgnore.png)
5. Valid Command
```
PLACE 3,2,NORTH
MOVE
LEFT
MOVE
REPORT

OUTCOME: 2,3,WEST  ACTIVE
```

```
PLACE 3,2,EAST
MOVE
RIGHT
MOVE
REPORT

OUTCOME: 4,1,SOUTH  ACTIVE
```
![Valid1](https://github.com/jxcharlie1991/ToyProject/blob/main/RobotChallenge/Robot-Challenge-Extended-Test/Valid1.png)

![Valid2](https://github.com/jxcharlie1991/ToyProject/blob/main/RobotChallenge/Robot-Challenge-Extended-Test/Valid2.png)
5. Change Command allow user to active specific robot
```
PLACE 3,2,EAST
ROBOT 1 is added on the table.
place 1,2,WEST
ROBOT 2 is added on the table.
PLACE 2,2,NORTH
ROBOT 3 is added on the table.
REPORT

OUTCOME: ROBOT 1: 3, 2, EAST
         ROBOT 2: 1, 2, WEST
         ROBOT 3: 2, 2, NORTH    ACTIVE.

ROBOT 2
REPORT

OUTCOME: ROBOT 1: 3, 2, EAST
         ROBOT 2: 1, 2, WEST    ACTIVE.
         ROBOT 3: 2, 2, NORTH

ROBOT 4

OUTCOME: Please select a valid robot. There are only 3 robots on the desk

```
![Valid3](https://github.com/jxcharlie1991/ToyProject/blob/main/RobotChallenge/Robot-Challenge-Extended-Test/Valid3.png)

