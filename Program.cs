namespace FolderSync
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sourceDir = @"C:\Users\pedro\Desktop\tudo\teste";//Puth the origin path
            string destinationDir = @"C:\Users\pedro\Desktop\tudo\test7";//Put the replica path 

            //Sync 
            int intervalo = 1 * 60 * 1000; //running the sync every 1 minute

            //Create a timer
            Timer timer = new Timer(SyncDirectories, new { SourceDir = sourceDir, DestinationDir = destinationDir }, 0, intervalo);





           
            Console.WriteLine("Sync satrated. Press Q to quit");
            while (Console.ReadKey(true).Key != ConsoleKey.Q)
            {
               

            }
            timer.Dispose();

            Console.WriteLine("Press F to clear the directory");
            while (Console.ReadKey(true).Key != ConsoleKey.F)
            {

            }


            if (Directory.Exists(destinationDir))
            {
                // Check if the destination directory exists
                if (Directory.Exists(destinationDir))
                {
                    // Delete all files in the destination directory
                    string[] destFiles = Directory.GetFiles(destinationDir);
                    foreach (string file in destFiles)
                    {
                        File.Delete(file);
                    }
                }
                else
                {
                    // Create the destination directory if it doesn't exist
                    Directory.CreateDirectory(destinationDir);
                }

            }
            Console.WriteLine("Folder Clear");

           
        }
        static void SyncDirectories(object state)
        {
            dynamic directories = state;
            string sourceDir = directories.SourceDir;
            string destinationDir = directories.DestinationDir;

            try
            {
                // Check if the source directory exists
                if (Directory.Exists(sourceDir))
                {
                    // Check if the destination directory exists
                    if (Directory.Exists(destinationDir))
                    {
                        // Delete all files in the destination directory
                        string[] destFiles = Directory.GetFiles(destinationDir);
                        foreach (string file in destFiles)
                        {
                            File.Delete(file);
                        }
                    }
                    else
                    {
                        // Create the destination directory if it doesn't exist
                        Directory.CreateDirectory(destinationDir);
                    }

                    //Couldnt get access to the folder because of permissions in my system

                    //string[] folders =Directory.GetDirectories(sourceDir);
                    //foreach(string folder in folders)
                    //{
                    //    string folderName=Path.GetFileName(folder);
                    //    string destFile = Path.Combine(destinationDir, folderName);
                    //    File.Copy(folder, destFile, true);
                    //}




                    // Get all files in the source directory except folders
                    string[] files = Directory.GetFiles(sourceDir);

                    // Copy each file to the destination directory
                    foreach (string file in files)
                    {
                        string fileName = Path.GetFileName(file);
                        string destFile = Path.Combine(destinationDir, fileName);
                        File.Copy(file, destFile, true); // 'true' to overwrite existing files if necessary
                    }

                    Console.WriteLine($"Synchronized directories at {DateTime.Now}.");
                }
                else
                {
                    Console.WriteLine("Source directory does not exist.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}