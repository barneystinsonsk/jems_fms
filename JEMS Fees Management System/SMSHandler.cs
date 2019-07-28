using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Collections.Specialized;

namespace JEMS_Fees_Management_System
{


    class SMSHandler
    {
        static SMSHandler smsHandler = null;

        public static SMSHandler getInstance()
        {
            if (smsHandler == null)
                return new SMSHandler();
            else return smsHandler;
        }

        private SMSHandler()
        {

        }

        public List<String> sendSMS(String API_KEY, List<String> numbers, List<String> messageString)
        {
            List<String> answer = new List<string>();

            // Validate and remove erroneous number/messages
            cleanMessages(numbers, messageString);

            //Further operations should be done on a separate thread to avoid UI freezing
            //Preferably a GUI form should be created to view progress and stop sending of messages
            //A message log will be made to track- Rejected Messages, Sent Messages, Undelivered Messages;

            if (numbers.Count != 1) return null;
            try
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    using (var wb = new WebClient())
                    {
                        String message = HttpUtility.UrlEncode(messageString[i]);
                        byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                        {
                            {"apikey" , API_KEY},
                            {"numbers" , "91" + numbers[i]},
                            {"message" , message},
                            {"sender" , "TXTLCL"}
                        });
                        string result = Encoding.UTF8.GetString(response);
                        answer.Add(result);
                    }
                }

            }
            catch(Exception ex)
            {
                List<String> error = new List<String>();
                error.Add(ex.Message);
                return error;
            }
            return answer;
        }
        private void cleanMessages(List<String> numbers, List<String> messageString)
        {
            List<String> rejectedNumbers = new List<string>();
            List<String> rejectedMessages = new List<string>();
            List<String> rejectReason = new List<String>();

            if (numbers == null || messageString == null || numbers.Count == 0 || messageString.Count == 0)
                throw new Exception("Empty List");
            if (numbers.Count != messageString.Count)
                throw new Exception("Message count does not match mobile number count");
            if (numbers.Count > 500 || messageString.Count > 500)
                throw new Exception("Message count is greater than 500");

            //Code to reject improper data
            int originalCount = numbers.Count;

            //Rejection based on numbers
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                //Number size should be 10
                if (numbers[i].Length != 10)
                {
                    rejectedNumbers.Add(numbers[i]);
                    rejectedMessages.Add(messageString[i]);
                    numbers.RemoveAt(i);
                    messageString.RemoveAt(i);
                }

                //Number should contain only numerics
                //TODO

                //First few digits validation
                //TODO
            }
            int numberCount = numbers.Count;
            //Rejection based on message
            for (int i = messageString.Count - 1; i >= 0; i--)
            {
                //message should be less than 130 characters Compunsating for special characters which take 2 character spaces
                if (messageString[i].Length > 130 || messageString[i].Length < 10)
                {
                    rejectedNumbers.Add(numbers[i]);
                    rejectedMessages.Add(messageString[i]);
                    numbers.RemoveAt(i);
                    messageString.RemoveAt(i);
                }

                //Number should contain only numerics
                //TODO

                //First few digits validation
                //TODO
            }
            int messageCount = messageString.Count;

            //By now messages and numbers have been validated
        }

    }
}
