using System;
using System.Collections;
using System.Collections.Generic;

namespace Poe_part1
{
    public class design_prompt
    {
        // Variable declaration global
        private string user_name = string.Empty;
        private string user_asking = string.Empty;
        private bool isFirstInteraction = true; // Flag to check if it's the first interaction

        // ArrayList for predefined questions and answers (static)
        private ArrayList predefinedQuestions = new ArrayList();
        private ArrayList predefinedAnswers = new ArrayList();

        // ArrayList for dynamic questions and answers (user input)
        private ArrayList userQuestions = new ArrayList();
        private ArrayList userAnswers = new ArrayList();

        // Constructor
        public design_prompt()
        {
            // Initialize predefined questions and answers
            predefinedQuestions.Add("how are you?");
            predefinedAnswers.Add("I'm doing well, thank you! How can I assist you with cybersecurity today?");

            predefinedQuestions.Add("what's your purpose?");
            predefinedAnswers.Add("My purpose is to assist you with cybersecurity topics such as password safety, phishing, and safe browsing. Feel free to ask me anything!");

            predefinedQuestions.Add("what can i ask you about?");
            predefinedAnswers.Add("My purpose is to assist you with cybersecurity topics such as password safety, phishing, and safe browsing. Feel free to ask me anything!");

            predefinedQuestions.Add("password");
            predefinedAnswers.Add("It's important to create strong passwords. Use a mix of letters, numbers, and special characters. Avoid using the same password for multiple accounts.");

            predefinedQuestions.Add("phishing");
            predefinedAnswers.Add("Phishing is when attackers try to trick you into giving away personal information like passwords. Always verify the source before clicking on links or opening attachments in emails.");

            predefinedQuestions.Add("safe browsing");
            predefinedAnswers.Add("For safe browsing, ensure you're using HTTPS websites and avoid clicking on suspicious links. Use up-to-date antivirus software and a firewall.");

            // Welcome the user and prompt the name
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("  |Welcome to AI|");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------------------");

            // Ask for the user's name
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("chatBot:->");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Please enter your name:");

            // Get user's name
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("you:->");
            Console.ForegroundColor = ConsoleColor.White;
            user_name = Console.ReadLine();

            // Main loop to interact with the user
            do
            {
                // If it's the first interaction, ask "How can I assist you today?"
                if (isFirstInteraction)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("chatBot:->");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"Hey {user_name}, how can I assist you today?");
                    isFirstInteraction = false; // Set the flag to false after the first interaction
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{user_name}:->");
                Console.ForegroundColor = ConsoleColor.White;

                // Get the user's input
                user_asking = Console.ReadLine();

                // If the user types "exit", display a goodbye message and exit
                if (user_asking.ToLower() == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("chatBot:-> Goodbye, thanks for using this AI!"); // Goodbye message
                    break; // Exit the loop and end the program
                }

                // Call the method to respond based on user input
                Answer(user_asking);
            } while (user_asking.ToLower() != "exit");
        }

        // Answering method
        private void Answer(string asked)
        {
            // Default response if no match is found
            string response = "I didn't quite understand that. Could you rephrase? I'm here to help with cybersecurity topics.";

            // Normalize the input (convert to lowercase) and check if it's in the predefined questions
            bool foundMatch = false;
            for (int i = 0; i < predefinedQuestions.Count; i++)
            {
                string predefinedQuestion = predefinedQuestions[i].ToString().ToLower();
                if (asked.ToLower().Contains(predefinedQuestion))
                {
                    response = predefinedAnswers[i].ToString();
                    foundMatch = true;
                    break;
                }
            }

            // If no match found in predefined questions, create a new response
            if (!foundMatch)
            {
                response = "I didn't quite understand that. Could you rephrase? I'm here to help with cybersecurity topics.";
            }

            // Add the user's question and response to the userQuestions and userAnswers ArrayLists
            userQuestions.Add(asked);
            userAnswers.Add(response);

            // Display the response to the user
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("chatBot:-> " + response);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
