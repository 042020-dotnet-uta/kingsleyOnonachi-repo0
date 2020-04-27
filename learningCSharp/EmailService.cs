using System;

namespace learning
{
    public class EmailService  
   {  
        SmtpClient _smtpClient; 

        public EmailService(SmtpClient aSmtpClient)  
        {  
            _smtpClient = aSmtpClient;  
        }  

        public bool virtual ValidateEmail(string email)  
        {  
            return email.Contains("@");  
        }
          
        public bool SendEmail(MailMessage message)  
        {  
            _smtpClient.Send(message);  
        }  
    }   
}