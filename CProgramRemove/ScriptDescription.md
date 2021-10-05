Write a shell script (to run on the **Bourne** shell) that can be used to remove some old C programs you no longer wish to keep. When the script is run with no arguments supplied, it picks up each C program from the current directory and lists the first 10 lines (hint: research the **head** command). It then prompts for deletion of the file (the user can then choose to delete or not to delete the file). When the user supplies arguments (C program file names) with the script, it works on those files only.

Your script for this task **must** be named **delC.sh**. In designing your script you should consider 
the following scenarios:
* There is no C program file stored under the current directory;
* There is at least one C program file stored under the current directory;
* The user-supplied arguments list contains names of existing C programs stored under the current directory. We can assume that all the C programs have been correctly named as *.c, and that there are no special characters (such as space) in any of these filenames;
* The user-supplied arguments list contains both existing and missing names of C programs stored under the current directory. Missing names refer to the files which no longer exist under the current directory.

Make sure your script is user-friendly and follows common sense (for example, when there is no 
C program stored under the current directory your script should display a message and then 
exit).

To illustrate the behaviour of the script, the following are sample outputs, noting the '$' is the shell prompt.

a)

    $ ./delC.sh
    This script removes C files which you no longer want to keep.
    Here are the C file(s) under the current directory:
    No C files found.
b)
 
    $ ./delC.sh
    This script removes C files which you no longer want to keep.
    Here are the C file(s) under the current directory:
    f1.c f2.c
    Displaying first 10 lines of f1.c:
    /* A C program for handling arrays
     Written by John Jones, July 2009
     Updated April 2010
    */
    #include <stdio.h>
    int main()
    {
     int x;
    Delete file f1.c? (y/n):n (user input)
    File f1.c NOT deleted.
    Displaying first 10 lines of f2.c:
    /* Another C program for handling arrays
     Written by John Jones, August 2009
     Updated May 2010
    */
    #include <stdio.h>
    int main()
    {
     int x, y, z;
    Delete file f2.c? (y/n): y (user input)
    File f2.c deleted.
c)

    $ ./delC.sh f1.c
    This script removes C files which you no longer want to keep.
    The file(s) you want to delete is/are:
    f1.c
    Displaying first 10 lines of f1.c:
    /* A C program for handling arrays
     Written by John Jones, July 2009
     Updated April 2010
    */
    #include <stdio.h>
    int main()
    {
     int x;
    Delete file f1.c? (y/n):y (user input)
    File f1.c deleted.
d)

    $ ./delC.sh f2.c f3.c
    This script removes C files which you no longer want to keep.
    The file(s) you want to delete is/are: 
    f2.c f3.c
    Displaying first 10 lines of f2.c:
    /* Another C program for handling arrays
     Written by John Jones, August 2009
     Updated May 2010
    */
    #include <stdio.h>
    int main()
    {
     int x, y, z;
    Delete file f2.c? (y/n): y (user input)
    File f2.c deleted.
    Displaying first 10 lines of f3.c:
    File f3.c does not exist.
e)

    $ ./delC.sh f3.c f4.c
    This script removes C files which you no longer want to keep.
    The file(s) you want to delete is/are: 
    f3.c f4.c
    Displaying first 10 lines of f3.c:
    File f3.c does not exist.
    Displaying first 10 lines of f4.c:
    File f4.c does not exist.
