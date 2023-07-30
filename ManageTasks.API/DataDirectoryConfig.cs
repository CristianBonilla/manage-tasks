namespace ManageTasks.API
{
  class DataDirectoryConfig
  {
    const string AppData = "App_Data";
    const string DataDirectory = "[DataDirectory]";

    public static string DirectoryPath
    {
      get
      {
        string baseDirectory = Directory.GetCurrentDirectory();
        int lastIndex = baseDirectory.ToLower().LastIndexOf(@"bin\debug\");
        int length = lastIndex >= 0 ? lastIndex : baseDirectory.Length;
        string directory = baseDirectory[..length];

        return directory;
      }
    }

    public static void SetDataDirectoryPath(ref string connectionString)
    {
      if (string.IsNullOrEmpty(connectionString))
        throw new ArgumentNullException(nameof(connectionString), "The connection string should be defined");

      string appDataPath = Path.Combine(DirectoryPath, AppData);
      if (!Directory.Exists(appDataPath))
        Directory.CreateDirectory(appDataPath);
      connectionString = connectionString.Replace(
          DataDirectory,
          appDataPath,
          StringComparison.OrdinalIgnoreCase);
    }
  }
}
