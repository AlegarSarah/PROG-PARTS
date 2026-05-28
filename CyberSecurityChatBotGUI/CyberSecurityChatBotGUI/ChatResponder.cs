using System;
using System.Collections.Generic;

namespace CyberSecurityChatBotGUI
{
    class ChatbotResponder
    {
        private static readonly Random random = new Random();

        private static readonly Dictionary<string, string[]> Responses =
            new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase)
        {
            { "hello",            new[] { "Hello! How can I help you stay safe online?",
                                          "Hi there! Ready to help with cybersecurity!",
                                          "Hey! What cybersecurity topic can I help with?" }},

            { "hi",               new[] { "Hi! How can I assist you today?",
                                          "Hello! Ask me anything about cybersecurity!" }},

            { "how are you",      new[] { "I am running securely and ready to help!",
                                          "All systems secure! How can I help you?" }},

            { "help",             new[] { "Type 'list' to see all available topics!",
                                          "Ask me about passwords, phishing, malware and more!" }},

            { "thank you",        new[] { "You are welcome! Stay safe online!",
                                          "Happy to help! Remember to stay vigilant!" }},

            { "thanks",           new[] { "No problem! Stay safe online!",
                                          "Anytime! Cybersecurity is important!" }},

            { "password",         new[] { "Use strong passwords with uppercase, lowercase, numbers and symbols!",
                                          "Never reuse passwords across different sites!",
                                          "Use a password manager like LastPass or Bitwarden!" }},

            { "phishing",         new[] { "Phishing emails mimic trusted sources. Always verify the sender!",
                                          "Never click suspicious links in emails!",
                                          "Check the email address carefully before clicking any links!" }},

            { "scam",             new[] { "Legitimate companies never ask for passwords via email!",
                                          "Be cautious of unsolicited calls asking for personal info!",
                                          "If it sounds too good to be true it probably is a scam!" }},

            { "malware",          new[] { "Install reputable antivirus and keep it updated!",
                                          "Avoid downloading software from unknown sources!",
                                          "Scan your device regularly for malware!" }},

            { "virus",            new[] { "Keep your antivirus updated to protect against viruses!",
                                          "Never download files from untrusted websites!" }},

            { "ransomware",       new[] { "Always back up your data to prevent ransomware damage!",
                                          "Never open suspicious email attachments!" }},

            { "spyware",          new[] { "Install antivirus software to detect and remove spyware!",
                                          "Avoid clicking unknown links that could install spyware!" }},

            { "trojan",           new[] { "Only download software from trusted official sources!",
                                          "Trojans disguise themselves as legitimate software!" }},

            { "antivirus",        new[] { "Install reputable antivirus and keep it updated!",
                                          "Run regular scans to protect your device!" }},

            { "vpn",              new[] { "A VPN encrypts your internet connection!",
                                          "Use a VPN especially on public WiFi networks!" }},

            { "firewall",         new[] { "Always keep your firewall enabled!",
                                          "A firewall monitors and controls network traffic!" }},

            { "wifi",             new[] { "Avoid using public WiFi for sensitive tasks!",
                                          "Always use a VPN on public WiFi networks!" }},

            { "encryption",       new[] { "Encryption converts data into unreadable code!",
                                          "Use encrypted apps for sensitive communication!" }},

            { "backup",           new[] { "Use the 3-2-1 rule: 3 copies, 2 media, 1 offsite!",
                                          "Back up your data regularly to prevent data loss!" }},

            { "data breach",      new[] { "Change your passwords immediately after a breach!",
                                          "Enable 2FA on all accounts after a breach!" }},

            { "privacy",          new[] { "Review your app permissions regularly!",
                                          "Limit what personal information you share online!" }},

            { "two factor",       new[] { "Always enable 2FA for extra security!",
                                          "2FA makes it much harder for hackers to access accounts!" }},

            { "2fa",              new[] { "Enable Two-Factor Authentication on all accounts!",
                                          "Use Google Authenticator for 2FA!" }},

            { "update",           new[] { "Always keep software updated to patch vulnerabilities!",
                                          "Enable automatic updates to stay protected!" }},

            { "hacker",           new[] { "Hackers exploit weak passwords and outdated software!",
                                          "Keep everything updated and use strong passwords!" }},

            { "dark web",         new[] { "Avoid the dark web as it is full of illegal activity!",
                                          "Never share personal information on the dark web!" }},

            { "social media",     new[] { "Be careful what you share on social media!",
                                          "Check your privacy settings on all social media accounts!" }},

            { "online banking",   new[] { "Always use 2FA for online banking!",
                                          "Never do online banking on public WiFi!" }},

            { "cybersecurity",    new[] { "Cybersecurity protects systems from digital attacks!",
                                          "Stay informed about cybersecurity to protect yourself!" }},

            { "identity theft",   new[] { "Monitor your accounts regularly for suspicious activity!",
                                          "Enable 2FA to prevent identity theft!" }},

            { "cookie",           new[] { "Clear cookies regularly for better privacy!",
                                          "Only accept cookies from trusted websites!" }},

            { "https",            new[] { "Always look for HTTPS before entering personal info!",
                                          "HTTPS means the connection is encrypted!" }},

            { "fraud",            new[] { "Never share personal info with unverified sources!",
                                          "Report fraud to the authorities immediately!" }},

            { "spam",             new[] { "Never click links inside spam emails!",
                                          "Mark spam emails and report them!" }},

            { "fake website",     new[] { "Check the URL carefully for slight misspellings!",
                                          "Always look for HTTPS before entering info!" }},
        };

