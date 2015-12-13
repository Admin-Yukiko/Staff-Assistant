These are the files required by the Staff Assistant. I decided to collect them in a package rather than mix them in the "standard" command directories.

Many of these commands are copied from the "standard" commands and renamed with the prefix "sa_".

There are a few commands that were not copied into this package. Info and iteminfo are two examples. Staff Assistant calls those commands by their name without the "sa_" prefix. The main reason I have not yet moved them to the StaffAssistant package is due to their dependancy on other files (includes) within a server. I might add add copies of them to this package at a later date. I'd need to add the dependant includes so that this package would be a stand alone package.

For some of the commands I appropriated to this package I needed includes to handle gumps and such. So you will find those in this package as well.