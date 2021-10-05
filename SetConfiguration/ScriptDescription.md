The second task is to write a shell script (to run on the Bourne shell) that allows a user to view, 
add, or delete a setting in a configuration file **(config.txt)** that contains settings in the  form 
**variable=value**. The following is an example of such configuration file:

```
HOME=/home/abc
HOST=alacritas
HOSTTYPE=sun4
LOGNAME=abc
OSTYPE=linux
PATH=/usr/dt/bin:/usr/openwin/bin:/bin:.
PS1=$ 
PS2=> 
SHELL=/usr/bin/tcsh
TZ=Australia/Tasmania
USER=abc
VENDOR=sun
EDITOR=joe
```
Your script for this task must be named **setting.sh**. For ease of use, your script must present a 
menu of operations that a user may choose from. After the user makes a selection and that the selected operation has been completed,  the menu must be displayed again so that the user can make another selection. Validation check on user inputs is required  (see the following sample output about this). In the beginning of your script you need to check to see whether the required configuration file **(config.txt)** actually exists under the current directory  (if not,  your script displays a message and then exits).
### Sample Output

Here is a sample output of your script. The $ is the shell prompt. The texts in & are not part of the sample output. They are hints indicating how your script should behave

```
$ ./setting.sh

*** MENU ***
1. Add a Setting
2. Delete a Setting
3. View a Setting
4. View All Settings
Q – Quit

CHOICE: 1 &(user input)&
Enter setting (format: ABCD=abcd): &(user simply presses the Enter/Return key)&
New setting not entered

Enter setting (format: ABCD=abcd): EDITOR &(user input)&
Invalid setting &(A valid setting needs to contain a “=” sign)&

Enter setting (format: ABCD=abcd): EDITOR= &(user input)&
The variable name of the setting is: EDITOR
The variable value of the setting is: 
Invalid setting.
&(Hint: To retrieve a variable name before the “=” sign, research the expr command’s ability in handling strings)&

Enter setting (format: ABCD=abcd): =vi &(user input)&
The variable name of the setting is: 
The variable value of the setting is: vi
Invalid setting.

Enter setting (format: ABCD=abcd): 1EDITOR=vi &(user input)&
The variable name of the setting is: 1EDITOR
The variable value of the setting is: vi
Invalid setting. The first character of a variable name cannot be a digit.

Enter setting (format: ABCD=abcd): EDITOR=vi &(user input)&
The variable name of the setting is: EDITOR
The variable value of the setting is: vi

New setting added.

*** MENU ***
1. Add a Setting
2. Delete a Setting
3. View a Setting
4. View All Settings
Q - Quit
CHOICE: 1 &(user input)&

Enter setting (format: ABCD=abcd): USER=jchen &(user input)&
The variable name of the setting is: USER
The variable value of the setting is: jchen
Variable exists. Changing the values of existing variables is not allowed.

*** MENU ***
1. Add a Setting
2. Delete a Setting
3. View a Setting
4. View All Settings
Q - Quit
CHOICE: 2 &(user input)&

Enter variable name: EDTOR &(user input)&
Variable does not exist. &(Your script needs to check whether a variable exists or not)&

*** MENU ***
1. Add a Setting
2. Delete a Setting
3. View a Setting
4. View All Settings
Q - Quit
CHOICE: 2 &(user input)&

Enter variable name: EDITOR &(user input)&
EDITOR=vi
Delete this setting (y/n)? y &(user input)&
Setting deleted &(However, if user’s answer is n here, then the setting stays)&

*** MENU ***
1. Add a Setting
2. Delete a Setting
3. View a Setting
4. View All Settings
Q - Quit
CHOICE: 3 &(user input)&

Enter variable name:USER1 &(user input)&
Variable does not exist. &(Your script needs to check whether a variable exists or not)&

*** MENU ***
1. Add a Setting
2. Delete a Setting
3. View a Setting
4. View All Settings
Q - Quit
CHOICE: 3 &(user input)&

Enter variable name: USER &(user input)&
USER=abc 
Requested setting displayed above.

*** MENU ***
1. Add a Setting
2. Delete a Setting
3. View a Setting
4. View All Settings
Q - Quit
CHOICE: 4 &(user input)&

HOME=/home/abc 
HOST=alacritas 
HOSTTYPE=sun4 
LOGNAME=abc 
OSTYPE=linux 
PATH=/usr/dt/bin:/usr/openwin/bin:/bin:. 
PS1=$ 
PS2=> 
SHELL=/usr/bin/tcsh 
TZ=Australia/Tasmania 
USER=abc 
VENDOR=sun
 
*** MENU ***
1. Add a Setting
2. Delete a Setting
3. View a Setting
4. View All Settings
Q - Quit
CHOICE: 5 &(user input)&
Invalid choice.

*** MENU ***
1. Add a Setting
2. Delete a Setting
3. View a Setting
4. View All Settings
Q - quit
CHOICE: q &(user input)&
&(The running script is terminated. The shell prompt is displayed)&
```
