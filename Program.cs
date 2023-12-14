namespace FolderSync
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sourceDir = @"C:\Users\pedro\Desktop\tudo\teste";
            string destinationDir = @"C:\Users\pedro\Desktop\tudo\test6";

            try
            {
                // Check if the source directory exists
                if (Directory.Exists(sourceDir))
                {

                    if (!Directory.Exists(destinationDir))
                    {
                        Directory.CreateDirectory(destinationDir);
                    }

                    // Get all files in the source directory
                    string[] files = Directory.GetFiles(sourceDir);

                    // Copy each file to the destination directory
                    foreach (string file in files)
                    {
                        string fileName = Path.GetFileName(file);
                        string destFile = Path.Combine(destinationDir, fileName);
                        File.Copy(file, destFile, true); // 'true' to overwrite existing files if necessary
                    }

                    Console.WriteLine("Directory duplicated successfully.");
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

            Console.WriteLine("Carregue em uma tecla para limpar o diretorio replicado");
            Console.ReadKey();
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


        }
    }
}