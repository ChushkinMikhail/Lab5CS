using System;

class MyMatrix
    {
    private int[,] matrix;
    private int rows;
    private int columns;
    private Random random = new Random();

    public MyMatrix(int rows, int columns, int minValue, int maxValue)
        {
        this.rows = rows;
        this.columns = columns;
        matrix = new int[rows, columns];

        Fill(minValue, maxValue);
        }

    public void Fill(int minValue, int maxValue)
        {
        for (int i = 0; i < rows; i++)
            {
            for (int j = 0; j < columns; j++)
                {
                matrix[i, j] = random.Next(minValue, maxValue + 1);
                }
            }
        }

    public void ChangeSize(int newRows, int newColumns, int minValue, int maxValue)
        {
        if (newRows == rows && newColumns == columns)
            return;

        int[,] newMatrix = new int[newRows, newColumns];

        for (int i = 0; i < Math.Min(rows, newRows); i++)
            {
            for (int j = 0; j < Math.Min(columns, newColumns); j++)
                {
                newMatrix[i, j] = matrix[i, j];
                }
            }

        if (newRows > rows || newColumns > columns)
            {
            for (int i = 0; i < newRows; i++)
                {
                for (int j = 0; j < newColumns; j++)
                    {
                    if (i >= rows || j >= columns)
                        {
                        newMatrix[i, j] = random.Next(minValue, maxValue + 1);
                        }
                    }
                }
            }

        matrix = newMatrix;
        rows = newRows;
        columns = newColumns;
        }   

    public void PrintPartialy(int startRow, int endRow, int startColumn, int endColumn)
        {
        for (int i = startRow; i <= endRow && i < rows; i++)
            {
            for (int j = startColumn; j <= endColumn && j < columns; j++)
                {
                Console.Write(matrix[i, j] + " ");
                }
            Console.WriteLine();
            }
        }

    public void Print()
        {
        PrintPartialy(0, rows - 1, 0, columns - 1);
        }

    public int this[int index1, int index2]
        {
        get
            {
            if (index1 >= 0 && index1 < rows && index2 >= 0 && index2 < columns)
                {
                return matrix[index1, index2];
                }
            else
                {
                throw new IndexOutOfRangeException("Index out of range");
                }
            }
        set
            {
            if (index1 >= 0 && index1 < rows && index2 >= 0 && index2 < columns)
                {
                matrix[index1, index2] = value;
                }
            else
                {
                throw new IndexOutOfRangeException("Index out of range");
                }
            }
        }
    }

class MyProgram
    {
    static void Main()
        {
        Console.Write("Введите количество строк: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Введите количество столбцов: ");
        int columns = int.Parse(Console.ReadLine());

        Console.Write("Введите минимальное значение: ");
        int minValue = int.Parse(Console.ReadLine());

        Console.Write("Введите максимальное значение: ");
        int maxValue = int.Parse(Console.ReadLine());

        MyMatrix matrix = new MyMatrix(rows, columns, minValue, maxValue);

        Console.WriteLine("Наша матрица:");
        matrix.Print();

        Console.WriteLine("\nИзменяем размер матрицы");
        Console.Write("Введите новое количество строк: ");
        int newRows = int.Parse(Console.ReadLine());

        Console.Write("Введите новое количество столбцов: ");
        int newColumns = int.Parse(Console.ReadLine());

        matrix.ChangeSize(newRows, newColumns, minValue, maxValue);

        Console.WriteLine("Новая матрица:");
        matrix.Print();

        Console.WriteLine("\nОтображаем часть матрицы 3x3:");
        matrix.PrintPartialy(0, 2, 0, 2);

        Console.WriteLine("\nИзменяем элемент матрицы.");
        Console.Write("Введите индекс строки: ");
        int rowIndex = int.Parse(Console.ReadLine());

        Console.Write("Введите индекс столбца: ");
        int columnIndex = int.Parse(Console.ReadLine());

        Console.Write("Введите новое значение: ");
        int newValue = int.Parse(Console.ReadLine());

        matrix[rowIndex, columnIndex] = newValue;

        Console.WriteLine("Измененная матрица:");
        matrix.Print();
        MyMatrix Matrix = new MyMatrix(3, 3, 1, 10);
        matrix[0, 0] = 5; // Используется мутатор для установки значения
        int value = matrix[0, 0]; // Используется аксессор для получения значения
        }
    }
