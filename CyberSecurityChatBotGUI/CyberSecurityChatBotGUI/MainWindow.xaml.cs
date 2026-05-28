using CyberSecurityChatBotGUI;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace CybersecurityChatbotGUI
{
    public partial class MainWindow : Window
    {
        private string userName = "";
        private string favouriteTopic = "";
        private ChatbotResponder responder;

        public MainWindow()
        {
            InitializeComponent();
            responder = new ChatbotResponder();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Play voice greeting
            AudioPlayer.PlayVoiceGreeting();

            // Display ASCII art
            DisplayAsciiArt();

            // Ask for user name
            InputDialog inputDialog = new InputDialog();
            if (inputDialog.ShowDialog() == true)
                userName = inputDialog.UserName;

            if (string.IsNullOrWhiteSpace(userName))
                userName = "User";

            // Display welcome messages
            AppendMessage("Bot",
                $"Hello {userName}! I am here to help you stay safe online.",
                Brushes.Cyan);
            AppendMessage("Bot",
                "Ask me about: passwords, phishing, malware, VPN, 2FA and more!",
                Brushes.Cyan);
            AppendMessage("Bot",
                "Type 'list' to see all topics.",
                Brushes.Cyan);
        }

        private void DisplayAsciiArt()
        {
            Paragraph para = new Paragraph();
            para.Foreground = Brushes.Cyan;
            para.FontFamily = new FontFamily("Courier New");
            para.FontSize = 11;
            para.Inlines.Add(new Run(@"
  ██████╗██╗   ██╗██████╗ ███████╗██████╗ 
 ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗
 ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝
 ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗
 ╚██████╗   ██║   ██████╔╝███████╗██║  ██║
  ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝
      🔒 Cybersecurity Awareness Bot 🔒
"));
            rtbChat.Document.Blocks.Add(para);
        }

        private void AppendMessage(string sender, string message, Brush color)
        {
            Paragraph para = new Paragraph();
            para.Foreground = color;
            para.FontFamily = new FontFamily("Courier New");
            para.FontSize = 13;

            if (sender == "Bot")
                para.Inlines.Add(new Run($"🤖 Bot: {message}"));
            else
                para.Inlines.Add(new Run($"👤 {userName}: {message}"));

            rtbChat.Document.Blocks.Add(para);
            scrollViewer.ScrollToBottom();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                SendMessage();
        }

        private void SendMessage()
        {
            string userInput = txtInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(userInput))
            {
                AppendMessage("Bot",
                    "I did not catch that. Could you rephrase?",
                    Brushes.Red);
                return;
            }

            // Display user message
            AppendMessage(userName, userInput, Brushes.Yellow);
            txtInput.Clear();

            // Check for exit
            if (userInput.ToLower() == "exit" ||
                userInput.ToLower() == "bye" ||
                userInput.ToLower() == "quit" ||
                userInput.ToLower() == "goodbye")
            {
                AppendMessage("Bot",
                    $"Goodbye {userName}! Stay safe online! 🔒",
                    Brushes.Green);
                return;
            }

            // Check for list
            if (userInput.ToLower() == "list")
            {
                AppendMessage("Bot",
                    responder.GetTopicList(),
                    Brushes.Cyan);
                return;
            }

            // Get response
            string response = responder.GetResponse(
                userInput, userName, ref favouriteTopic);
            AppendMessage("Bot", response, Brushes.Cyan);
        }
    }
}