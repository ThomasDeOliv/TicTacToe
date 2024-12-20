using Connect4.Models.BoardModel.ColumnModel.CellModel;
using FluentAssertions;

namespace Connect4.Tests
{
    public class BoardTests
    {
        [Fact]
        public void TDD_1()
        {
            // Arrange
            const int ROW_LENGTH = 7;
            const int COLUMN_LENGTH = 6;
            List<ICell> cells = new List<ICell>();
            for (int i = 0; i < ROW_LENGTH; i++)
            {
                for (int j = 0; j < COLUMN_LENGTH; j++)
                {
                    cells.Add(Cell.Create(CellState.RED, i, j));
                }
            }

            // Act 
            int red = cells.Count((c) => c.Value.Equals(CellState.RED));
            int yellow = cells.Count((c) => c.Value.Equals(CellState.YELLOW));

            // Assert
            red.Should().Be(42); // ROW_LENGTH * COLUMN_LENGTH = 42
            yellow.Should().Be(0);

            // Empty GRID with good dimensions
        }

        [Fact]
        public void TDD_2()
        {
            // Arrange
            const int ROW_LENGTH = 7;
            const int COLUMN_LENGTH = 6;
            List<ICell> cells = new List<ICell>();
            for (int i = 0; i < ROW_LENGTH; i++)
            {
                for (int j = 0; j < COLUMN_LENGTH; j++)
                {
                    if (j == 0 && i == 0) // ADD 1 YELLOW TOKEN
                    {
                        cells.Add(Cell.Create(CellState.YELLOW, i, j));
                    }
                    else // 41 EMPTY 
                    {
                        cells.Add(Cell.Create(CellState.RED, i, j));
                    }
                }
            }

            // Act 
            int red = cells.Count((c) => c.Value.Equals(CellState.RED));
            int yellow = cells.Count((c) => c.Value.Equals(CellState.YELLOW));

            // Assert
            red.Should().Be(42 - 1); // ROW_LENGTH * COLUMN_LENGTH = 42
            yellow.Should().Be(1);

            // Empty GRID with good dimensions, fulled like we want but no "gravity effect"
        }

        [Fact]
        public void TDD_3()
        {
            // Arrange
            const int ROW_LENGTH = 7;
            const int COLUMN_LENGTH = 6;
            List<Stack<ICell>> cells = new List<Stack<ICell>>();

            for (int i = 0; i < COLUMN_LENGTH; i++)
            {
                cells.Add(new Stack<ICell>());

                for (int j = 0; j < ROW_LENGTH; j++)
                {
                    cells[i].Push(Cell.Create(CellState.RED, i, j));
                }
            }

            // Act 
            int redCellCount = cells.Sum((s) => s.Count);

            // Assert
            redCellCount.Should().Be(42); // ROW_LENGTH * COLUMN_LENGTH = 42
        }
    }
}