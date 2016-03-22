using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Collections;

namespace Assets.MyAssets.Resources.Script.database
{
  
   public static class ManagerDB
    {
        private static string rootAPI = "http://speedrunnerapi.azurewebsites.net/WebServiceSpeedRunner.asmx";
        private static string rootAPIDebug = "http://localhost:63303/WebServiceSpeedRunner.asmx";


        private static string AddScore = rootAPI + "/AddScore";
        private static string AddScoreDebug = rootAPIDebug + "/AddScore";
        private static string AddGame = rootAPI + "/AddGame";
        private static string AddGameDebug = rootAPIDebug + "/AddGame";
        private static string password = "speedrunner@md5Token!";

        public static bool debugOption = false;

        public static void AddScoreToApi(string playerName, int score)
        {
            try
            {
                string url = AddScore;
                if (debugOption)
                    url = AddScoreDebug;
                WWWForm form = new WWWForm();
                form.AddField("password", CreateMD5(playerName + score.ToString() + password));
                form.AddField("user", playerName);
                form.AddField("score1", score.ToString());
                WWW www = new WWW(url, form);
            }
            catch(Exception e) { throw new Exception("Error when sending score"); };

            try
            {
                string url = AddGame;
                if (debugOption)
                    url = AddGameDebug;
                WWWForm form = new WWWForm();
                form.AddField("password", CreateMD5(playerName + score.ToString() + password));
                form.AddField("user", playerName);
                form.AddField("score1", score.ToString());

                WWW www = new WWW(url, form);
            }
            catch (Exception e) { throw new Exception("Error when sending game"); };

        }


        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
            byte[] bytes = ue.GetBytes(input);

            // encrypt bytes
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashBytes = md5.ComputeHash(bytes);

            // Convert the encrypted bytes back to a string (base 16)
            string hashString = "";

            for (int i = 0; i < hashBytes.Length; i++)
            {
                hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
            }

            return hashString;
        }

        //   private static MySqlConnection db;




    }
}
