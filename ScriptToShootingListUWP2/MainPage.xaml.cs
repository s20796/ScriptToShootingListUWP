using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using OpenAI_API;
using OpenAI;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.Managers;
using OpenAI.ObjectModels;

namespace ScriptToShootingListUWP2
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void OnButtonClick(object sender, RoutedEventArgs e)
        {
            string text = myTextBox.Text;

            // Create an instance of the APIAuthentication class with your API key
            var authentication = new APIAuthentication("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");

            // Create an instance of the OpenAIAPI class with the APIAuthentication object
            var api = new OpenAIAPI(authentication);

            // Create a new conversation with ChatGPT
            var conversation = api.Chat.CreateConversation();

            // Append user input and get response from ChatGPT
            conversation.AppendUserInput("Tell a joke");
            var response = await conversation.GetResponseFromChatbot();
            Console.WriteLine(response);

            // Wait for user input before closing the console window
            Console.ReadLine();
        }
        }
    }

    public class GptResponse
    {
        public List<Choice> Choices { get; set; }
    }

    public class Choice
    {
        public string Text { get; set; }
    }
