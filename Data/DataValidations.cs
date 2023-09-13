using Microsoft.AspNetCore.Components.Forms;
using System.Net.Mail;

namespace FileUploader.Data
{
    public class DataValidations
    {
        public bool IsValidEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch { 
                return false;
            }
        }

        public bool IsValidDocxFile(IBrowserFile file) {
            return file != null && Path.GetExtension(file.Name) == ".docx";
        }
    }
}
