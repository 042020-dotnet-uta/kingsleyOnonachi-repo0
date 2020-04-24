using System;

namespace learningCSharp
{
    public class UserService  
    {  
        public void Register(string email, string password)  
        {  
            if (!ValidateEmail(email))  
                throw new ValidationException("Email is not an email");  
                var user = new User(email, password);  
        
                SendEmail(new MailMessage("mysite@nowhere.com", email) { Subject="HEllo foo" });  
        }

        public virtual bool ValidateEmail(string email)  
        {  
            return email.Contains("@");  
        } 
         
        public bool SendEmail(MailMessage message)  
        {  
            _smtpClient.Send(message);  
        }  
    } 
}
