using System.IO;
using System.Media;
using System;

namespace Poe_part1
{
    public class voice_greeting
    {
        public voice_greeting()
        {
            string project_location = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine(project_location);

            string updated_path = project_location.Replace("bin\\Debug\\", "");
            string full_path = Path.Combine(updated_path, "Recording 1.wav");

            Play_wav(full_path);



        }
        // Method to play the sound
        private void Play_wav(string full_path)
        {
            // Try and catch
            try
            {
                using (SoundPlayer player = new SoundPlayer(full_path))
                {
                    player.PlaySync();
                }
            }
            catch (Exception error)
            {
                // Then show an error message
                Console.WriteLine(error.Message);
            }
        }
    }
}
