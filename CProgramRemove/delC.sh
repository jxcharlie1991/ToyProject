#! /bin/sh
#1. Without arguments supplied, the script will find all the C programs in the current directory,
#and lists the fist 10 lines of each, then it prompts for deletion of the file.
#2. With arguments supplied(C program file names) by users, the script will work on the files only. 
echo -e "This script removes C files which you no longer want to keep."
#Firstly, the script need to distinguish whether user supplies arguments.      
if test $# -eq 0 
then
	echo "Here are the C file(s) under the current directory: "
	#The script need to find out there is or not any C programs in the current directory.
	#If there is not any C programs, the outputs would be nothing, so we could count the words count. 
	if test `find . -name "*.c" | wc -w` -eq 0
	then
		echo "No C files found."
	else
                #Assign all the C programs into string 'x'.
                #Use *.c to ensure find C programs.
                x=`ls *.c`
                echo $x
                #Distinguish how many files are there in the current directory.
		#Use 'for' command to ensure all the C programs will be dealt with.
		for file in $x
		do
	                echo -e "\nDisplaying first 10 lines of $file: \n"
			#Print first 10 lines.
			cat $file | head -10
			echo -e "\nDelete file $file? (y/n): \c"
			#Assign user's choice to the uinput, and deal with the C programs.
			read uinput
			case $uinput in
			y|Y) rm $file
			     echo "File $file deleted." ;;
			n|N) echo "File $file NOT deleted." ;;
			*)   echo "Invalid option" ;;
			esac
		done
	fi
else
	echo "The file(s) you want to delete is/are: "
	#Print all user's supplied arguments.
	echo -e "$*"
	#Use 'for' command to ensure all the user's supplied arguments will be dealt with.
	for file in $*
	do
		echo -e "\nDisplaying first 10 lines of $file: \n"
		#Distinguish whether the file exist. 
		if test ! -f $file 
		then
			#It means the file doesn't exist.
			echo "File $file does not exist. "
		else
			#If the file exist, print first 10 lines.
			cat $file | head -10
			echo -e "\nDelete file $file? (y/n): \c"
			#Assign user's choice to the uinput, and deal with the C programs.
			read uinput
			case $uinput in
			y|Y) rm $file
			     echo "File $file deleted." ;;
			n|N) echo "File $file NOT deleted." ;;
			*)   echo "Invalid option" ;;
			esac
		fi


	done
fi
