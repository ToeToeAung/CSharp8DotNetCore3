public class MaximumMatrixSum {
    public long MaxMatrixSum(int[][] matrix) {
           if(matrix == null || matrix.Length == 0)
            return 0;
        
        long sum = 0;
        int m = matrix.Length, n = matrix[0].Length, nonPostiveNumCnt = 0, minNonPostiveNum = Int32.MaxValue;
        for(int i = 0; i < m; i++)
        {
            for(int j = 0; j < n; j++)
            {
                if(matrix[i][j] <= 0)
                {
                    sum -= matrix[i][j];
                    minNonPostiveNum = Math.Min(minNonPostiveNum, -matrix[i][j]);
                    nonPostiveNumCnt++;
                }
                else
                {
                    sum += matrix[i][j];
                    minNonPostiveNum = Math.Min(minNonPostiveNum, matrix[i][j]);
                }
            }
        }
        
        return nonPostiveNumCnt % 2 == 0? sum : sum - 2 * minNonPostiveNum;
    }
}