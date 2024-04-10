using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OCP.Pages;

public class ContactModel : PageModel
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
    
    public void OnGet()
    {
        
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page(); // Return to the page if the form has validation errors
        }

        // Send the notification email
        if (await SendNotificationEmail()) 
        {
            ViewData["Message"] = "Message sent! Thank you for reaching out.";
        }
        else
        {
            ViewData["Message"] = "There was an error sending your message. Please try again.";
        }

        return Page(); // Show a success or error message
    }
    
    private async Task<bool> SendNotificationEmail()
    {
        try
        {
            // Example using SMTP (replace placeholders):
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new System.Net.NetworkCredential("twizoraph4247@gmail.com", "oqwb eoah otqt jadv\n"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("twizoraph4247@gmail.com"),
                To = { "oreste.twizeyimana99@gmail.com" },
                Subject = "New Contact Form Submission",
                Body = $"Name: {Name}\nEmail: {Email}\nMessage: {Message}"
            };

            await smtpClient.SendMailAsync(mailMessage);

            return true; // Email sent successfully
        }
        catch (Exception ex)
        {
            // Log the error:
            Console.WriteLine("Email sending error: " + ex.Message);
            return false; // Email sending failed
        }
    }
}