
using Domain;
using OpenPop.Mime;
using OpenPop.Pop3;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common.Email
{
    public class EmailService : IEmailService
    {
        /// <summary>
        /// 
        /// </summary>
        static bool mailSent = false;



        public async Task<bool> SendApprovalRequestAsync(int managerId, int requestId, string managerEmail)
        {

            try
            {

                String sReplyToadd = "replyams757@gmail.com";
                String replyToAddress = sReplyToadd.Substring(0, sReplyToadd.IndexOf('@')) + "+on+" + managerId + "+" + requestId + "+un" + sReplyToadd.Substring(sReplyToadd.IndexOf('@'), sReplyToadd.Length - sReplyToadd.IndexOf('@'));

                // Command-line argument must be the SMTP host.
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                // Specify the email sender.
                // Create a mailing address that includes a UTF8 character
                // in the display name.
                MailAddress from = new MailAddress("usertestuserlast46@gmail.com",
                   "user8767 " + (char)0xD8 + " testUserLastName",
                System.Text.Encoding.UTF8);
                // Set destinations for the email message.
                MailAddress to = new MailAddress(managerEmail);
                // Specify the message content.
                using (MailMessage message = new MailMessage(from, to))
                {
                    message.Body = "This is a test email message sent by an application. Please do not change the To address to map your reply properly to the system.";
                    // Include some non-ASCII characters in body and subject.
                    string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });
                    message.Priority = MailPriority.High;
                    message.Body += Environment.NewLine + someArrows;
                    message.BodyEncoding = System.Text.Encoding.UTF8;
                    message.Subject = "test message 1" + someArrows;
                    message.SubjectEncoding = System.Text.Encoding.UTF8;
                    message.IsBodyHtml = true;

                    //here we set the unique reply to address for the outgoing email
                    message.ReplyTo = new MailAddress(replyToAddress); //replyto+on1234un5678@domain.com
                    // Set the method that is called back when the send operation ends.
                    client.SendCompleted += new
                    SendCompletedEventHandler(SendCompletedCallback);
                    client.UseDefaultCredentials = false;
                    NetworkCredential credentials = new NetworkCredential("usertestuserlast46@gmail.com", "xxxxxx");
                    client.Credentials = credentials;
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Send(message);

                    // Clean up
                    //message.Dispose();
                }

                return true;
            }
            catch (Exception ex)
            {
                //Log handling 
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="managerId"></param>
        /// <param name="requestId"></param>
        /// <returns></returns>
        public ApprovaInfoDto LoadReplyByRequestIdAsync(int managerId, int requestId)
        {
            var allApprovalReplies = this.LoadApprovalRepliesAsync().Result;
            var approvalInfoList = new List<ApprovaInfoDto>();

            allApprovalReplies?.ToList().ForEach(x =>
            {
                var approvalInfo = new ApprovaInfoDto();
                var data = x.To.Split("+");

                if (data != null && data.Count() == 5)
                {
                    approvalInfo.ManagerId = Convert.ToInt32(data[2]);
                    approvalInfo.RequestId = Convert.ToInt32(data[3]);
                    approvalInfo.IsApproved = (x.Body.Contains("ApprovedOn") || x.Body.Contains("Approved"));

                    approvalInfoList.Add(approvalInfo);
                }
            });

            return approvalInfoList.Where(x => x.RequestId == requestId && x.ManagerId == managerId)?.FirstOrDefault();
        }

        /// <summary>
        ///    
        /// </summary>
        /// <returns></returns>
        private async Task<IEnumerable<POPEmail>> LoadApprovalRepliesAsync()
        {

            //int eid = Convert.ToInt32(Session["Email"]);
            //var PEmails = db.CnfiEmail.FirstOrDefault(x => x.id == eid);
            //var pid = db.PoPP.FirstOrDefault(x => x.Pid == PEmails.Pid);
            HtmlToTextConverter htt = new HtmlToTextConverter();

            Pop3Client pop3Client = new Pop3Client();
            pop3Client.Connect("pop.gmail.com", 995, true);
            pop3Client.Authenticate("replyams757@gmail.com", "xxxxxxxx");
            // Session["Pop3Client"] = pop3Client;

            int count = pop3Client.GetMessageCount();
            var Emails = new List<POPEmail>();
            int counter = 0;
            for (int i = count; i >= 1; i--)
            {
                Message message = pop3Client.GetMessage(i);
                POPEmail email = new POPEmail()
                {
                    MessageNumber = i,
                    Subject = message.Headers.Subject,
                    DateSent = message.Headers.DateSent,
                    //From = string.Format("<a href = 'mailto:{1}'>{0}</a>", message.Headers.From.DisplayName, message.Headers.From.Address),
                    From = message.Headers.From.Address,
                    To = message.Headers.To.FirstOrDefault().Address
                };
                MessagePart body = message.FindFirstHtmlVersion();
                if (body != null)
                {
                    email.Body = body.GetBodyAsText();
                }
                else
                {
                    body = message.FindFirstPlainTextVersion();
                    if (body != null)
                    {
                        email.Body = body.GetBodyAsText();
                    }
                }
                email.Body = htt.ConvertHtml(email.Body);
                Emails.Add(email);
                counter++;
                //if (counter > 2)
                //{
                //    break;
                //}
            }
            var emails = Emails;
            return emails;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {

                // Save token DB
            }
            else if (e.Error != null)
            {
                // Save token DB 
            }
            else
            {
                //Save token 
            }
            mailSent = true;
        }

    }
}
