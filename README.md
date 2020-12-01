## An idea for eliminating the need for a database when using OTP (One-Time Password) in .NET
As I have seen, most applications use database for the OTP Verification section and assign one or more tables to OTP. <br>
This makes sense in terms of storing and reviewing data, but increases database transactions and thus slows down the database. <br><br>
**What is the solution?** <br>
We can implement Generate and Verify operations in application logic! <br><br>
**But how?** <br>
Using cryptography, we encrypt the data we want and send it to the client as a key.<br><br>
**How to verify the accuracy of the information?** <br>
We decrypt the key sent to us by the client and then perform the operations required to verify the information.

### Generate OTP Schema
1. Generate Random Code (Password)
2. Create and Serialize OTP JSON Object
3. Encrypt OTP JSON Object

### Verify OTP Schema
1. Decrypt Key
2. Deserialize OTP JSON Object
3. Check the accuracy of the information
