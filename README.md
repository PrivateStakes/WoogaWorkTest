# WoogaWorkTest
A UI test strategy implementation oriented around Selenium

HOW TO USE:
1. Runtime testing instructions and overview
2. Adding new addresses
3. Adding new browsers
4. Adding new test environments

----------------------------------------------------------

1. Runtime testing instructions and overview:
Testing is done through conventional testing explorer in Visual Studio. Browsers listed in the testing .cs file 
must be present on the computer testing (Firefox, Chrome, and Edge as of writing this). To conduct tests the
addresses.txt file located under GoogleMapsSeleniumProject must be present.

2. Adding new addresses:
Simply locate the addresses.txt file under GoogleMapsSeleniumProject and add the address to a new row. Note that
for the program to register the address as separate from another, it must be on a separate row.

3. Adding new browsers:
Add the browser to the enum 'E_Browsers' in main.cs - the added value must be added before 'last_element' (i.e: 
must be lower than last_element). For the browser to be included in tests it must be added to the switch-case in
the main.cs method called set_browsers().

4. Adding new test environments:
To create a new test environment, make a child class of TestEnvironment. To implement the environment, either:
a) add it to the list _tests, located in the [setup] function setup_tests(), or
b) add it as a separate test (see test_google_test() as a model example for implementation)
