// AdventOfCode2022-Day7

var lines = File.ReadAllLines("input.txt");
var rootDirectory = new Day7.Directory();
Day7.Directory pwd = rootDirectory;

// Create directory hierarchy.
foreach (var line in lines)
{
    var parts = line.Split(' ');
    if (parts[0] == "$")
    {
        if (parts[1] == "cd")
        {
            if (parts[2] == "..")
            {
                pwd = pwd.ParentDirectory;
            }
            else
            {
                if (!pwd.Directories.ContainsKey(parts[2]))
                {
                    pwd.Directories[parts[2]] = new Day7.Directory
                    {
                        ParentDirectory = pwd,
                    };
                }

                pwd = pwd.Directories[parts[2]];
            }
        }
    }
    else if (parts[0] == "dir")
    {
        if (!pwd.Directories.ContainsKey(parts[1]))
        {
            pwd.Directories[parts[1]] = new Day7.Directory
            {
                ParentDirectory = pwd,
            };
        }
    }
    else
    {
        pwd.Files[parts[1]] = int.Parse(parts[0]);
    }
}

// Find sum of all directories <= 100,000.
var sum = rootDirectory
    .GetAllDirectoriesWhere(x => x.Size <= 100_000)
    .Select(x => x.Size)
    .Sum();
    
rootDirectory.PrintHierarchy();
Console.WriteLine($"1. Sum:{sum}");
var used = rootDirectory.Size;
var free = 70_000_000 - used;
var needToDelete = 30_000_000 - free;
Console.WriteLine($"Total Used:{used}");
Console.WriteLine($"Total Free:{free}");

var directorySizeToDelete = rootDirectory
    .GetAllDirectoriesWhere(x => x.Size >= needToDelete)
    .Select(x => x.Size)
    .Min();
    
Console.WriteLine($"Directory size to delete:{directorySizeToDelete}");