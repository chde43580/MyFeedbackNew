using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MyFeedback.Domain.Entities
{
    public class ForumPost : DomainEntity
    {
        public DateTime PostDate { get; protected set; }
        public List<Comment> Comments { get; protected set; }
        public Guid CategoryId { get; protected set; }
        public string ProblemText { get; protected set; }
        public string SolutionText { get; protected set; }
        public int UpVotes { get; protected set; }
        public int DownVotes { get; protected set; }
        public int TimesReported { get; protected set; }
        public bool IsLocked { get; protected set; }

        public ForumPost(string problemText, string solutionText)
        {
            this.ProblemText = problemText;
            this.SolutionText = solutionText;
        }

        public static ForumPost Create(string problemText, string solutionText)
        {
            ForumPost newForumPost = new ForumPost(problemText, solutionText);

            return newForumPost;
        }

        public string AssureTextNotTooLong()
        {
            if (this.SolutionText.Length > 150)
            {
                return "Solution text is too long; it can't be longer than 200 characters!";
            }
            else if (this.ProblemText.Length > 150)
            {
                return "Problem text is too long; it can't be longer than 200 characters!";

            }
            else
            {
                return ""; // Empty string means to the caller that the text is not too long
            }
        }

        public void SendMailWhenSufficientEngagement(string categoryPrincipalEmail)
        {
            if (this.UpVotes > 19)
            {


                SmtpClient client = new SmtpClient("smtp.simply.com", 587) // Simply bruger denne (587) eller port 25 (25 virker tilsyneladende ikke dog)
                {
                    Credentials = new System.Net.NetworkCredential("MyFeedbackNotification@fm02.dk", "Myfeedback1234"),
                    EnableSsl = true
                };

                MailMessage mailMessage = new MailMessage();

                mailMessage.From = new MailAddress("MyFeedbackNotification@fm02.dk");

                mailMessage.To.Add(categoryPrincipalEmail);

                mailMessage.Subject = "Notifikation om særligt engagement i et forumindlæg i MyFeedback";

                mailMessage.Body = $"Forumindlægget har modtaget {this.UpVotes} up-votes!" + " Se indlægget her: [link til indlæg]";

                client.Send(mailMessage);

            }
            else if (this.DownVotes > 39)
            {
                SmtpClient client = new SmtpClient("smtp.simply.com", 587) // Simply bruger denne (587) eller port 25 (25 virker tilsyneladende ikke dog)
                {
                    Credentials = new System.Net.NetworkCredential("MyFeedbackNotification@fm02.dk", "Myfeedback1234"),
                    EnableSsl = true
                };

                MailMessage mailMessage = new MailMessage();

                mailMessage.From = new MailAddress("MyFeedbackNotification@fm02.dk");

                mailMessage.To.Add(categoryPrincipalEmail);

                mailMessage.Subject = "Notifikation om særligt engagement i et forumindlæg i MyFeedback";

                mailMessage.Body = $"Forumindlægget har modtaget {this.DownVotes} down-votes!" + " Se indlægget her: [link til indlæg]";

                client.Send(mailMessage);

            }
            else if (this.Comments.Count > 9)
            {
                SmtpClient client = new SmtpClient("smtp.simply.com", 587) // Simply bruger denne (587) eller port 25 (25 virker tilsyneladende ikke dog)
                {
                    Credentials = new System.Net.NetworkCredential("MyFeedbackNotification@fm02.dk", "Myfeedback1234"),
                    EnableSsl = true
                };

                MailMessage mailMessage = new MailMessage();

                mailMessage.From = new MailAddress("MyFeedbackNotification@fm02.dk");

                mailMessage.To.Add(categoryPrincipalEmail);

                mailMessage.Subject = "Notifikation om særligt engagement i et forumindlæg i MyFeedback";

                mailMessage.Body = $"Forumindlægget har modtaget {this.Comments.Count()} kommentarer!" + " Se indlægget her: [link til indlæg]";

                client.Send(mailMessage);
            }
                }

            }
        }
