using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Buchhaltung
{
    static internal class ProfileManager
    {
        public static Profile CurrentProfile { get; private set; }

        public static void CreateProfile(string name, decimal ballance)
        {
            CurrentProfile = new Profile(name, ballance);
            SaveProfile(CurrentProfile);
        }

        public static void SaveProfile(Profile profile)
        {
            string filePath = AppContext.BaseDirectory + profile.Name + ".prof";
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            try
            {
                using(FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    binaryFormatter.Serialize(fs, profile);
                }
            }
            catch (Exception ex)
            { 
                Console.Clear(); 
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        public static void LoadProfile(string profilePath)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            try
            {
                using(FileStream stream = new FileStream(profilePath, FileMode.Open))
                {
                    CurrentProfile = (Profile)binaryFormatter.Deserialize(stream);
                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        public static bool CheckIfProfileExists(string profileName)
        {
            string fullPath = AppContext.BaseDirectory + profileName + ".prof";
            return File.Exists(fullPath);
        }
    }
}
