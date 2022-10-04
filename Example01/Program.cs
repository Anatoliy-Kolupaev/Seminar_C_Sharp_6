// игра движение собачки
String[,] matrix = {                  //создание поля для передвижения собачки
    {" ", " ", " ", " ", " ", " ",},
    {" ", " ", " ", " ", " ", " ",},
    {" ", "@", " ", " ", " ", " ",}, // @  - собачка
    {" ", " ", " ", " ", " ", " ",},
    {" ", " ", " ", "$", " ", " ",},
    {" ", " ", " ", " ", " ", " ",}};

int X = 1; // координаты где находится собачка 
int Y = 2; // в 1 строке 2 столбце ( нумерация с 0)
int point = 0;

void WriteArrayMatrix(string[,] matrix) //  функция вывода в консоль поля и собачки
{
    for (int y = 0; y < matrix.GetLength(0); y++)
    {
        for (int x = 0; x < matrix.GetLength(1); x++)
        {
            Console.Write(matrix[y, x] + " ");
        }
        Console.WriteLine();
    }
}
void WriteCoordinates (int X, int Y, int point) // функция вывода в терсмнал координат нахождения собачки
{
    Console.WriteLine($"X = {X} Y = {Y} point = {point}");
}
int BonusCreator(string[,] matrix, int X, int Y, int point) // функция считает очки после того как собака сьест $ и делает появление его в рандом месте
{
    while (matrix[Y,X] == "$")
    {
        point++;
        matrix[Y, X] = " ";
        int newCoordBonusY = new Random().Next(0, matrix.GetLength(0));
        int newCoordBonusX = new Random().Next(0, matrix.GetLength(1));
        matrix[newCoordBonusY, newCoordBonusX] = "$";
    }
    return point;
}

void Geme(string[,] matrix, int X, int Y, int point) // функция кот будет запускать игру
{
    while (true) //  true - бесконечный цикл
    {
        matrix[Y, X] = " ";  // все начинается с Y 
        ConsoleKeyInfo user_KeyTab = Console.ReadKey(); // ConsoleKeyInfo - тип данных кот содерж в себе именно клавишу. Console.ReadKey() - запрос клавиши
        if (user_KeyTab.Key == ConsoleKey.W) Y--; // .Key - там сохранена клавиша
        if (user_KeyTab.Key == ConsoleKey.S) Y++; // ConsoleKey.клавиша
        if (user_KeyTab.Key == ConsoleKey.A) X--;
        if (user_KeyTab.Key == ConsoleKey.D) X++;
        if (Y < 0) Y = 0;                                              // задаем границы поля
        if (X < 0) X = 0;                                              // задаем границы поля
        if (X > matrix.GetLength(1) - 1) X = matrix.GetLength(1) - 1;  // задаем границы поля
        if (Y > matrix.GetLength(0) - 1) Y = matrix.GetLength(0) - 1;  // задаем границы поля
        point = BonusCreator(matrix, X, Y, point);
        matrix[Y, X] = "@";
        Console.Clear();  // зачистить все поле
        WriteArrayMatrix(matrix);
        WriteCoordinates(X, Y, point);

    }
}

WriteArrayMatrix(matrix);
Geme(matrix, X, Y, point);