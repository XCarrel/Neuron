using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neuron
{
    /// <summary>
    /// A Glimpse is one interpretation of a
    /// </summary>
    class Glimpse
    {
        private Vector<double> InputValues;
        private Matrix<double> Weights;
        private Vector<double> Result;
        private Vector<double> Target;

        public Glimpse(Vector<double> inputValues, Matrix<double> weights, Vector<double> result, int target)
        {
            InputValues = inputValues;
            Weights = weights;
            Result = result;
            Target = Vector<double>.Build.DenseOfArray(new double[10]);
            Target[target] = 1;
        }

        /// <summary>
        /// Indicator that tells how bad the network has performed in recognizing the target in the input
        /// </summary>
        /// <returns></returns>
        public double Cost()
        {
            double res = 0;
            for (int i = 0; i < Result.Count; i++) res += Math.Pow(Result[i] - Target[i], 2);
            return res;
        }

        /// <summary>
        /// Returns a matrix of the changes that this training proposes to the weights matrix
        /// </summary>
        /// <param name="magnitude">A factor applied to the whole matrix to fine tune the impact it has</param>
        /// <returns></returns>
        public Matrix<double> WeightsNudge(double magnitude)
        {
            Matrix<double> res = Weights.Clone(); // Just to be sure we have the same sizes, we'll change all values
            for (int row=0; row<res.RowCount; row++)
                for (int col=0; col<res.ColumnCount; col++)
                    res[row, col] = (Target[row] - Result[row]) * InputValues[col] * magnitude;
            return res;
        }
    }
}
