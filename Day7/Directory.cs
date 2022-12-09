namespace Day7;

public class Directory
{
    public Directory ParentDirectory { get; set; } = null;
    public IDictionary<string, Directory> Directories { get; } = new Dictionary<string, Directory>();
    public IDictionary<string, long> Files { get; } = new Dictionary<string, long>();

    public long Size
    {
        get
        {
            long size = 0;
            foreach (var directory in this.Directories)
            {
                size += directory.Value.Size;
            }
            
            foreach (var file in this.Files)
            {
                size += file.Value;
            }

            return size;
        }
    }

    public void PrintHierarchy(int level = 0)
    {
        foreach (var file in this.Files)
        {
            Console.WriteLine(new string(' ', 4 * level) + file.Key + $" (File, {file.Value})");
        }
        
        foreach (var directory in this.Directories)
        {
            Console.WriteLine(new string(' ', 4 * level) + directory.Key + $" (Directory, {directory.Value.Size})");
            directory.Value.PrintHierarchy(level + 1);
        }
    }

    public IEnumerable<Directory> GetAllDirectoriesWhere(Func<Directory, bool> predicate)
    {
        var directories = new HashSet<Directory>();
        foreach (var directory in this.Directories)
        {
            var newDirectories = directory.Value.GetAllDirectoriesWhere(predicate);
            foreach (var newDirectory in newDirectories)
            {
                directories.Add(newDirectory);
            }
        }

        if (predicate(this))
        {
            directories.Add(this);
        }

        return directories;
    }
}