        public string GetTopicList()
        {
            return "Topics I can help with:\n" +
                   "• passwords, phishing, malware\n" +
                   "• vpn, firewall, encryption\n" +
                   "• 2fa, backup, data breach\n" +
                   "• scam, fraud, ransomware\n" +
                   "• social media, privacy\n" +
                   "• dark web, online banking\n" +
                   "• identity theft and more!";
        }

        public string GetResponse(string input,
            string userName, ref string favouriteTopic)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "I did not catch that. Could you rephrase?";

            // Sentiment detection
            if (input.ToLower().Contains("worried") ||
                input.ToLower().Contains("scared") ||
                input.ToLower().Contains("afraid"))
                return $"I understand you are worried {userName}. " +
                       "Let me help you stay safe online!";

            if (input.ToLower().Contains("frustrated") ||
                input.ToLower().Contains("angry") ||
                input.ToLower().Contains("upset"))
                return $"I understand your frustration {userName}. " +
                       "Take it one step at a time!";

            if (input.ToLower().Contains("happy") ||
                input.ToLower().Contains("great") ||
                input.ToLower().Contains("good"))
                return $"Glad to hear that {userName}! " +
                       "Keep up the good work staying safe online!";

            // Memory and recall
            if (input.ToLower().Contains("what do you remember") ||
                input.ToLower().Contains("what do you know about me"))
            {
                string memory = $"I remember your name is {userName}.";
                if (!string.IsNullOrEmpty(favouriteTopic))
                    memory += $" Your favourite topic is {favouriteTopic}.";
                return memory;
            }

            // Conversation flow
            if (input.ToLower().Contains("tell me more") ||
                input.ToLower().Contains("explain more") ||
                input.ToLower().Contains("give me another tip") ||
                input.ToLower().Contains("more info"))
            {
                if (!string.IsNullOrEmpty(favouriteTopic))
                    return GetRandomResponse(favouriteTopic);
                return "What topic would you like to know more about?";
            }

            // Check dictionary for keyword match
            foreach (var entry in Responses)
            {
                if (input.ToLower().Contains(entry.Key.ToLower()))
                {
                    favouriteTopic = entry.Key;
                    return GetRandomResponse(entry.Key);
                }
            }

            return "I did not quite understand that. " +
                   "Type 'list' to see all available topics.";
        }

        private string GetRandomResponse(string key)
        {
            if (Responses.ContainsKey(key))
            {
                string[] responses = Responses[key];
                return responses[random.Next(responses.Length)];
            }
            return "I did not quite understand that.";
        }
    }
}
