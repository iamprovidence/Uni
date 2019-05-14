package models.math;

import java.util.Random;

public class Matrix
{
    // FIELDS
    int[][] base;
    int rows;
    int cols;

    // CONSTRUCTORS
    public Matrix(int rows, int cols)
        throws NegativeMatrixSizeException
    {
        if (rows <= 0) throw new NegativeMatrixSizeException();
        if (cols <= 0) throw new NegativeMatrixSizeException();

        this.rows = rows;
        this.cols = cols;
        this.base = new int[rows][];
        for (int i = 0; i < rows; ++i)
        {
            this.base[i] = new int[cols];
        }
    }

    public void randomize()
    {
        java.util.Random random = new Random();
        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < cols; ++j)
            {
                base[i][j] = random.nextInt(1000);
            }
        }
    }

    // METHODS
    public void set(int i, int j, int value)
            throws ArrayIndexOutOfBoundsException
    {
        base[i][j] = value;
    }
    public int[] getRow(int index)
        throws ArrayIndexOutOfBoundsException
    {
        return base[index];
    }

    @Override
    public String toString()
    {
        StringBuilder builder = new StringBuilder("Matrix\n");
        builder.append("rows - " + rows + "\n");
        builder.append("cols - " + cols + "\n");

        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < cols; ++j)
            {
                builder.append(" " + base[i][j]);
            }
            builder.append("\n");
        }
        return builder.toString();
    }
}
