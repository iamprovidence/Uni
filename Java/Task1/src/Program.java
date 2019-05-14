package src;

import models.math.*;
import models.Education.*;
import models.Education.Enums.*;

import java.util.Scanner;
import java.util.stream.Collectors;

import java.util.InputMismatchException;

public class Program
{
    public static void main (String args[])
    {
        Scanner reader = new Scanner(System.in);

        // 1
        // Дано прямокутну матрицю розмірності N*M .
        // Утворити вектор, кожен елемент якого дорівнює максимуму
        // із суми цифр елементів відповідного рядка матриці.

        // input
        int rows;
        int cols;
        try
        {

            System.out.println("Input num of rows (n): ");
            rows = reader.nextInt();
            System.out.println("Input num of cols (m): ");
            cols = reader.nextInt();
            reader.nextLine(); // reset reader
        }
        catch (InputMismatchException ex)
        {
            System.out.println("Wrong input");

            reader.close();
            return;
        }

        // initialize
        Matrix matrix;
        try
        {
            matrix = new Matrix(rows, cols);
        }
        catch (NegativeMatrixSizeException ex)
        {
            System.out.println("Can not build matrix");

            reader.close();
            return;
        }
        matrix.randomize();

        // show matrix
        System.out.println("Current matrix");
        System.out.println(matrix);

        // calc vector
        Matrix vector = new Matrix(rows, 1); // if 'rows' is wrong, program will be interrupted before this line
        for (int i = 0; i < rows; ++i)
        {
            // calc digit sum
            Iterable<Integer> digitSum = Algorithms.transformNumberToDigitSum(java.util.stream.IntStream.of( matrix.getRow(i) ).boxed().collect(Collectors.toList()));

            // find max
            vector.set(i, 0, Algorithms.maxValue(digitSum));
        }

        // print vector
        System.out.println("Vector with max digit values:");
        System.out.println(vector);

        // 2
        // Дано послідовність слів, розділених комами.
        // Видрукувати слова, попередньо перетворивши кожне із них за
        // правилом: вставити після кожної літери 'T' літеру 'H'

        System.out.println("Input string :");
        String result = reader.nextLine().replaceAll("t", "th");
        System.out.println("Insert after all 't', the letter 'h'");
        System.out.println(result);
        System.out.println();

        // 3
        // Створити базовий клас навчальний заклад (назва, адрес, рік заснування)
        // та похідні класи - СШ (номер, к-сть учнів) і ВУЗ (рівень акредитації, к-сть факультетів).
        // Дано масив навчальних закладів.
        // − Посортувати його за роком заснування.
        // − Знайти школу з мінімальною к-стю учнів.
        // − Вивести ВУЗи вказаного рівня акредитації.

        AbstractEducationalInstitution[] institutions = new AbstractEducationalInstitution[]
                {
                        new School(),
                        new University(),
                        new School(),
                        new University(),
                        new School(),
                        new University(),
                        new University(),
                        new University(),
                        new School(),
                };

        // - sorting
        System.out.println("Institution list: ");
        System.out.println(java.util.Arrays.toString(institutions));

        java.util.Arrays.sort(institutions, new InstitutionComparator(InstitutionCompareType.Year));

        System.out.println("Institution list, after sorting: ");
        System.out.println(java.util.Arrays.toString(institutions));

        // - find school
        School schoolWithMinPupilsAmount = null;

        // find school with min amount of pupils
        for (AbstractEducationalInstitution institution: institutions)
        {
            if (institution instanceof School)
            {
                // find first occurrence of school
                if (schoolWithMinPupilsAmount == null)
                {
                    schoolWithMinPupilsAmount = (School) institution;
                }

                // find min
                if (((School)institution).getPupilsAmount() < schoolWithMinPupilsAmount.getPupilsAmount())
                {
                    schoolWithMinPupilsAmount = (School) institution;
                }
            }
        }

        // show it
        if (schoolWithMinPupilsAmount == null)
        {
            System.out.println("There is no school");
        }
        else
        {
            System.out.println("School with min amount of pupils");
            System.out.println(schoolWithMinPupilsAmount);
        }

        // - show universities
        System.out.println("Sets level of accreditation: ");
        System.out.println(java.util.Arrays.toString(LevelOfAccreditation.values()));

        // sets level of accreditation
        LevelOfAccreditation levelOfAccreditation;
        try
        {
            levelOfAccreditation = LevelOfAccreditation.valueOf(reader.next());
        }
        catch (java.lang.IllegalArgumentException ex)
        {
            System.out.println("Wrong enum value");

            reader.close();
            return;
        }

        // shows universities list
        System.out.println("Shows universities list: ");
        for (AbstractEducationalInstitution institution: institutions)
        {
            if (institution instanceof University && ((University)institution).getLevelOfAccreditation() == levelOfAccreditation)
            {
                System.out.println(institution);
            }
        }

        reader.close();
    }
}
