// AdventOfCode2022-Day8

var lines = File.ReadAllLines("input.txt");
var rowCount = lines.Length;
var columnCount = lines.First().Length;

var visibleTrees = 0;
var scenicScoreMax = 0;
for (var row = 0; row < rowCount; row++)
{
    for (var column = 0; column < columnCount; column++)
    {
        if (column == 0 || column == columnCount - 1 || row == 0 || row == rowCount - 1)
        {
            visibleTrees++;
            continue;
        }
        
        var currentTreeHeight = int.Parse($"{lines[row][column]}");

        // Left check.
        var visibleFromLeft = true;
        var leftScenicScore = 0;
        for (var i = column - 1; i >= 0; i--)
        {
            var treeHeight = int.Parse($"{lines[row][i]}");
            leftScenicScore++;
            if (treeHeight >= currentTreeHeight)
            {
                visibleFromLeft = false;
                break;
            }
        }
        
        // Top check.
        var visibleFromTop = true;
        var topScenicScore = 0;
        for (var i = row - 1; i >= 0; i--)
        {
            var treeHeight = int.Parse($"{lines[i][column]}");
            topScenicScore++;
            if (treeHeight >= currentTreeHeight)
            {
                visibleFromTop = false;
                break;
            }
        }
        
        // Right check.
        var visibleFromRight = true;
        var rightScenicScore = 0;
        for (var i = column + 1; i < columnCount; i++)
        {
            var treeHeight = int.Parse($"{lines[row][i]}");
            rightScenicScore++;
            if (treeHeight >= currentTreeHeight)
            {
                visibleFromRight = false;
                break;
            }
        }
        
        // Bottom check.
        var visibleFromBottom = true;
        var bottomScenicScore = 0;
        for (var i = row + 1; i < rowCount; i++)
        {
            var treeHeight = int.Parse($"{lines[i][column]}");
            bottomScenicScore++;
            if (treeHeight >= currentTreeHeight)
            {
                visibleFromBottom = false;
                break;
            }
        }

        if (visibleFromLeft || visibleFromTop || visibleFromRight || visibleFromBottom)
        {
            visibleTrees++;
        }

        // Check scenic score.
        var currentScenicScore = leftScenicScore * topScenicScore * rightScenicScore * bottomScenicScore;
        if (currentScenicScore > scenicScoreMax)
        {
            scenicScoreMax = currentScenicScore;
        }
    }
}

Console.WriteLine($"Visible Trees:{visibleTrees}, Scenic Score Max:{scenicScoreMax}");