using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel.Communication;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Maui.Storage;
using Firebase.Auth;
using BudgetTrackingApp.Models;
using System.Text.RegularExpressions;


namespace BudgetTrackingApp
{

    
    public class Authentication
    {

       private static string apiKey = "AIzaSyBqozpItJ4JNHEcLEgzTGATCAf39tWcFtc";//await LoadFirebaseApiKey(); //Load the API Key from config.json

        /// <summary>
        /// Authenticate the user with email and password
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static async Task<bool> LoginUser(Models.User user)
        {
            bool loggedIn = false; // Initialize loggedIn to false
            try
            {

                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(apiKey)); //Load Firebase

                var auth = await authProvider
                .SignInWithEmailAndPasswordAsync(user.email, user.password); //Email password authentication

                var token = auth.FirebaseToken; //get the token

                if (string.IsNullOrEmpty(token)) //if token is empty, then user is not authenticated and return so invalid login state isn't set
                    return false;

                // Store login state
                await SecureStorage.SetAsync("firebase_token", token);
                await SecureStorage.SetAsync("username", user.userName);
                await SecureStorage.SetAsync("email", user.email);
                await SecureStorage.SetAsync("logged_in", "true");

                loggedIn = true;

                user.userName = auth.User.DisplayName;
            }

            catch (FirebaseAuthException ex)
            {
                Console.WriteLine($"Firebase auth error: {ex.Reason}");
                loggedIn = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                loggedIn = false;
            }


            return loggedIn;
        }

        /// <summary>
        /// Register a new user with email and password 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// If the user was registered successfully, return true. Otherwise, return false.
        /// </returns>
        public static async Task<bool> RegisterUser(Models.User user)
        {
            try
            {
                
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(user.email, user.password, user.userName, true);

                // Store token if needed
                await SecureStorage.SetAsync("firebase_token", auth.FirebaseToken);
                return true;
            }
            catch (FirebaseAuthException ex)
            {
                Console.WriteLine($"Firebase signup error: {ex.Reason}");
                return false;
            }
        }




        private static async Task<string> LoadFirebaseApiKey()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("config.json");
            using var reader = new StreamReader(stream);
            var json = await reader.ReadToEndAsync();
            var config = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            
            return config["FirebaseApiKey"];
        }

        public static bool ValidEmailAndPassword(string email, string password)
        {
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return false;
            }
            if (password.Length < 6)
            {
                return false;
            }

            return true;
        }



    }
}
