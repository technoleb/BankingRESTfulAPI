# BankingRESTfulAPI
Banking RESTfull Service API and Web

Banking RESTful service
Introduction
You are developing an internal interface for a Banking systems as a RESTful API.
One of the requirements is to implement a simple interface for an Banking System.

Problem Statement
To complete this task, you have to add a new custom controller in the BankingRESTfulService.Web project which will implement the BankingRESTfulService.Api.IInternetBankingApi interface.
Remember that the controller should implement the interface as a RESTful API.
Again, remember that you should create your new controller in BankingRESTfulService.Web project not in BankingRESTfulService.Api!

Requirements:

The GetApiVersion method should return the current version (1.0) in the following format: YYYY.MM.DD.1.0, where:
YYYY is the current year (UTC time),
MM is the current month (UTC time),
DD is the current day (UTC time).
The CalculateMD5 should calculate the MD5 hash for the data passed as a function parameter.
The MD5 hash should be returned as hex characters (the ex for test-string-1 should be 7FE8C14D5E3D1CFB648F77F05766A013).
The passed parameter will never be empty.
The IsPasswordStrong should check if the passed password (as a parameter) is strong.
The password will be recognized as strong if it is at least eight characters long and contains at least one uppercase letter, one lowercase letter, one number and at least one character other than an uppercase letter, a lowercase letter or a number.
The password cannot contain white-space characters.
Configure endpoints availability
Remember that you're not allowed to make any changes to Startup.cs or Program.cs, so you have to configure availability in your controller.

The GetApiVersion should be available at both: bank/api/version and bank/api-version url.
The CalculateMD5 should be available at both: bank/api/calc/MD5/<passed md5 value> and bank/api/calc/<passed md5 value>/MD5 url.
The IsPasswordStrong should be available at both: bank/api/password/strong/<passed md5 value> and bank/api/is-password-strong/<passed md5 value> url.
NOTE: Please, make sure not to change the task structure/refactor code, as it can break verification process.

Hints
Your solution should pass all tests.
You're not suposed to inject anything in your new custom controller construtor.
