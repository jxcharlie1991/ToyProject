#! /bin/sh
#The scropt allows user to view, add, or delete a setting in config.txt that contains settings in the form 'variable=value'.
#The script is a looping until user choose to quit, so I choose while as its basic structure.
while test "$uinput0" != "Q" -a "$uinput0" != "q"
do
        #According to the requirement, the script needs a menu for easy operating.
        echo -e "\n*** MENU ***"
        echo '1. Add a Setting'
        echo '2. Delete a Setting'
        echo '3. View a Setting'
        echo '4. View All Settings'
        echo 'Q – Quit'
        echo -e "\nCHOICE: \c"
        read uinput0
        case $uinput0 in
           #State a variable result and while looping to keep the script wouldn't step back until user types a valid command.
        1) result=default
           #Use 'while' to ensure if user types a valid command, the step would stop.
           while test "$result" != "success"
           do
                 echo -e "\nEnter setting (format: ABCD=abcd): \c"
                 read uinput1
                 #Use 4 'if' and 1 'while' loopings to keep the script identifys 6 kinds of wrong  and 1 right inputs.
                 #The 5 loopings first identify whether it is empty, then identify whether it has a "=", and it has three conditions,
                 #one lacks variable name, one lacks variable value, the other is a right statement. However, according to linux's
                 #syntax, variable name's first word couldn't be number, so the script need to identify it. Finally, a right and syntactic
                 #statement could also be wrong if there has already existed a same variable name, so the script need to identify it.
                 if test -z "$uinput1"
                 then
                         echo   "New setting not entered."
                 else
                         #Use [[]]and =~ to ensure the variable uinput1 have a '='.
                         if [[ "$uinput1" =~ '=' ]]
                         then
                                 echo "The variable name of the setting is: `echo $uinput1 | cut -f 1 -d '='`"
                                 echo "The variable value of the setting is: `echo $uinput1 | cut -f 2 -d '='`"
                                 #Test whether input has a variable name.
                                 if test -z `echo $uinput1 | cut -f 1 -d '='` 2> /dev/null
                                 then
                                         echo   "Invalid setting."
                                 #Test whether input has a variable value.
                                 elif test -z `echo $uinput1 | cut -f 2 -d '='` 2> /dev/null
                                 then
                                         echo   "Invalid setting."
                                 else
                                         #Test whether the variable name begins with a number.
                                         case   `echo $uinput1 | cut -c 1` in
                                         [0-9])  echo "Invalid setting. The first character of a variable name cannot be a digit." ;;
                                                 #Test whether the variable name exist in config.txt.
                                         *)      if cat config.txt | cut -f 1 -d '=' | grep `echo $uinput1 | cut -f 1 -d '='`  > /dev/null
                                         then
                                                 echo "Variable exists. Changing the values of existing variables is not allowed."
                                                 result=success
                                         else
                                                 #Now, it is a kind of valid statement, so the script needs to add the setting. 
                                                 echo $uinput1 >> config.txt
                                                 echo -e "\nNew setting added."
                                                 result=success
                                         fi ;;
                                         esac
                                 fi
                         else
                                 echo  "Invalid setting."
                         fi
                 fi
           done ;;
           #'Delete' needs to identigy whether the variable name exist, the script use 'if' looping to do that.
        2) echo -e "\nEnter variable name:\c"
           read uinput1
           #Identify whether the variable exists or not, in the config.txt
           if cat config.txt | cut -f 1 -d '=' | grep "$uinput1"  > /dev/null
           then
                   echo `grep "$uinput1" config.txt`
                   echo -e "Delete this setting (y/n)? \c"
                   read uinput2
                   case $uinput2 in
                   Y|y) sed -i "/$uinput1/d" config.txt
                        echo "Setting deleted." ;;
                   N|n) echo "Setting stays." ;;
                   *)   echo "Invalid option." ;;
                   esac
           else
                   echo "Variable does not exist."
           fi ;;
           #View a setting needs to identigy whether the variable name exist, the script use 'if' looping to do that.
        3) echo -e "\nEnter variable name: \c"
           read uinput1
           if cat config.txt | cut -f 1 -d '=' | grep "$uinput1"  > /dev/null
           then
                   echo `grep "$uinput1" config.txt`
                   echo "Requested setting displayed above."
           else
                   echo "Variable does not exist."
           fi ;;
           #'cat' command is easy to view all the settings
        4) echo
           cat config.txt ;;
        Q|q) ;;
        *) echo -e "\nInvalid option." ;;
        esac
done
