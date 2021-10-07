# Robot Challenge Basic Test
1. The first command only allows PLACE commands, so there would be three types invalid first command that cause the alarming
```
MOVE
PLACE 3,2,MOVE
PLACE 5,5,EAST

OUTCOME: INVALID
```
![First Invalid Command](https://github.com/jxcharlie1991/ToyProject/blob/main/RobotChallenge/Robot-Challenge-Basic-Test/FirstInvalidCommand.png)
2. The following command allows all the commands, except invalid command
```
PLACE 3,4,EAST
LEFT
LETT

OUTCOME: INVALID
```
![Invalid Command](https://github.com/jxcharlie1991/ToyProject/blob/main/RobotChallenge/Robot-Challenge-Basic-Test/InvalidCommand.png)
3. If MOVE command require the robot falls off the table, there would be alarming
```
PLACE 2,3,EAST
MOVE
MOVE
MOVE

OUTCOME: INVALID
```
![Falling Command](https://github.com/jxcharlie1991/ToyProject/blob/main/RobotChallenge/Robot-Challenge-Basic-Test/FallingCommand.png)
4. When user inputs the invalid command, the program would give alarming, then ignore the invalid command.
```
PLACE 3,4,EAST
LEFT
LETT

OUTCOME: INVALID
REPORT

OUTCOME: 3,4,NORTH
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

OUTCOME: 0,4,WEST
```

![Invalid Command Would Ignore](https://github.com/jxcharlie1991/ToyProject/blob/main/RobotChallenge/Robot-Challenge-Basic-Test/InvalidCommandWouldIgnore.png)

![Falling Command Would Ignore](https://github.com/jxcharlie1991/ToyProject/blob/main/RobotChallenge/Robot-Challenge-Basic-Test/FallingCommandWouldIgnore.png)
5. Valid Command
```
PLACE 3,2,NORTH
MOVE
LEFT
MOVE
REPORT

OUTCOME: 2,3,WEST
```

```
PLACE 3,2,EAST
MOVE
RIGHT
MOVE
REPORT

OUTCOME: 4,1,SOUTH
```
![Valid1](https://github.com/jxcharlie1991/ToyProject/blob/main/RobotChallenge/Robot-Challenge-Basic-Test/Valid1.png)

![Valid2](https://github.com/jxcharlie1991/ToyProject/blob/main/RobotChallenge/Robot-Challenge-Basic-Test/Valid2.png)
