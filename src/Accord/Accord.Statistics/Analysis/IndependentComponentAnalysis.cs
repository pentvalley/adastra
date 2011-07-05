﻿// Accord Statistics Library
// The Accord.NET Framework
// http://accord-net.origo.ethz.ch
//
// Copyright © César Souza, 2009-2011
// cesarsouza at gmail.com
// http://www.crsouza.com
//

namespace Accord.Statistics.Analysis
{
    using System;
    using System.Collections.ObjectModel;
    using Accord.Math;
    using Accord.Math.Decompositions;
    using Accord.Statistics.Analysis.ContrastFunctions;

    /// <summary>
    ///   FastICA's algorithms to be used in Independent Component Analysis.
    /// </summary>
    public enum IndependentComponentAlgorithm
    {
        /// <summary>
        ///   Deflation algorithm.
        /// </summary>
        /// <remarks>
        ///   In the deflation algorithm, components are found one
        ///   at a time through a series of sequential operations.
        ///   It is particularly useful when only a small number of
        ///   components should be computed from the input data set.
        /// </remarks>
        Deflation,

        /// <summary>
        ///   Symmetric parallel algorithm (default).
        /// </summary>
        /// <remarks>
        ///   In the parallel (symmetric) algorithm, all components
        ///   are computed at once. This is the default algorithm for
        ///   <seealso cref="IndependentComponentAnalysis">Independent
        ///   Component Analysis</seealso>.
        /// </remarks>
        Parallel,
    }

    /// <summary>
    ///   Independent component analysis (ICA) is a computational method for separating
    ///   a multivariate signal (or mixture) into its additive subcomponents, supposing
    ///   the mutual statistical independence of the non-Gaussian source signals.
    /// </summary>
    /// 
    /// <remarks>
    /// <para>
    ///   When the independence assumption is correct, blind ICA separation of a mixed
    ///   signal gives very good results. It is also used for signals that are not supposed
    ///   to be generated by a mixing for analysis purposes.</para>  
    /// <para>
    ///   A simple application of ICA is the "cocktail party problem", where the underlying
    ///   speech signals are separated from a sample data consisting of people talking
    ///   simultaneously in a room. Usually the problem is simplified by assuming no time
    ///   delays or echoes.</para>
    /// <para>
    ///   An important note to consider is that if N sources are present, at least N
    ///   observations (e.g. microphones) are needed to get the original signals.</para>
    ///   
    /// <para>
    ///   References:
    ///   <list type="bullet">
    ///     <item><description>
    ///       Hyvärinen,A (1999). Fast and Robust Fixed-Point Algorithms for Independent Component
    ///       Analysis. IEEE Transactions on Neural Networks, 10(3),626-634. Available on: 
    ///       <a href="http://cran.r-project.org/web/packages/fastICA/index.html">
    ///       http://cran.r-project.org/web/packages/fastICA/index.html</a></description></item>
    ///  </list></para>  
    /// </remarks>
    /// 
    [Serializable]
    public class IndependentComponentAnalysis : IMultivariateAnalysis
    {
        private double[,] sourceMatrix;

        
        private double[,] whiteningMatrix; // pre-whitening matrix
        private double[,] mixingMatrix; // estimated mixing matrix
        private double[,] revertMatrix; // estimated de-mixing matrix
        private double[,] resultMatrix;

        private Single[][] revertArray; // for caching conversions
        private Single[][] mixingArray;

        private AnalysisMethod analysisMethod = AnalysisMethod.Center;
        private bool overwriteSourceMatrix;

        private double[] columnMeans;
        private double[] columnStdDev;

        private int maxIterations = 200;
        private double tolerance = 1e-4;

        private IndependentComponentAlgorithm algorithm;
        private IContrastFunction contrast = new Logcosh();

        private IndependentComponentCollection componentCollection;


        //---------------------------------------------


        #region Constructors
        /// <summary>Constructs a new Independent Component Analysis.</summary>
        public IndependentComponentAnalysis(double[,] data)
            : this(data, AnalysisMethod.Center, IndependentComponentAlgorithm.Parallel)
        {
        }

        /// <summary>Constructs a new Independent Component Analysis.</summary>
        public IndependentComponentAnalysis(double[,] data, IndependentComponentAlgorithm algorithm)
            : this(data, AnalysisMethod.Center, algorithm)
        {
        }

        /// <summary>Constructs a new Independent Component Analysis.</summary>
        public IndependentComponentAnalysis(double[,] data, AnalysisMethod method)
            : this(data, method, IndependentComponentAlgorithm.Parallel)
        {
        }

        /// <summary>Constructs a new Independent Component Analysis.</summary>
        public IndependentComponentAnalysis(double[,] data, AnalysisMethod method, IndependentComponentAlgorithm algorithm)
        {
            if (data == null) throw new ArgumentNullException("data");

            this.sourceMatrix = data;
            this.algorithm = algorithm;
            this.analysisMethod = method;

            // Calculate common measures to speedup other calculations
            this.columnMeans = Accord.Statistics.Tools.Mean(sourceMatrix);
            this.columnStdDev = Accord.Statistics.Tools.StandardDeviation(sourceMatrix, columnMeans);
        }
        #endregion


        //---------------------------------------------


        #region Properties
        /// <summary>
        ///   Source data used in the analysis.
        /// </summary>
        /// 
        public double[,] Source
        {
            get { return sourceMatrix; }
        }

        /// <summary>
        ///   Gets or sets the maximum number of iterations 
        ///   to perform. If zero, the method will run until
        ///   convergence.
        /// </summary>
        /// <value>The iterations.</value>
        /// 
        public int Iterations
        {
            get { return maxIterations; }
            set { maxIterations = value; }
        }

        /// <summary>
        ///   Gets or sets the maximum absolute change in
        ///   parameters between iterations that determine
        ///   convergence.
        /// </summary>
        /// 
        public double Tolerance
        {
            get { return tolerance; }
            set { tolerance = value; }
        }

        /// <summary>
        ///   Gets the resulting projection of the source
        ///   data given on the creation of the analysis 
        ///   into the space spawned by independent components.
        /// </summary>
        /// <value>The resulting projection in independent component space.</value>
        /// 
        public double[,] Result
        {
            get { return resultMatrix; }
        }

        /// <summary>
        ///   Gets a matrix containing the mixing coefficients for
        ///   the original source data being analyzed. Each column
        ///   corresponds to an independent component.
        /// </summary>
        /// 
        public double[,] MixingMatrix
        {
            get { return mixingMatrix; }
        }

        /// <summary>
        ///   Gets a matrix containing the unmixing coefficients for
        ///   the original source data being analyzed. Each column
        ///   corresponds to an independent component.
        /// </summary>
        /// 
        public double[,] DemixingMatrix
        {
            get { return revertMatrix; }
        }

        /// <summary>
        ///   Gets the whitening matrix used to transform
        ///   the original data to have unit variance.
        /// </summary>
        public double[,] WhiteningMatrix
        {
            get { return whiteningMatrix; }
        }

        /// <summary>
        ///   Gets the Independent Components in a object-oriented structure.
        /// </summary>
        /// <value>The collection of independent components.</value>
        /// 
        public IndependentComponentCollection Components
        {
            get { return componentCollection; }
        }

        /// <summary>
        ///   Gets or sets whether calculations will be performed overwriting
        ///   data in the original source matrix, using less memory.
        /// </summary>
        /// 
        public bool Overwrite
        {
            get { return overwriteSourceMatrix; }
            set { overwriteSourceMatrix = value; }
        }

        /// <summary>
        ///  Gets or sets the <see cref="IndependentComponentAlgorithm">
        ///  FastICA</see> algorithm used by the analysis.
        /// </summary>
        /// 
        public IndependentComponentAlgorithm Algorithm
        {
            get { return algorithm; }
            set { algorithm = value; }
        }

        /// <summary>
        ///   Gets or sets the <see cref="IContrastFunction">
        ///   Contrast function</see> to be used by the analysis.
        /// </summary>
        /// 
        public IContrastFunction Contrast
        {
            get { return contrast; }
            set { contrast = value; }
        }
        #endregion



        //---------------------------------------------


        #region Public methods

        /// <summary>
        ///   Computes the Independent Component Analysis algorithm.
        /// </summary>
        public void Compute()
        {
            Compute(sourceMatrix.GetLength(1));
        }

        /// <summary>
        ///   Computes the Independent Component Analysis algorithm.
        /// </summary>
        public void Compute(int components)
        {
            // First, the data should be centered by subtracting
            //  the mean of each column in the source data matrix.
            double[,] matrix = Adjust(sourceMatrix, overwriteSourceMatrix);

            // Pre-process the centered data matrix to have unit variance
            double[,] whiten = Statistics.Tools.Whitening(matrix, out whiteningMatrix);

            // Generate a initial guess for the de-mixing matrix
            double[,] initial = Matrix.Random(components, matrix.GetLength(1));


            // Compute the demixing matrix using the selected algorithm
            if (algorithm == IndependentComponentAlgorithm.Deflation)
            {
                revertMatrix = deflation(whiten, components, initial);
            }
            else
            {
                revertMatrix = parallel(whiten, components, initial);
            }


            // Combine the rotation and demixing matrices
            revertMatrix = whiteningMatrix.MultiplyByTranspose(revertMatrix);

            // TODO: Normalize the reversion matrix

            // Compute the original source mixing matrix
            mixingMatrix = Matrix.PseudoInverse(revertMatrix);

            // Demix the data into independent components
            resultMatrix = matrix.Multiply(revertMatrix);


            // Creates the object-oriented structure to hold the principal components
            IndependentComponent[] array = new IndependentComponent[components];
            for (int i = 0; i < array.Length; i++)
                array[i] = new IndependentComponent(this, i);
            this.componentCollection = new IndependentComponentCollection(array);
        }

        /// <summary>
        ///   Separates a mixture into its components (demixing).
        /// </summary>
        public double[,] Separate(double[,] data)
        {
            // Data-adjust and separate the samples
            double[,] matrix = Adjust(data, false);

            return matrix.Multiply(revertMatrix);
        }

        /// <summary>
        ///   Separates a mixture into its components (demixing).
        /// </summary>
        public float[][] Separate(float[][] data)
        {
            if (revertArray == null)
            {
                // Convert reverting matrix to single
                revertArray = convert(revertMatrix);
            }

            // Data-adjust and separate the sources
            float[][] matrix = Adjust(data, false);

            return revertArray.Multiply(matrix);
        }


        /// <summary>
        ///   Combines components into a single mixture (mixing).
        /// </summary>
        public double[,] Combine(double[,] data)
        {
            return data.Multiply(mixingMatrix);
        }

        /// <summary>
        ///   Combines components into a single mixture (mixing).
        /// </summary>
        public float[][] Combine(float[][] data)
        {
            if (mixingArray == null)
            {
                // Convert mixing matrix to single
                mixingArray = convert(mixingMatrix);
            }

            return mixingArray.Multiply(data);
        }
        #endregion


        //---------------------------------------------


        #region FastICA Algorithms

        /// <summary>
        ///   Deflation iterative algorithm.
        /// </summary>
        /// <returns>
        ///   Returns a matrix in which each row contains
        ///   the mixing coefficients for each component.
        /// </returns>
        private double[,] deflation(double[,] X, int components, double[,] init)
        {
            int n = X.GetLength(0);
            int m = X.GetLength(1);

            // Algorithm initialization
            double[,] W = new double[components, m];
            double[] wx = new double[n];
            double[] gwx = new double[n];
            double[] dgwx = new double[n];


            // For each component to be computed,
            for (int i = 0; i < components; i++)
            {
                // Will compute each of the basis vectors
                //  invidually and sequentially, re-using
                //  previous computations to form basis W. 
                //  

                // Initialization
                int iterations = 0;
                bool stop = false;

                double[] w = init.GetRow(i);
                double[] w0 = init.GetRow(i);


                do // until convergence
                {
                    // Deflaction
                    for (int u = 0; u < i; u++)
                    {
                        double k = 0;
                        for (int j = 0; j < m; j++)
                            k += w0[j] * W[u, j];

                        for (int j = 0; j < m; j++)
                            w[j] = w0[j] - k * W[u, j];
                    }

                    // Normalize
                    w = w.Divide(Norm.Euclidean(w));


                    // Gets the maximum absolute change in the parameters
                    double delta = System.Math.Abs(System.Math.Abs(Matrix.Sum(w.ElementwiseMultiply(w0))) - 1);

                    // Check for convergence
                    if (!(delta > tolerance && iterations < maxIterations))
                    {
                        stop = true;
                    }
                    else
                    {
                        // Advance to the next iteration
                        w0 = w; w = new double[m];
                        iterations++;

                        // Compute wx = w*x
                        for (int j = 0; j < n; j++)
                        {
                            double s = 0;
                            for (int k = 0; k < m; k++)
                                s += w0[k] * X[j, k];
                            wx[j] = s;
                        }

                        // Compute g(w*x) and g'(w*x)
                        contrast.Evaluate(wx, gwx, dgwx);

                        // Compute E{ x*g(w*x) }
                        double[] means = new double[m];
                        for (int j = 0; j < m; j++)
                        {
                            for (int k = 0; k < n; k++)
                                means[j] += X[k, j] * gwx[k];
                            means[j] /= n;
                        }

                        // Compute E{ g'(w*x) }
                        double mean = Statistics.Tools.Mean(dgwx);


                        // Compute next update for w
                        for (int j = 0; j < m; j++)
                            w[j] = means[j] - w0[j] * mean;

                    }

                } while (!stop);

                // Store the just computed component
                // in the resulting component matrix.
                W.SetRow(i, w);
            }

            // Return the component basis matrix
            return W; // vectors stored as rows.
        }

        /// <summary>
        ///   Parallel (symmetric) iterative algorithm.
        /// </summary>
        /// <returns>
        ///   Returns a matrix in which each row contains
        ///   the mixing coefficients for each component.
        /// </returns>
        private double[,] parallel(double[,] X, int components, double[,] winit)
        {
            int n = X.GetLength(0);
            int m = X.GetLength(1);

            // Algorithm initialization
            double[,] W0 = winit;
            double[,] W = winit;
            double[,] K = new double[components, components];

            bool stop = false;
            int iterations = 0;


            do // until convergence
            {

                // Perform simultaneous decorrelation of all components at once
                var svd = new SingularValueDecomposition(W, true, false, true);
                var S = svd.Diagonal;
                var U = svd.LeftSingularVectors;

                // Normalize
                for (int i = 0; i < components; i++)
                {
                    for (int j = 0; j < components; j++)
                    {
                        double s = 0;
                        for (int k = 0; k < components; k++)
                            if (S[k] != 0.0)
                                s += U[i, k] * U[j, k] / S[k];
                        K[i, j] = s;
                    }
                }

                // Decorrelate
                W = K.Multiply(W);


                // Gets the maximum absolute change in the parameters
                double delta = Matrix.Max(Matrix.Abs(Matrix.Abs(Matrix.Diagonal(W0.Multiply(W.Transpose()))).Subtract(1.0)));

                // Check for convergence
                if (delta < tolerance || iterations >= maxIterations)
                {
                    stop = true;
                }
                else
                {
                    // Advance to the next iteration
                    W0 = W; W = new double[components,m];
                    iterations++;


#if DEBUG           // For each component (in parallel)
                    for (int i = 0; i < components; i++)
#else
                    AForge.Parallel.For(0, components, i =>
#endif
                    {
                        double[] wx = new double[n];
                        double[] dgwx = new double[n];
                        double[] gwx = new double[n];
                        double[] means = new double[m];

                        // Compute wx = w*x
                        for (int j = 0; j < n; j++)
                        {
                            double s = 0;
                            for (int k = 0; k < m; k++)
                                s += W0[i, k] * X[j, k];
                            wx[j] = s;
                        }

                        // Compute g(wx) and g'(wx)
                        contrast.Evaluate(wx, gwx, dgwx);

                        // Compute E{ x*g(w*x) }
                        for (int j = 0; j < m; j++)
                        {
                            for (int k = 0; k < n; k++)
                                means[j] += X[k, j] * gwx[k];
                            means[j] /= n;
                        }

                        // Compute E{ g'(w*x) }
                        double mean = Statistics.Tools.Mean(dgwx);


                        // Compute next update for w
                        for (int j = 0; j < m; j++)
                            W[i, j] = means[j] - W0[i, j] * mean;
                    }
#if !DEBUG
);
#endif
                }

            } while (!stop);

            // Return the component basis matrix
            return W; // vectors stored as rows.
        }

        #endregion


        //---------------------------------------------


        #region Auxiliary methods

        /// <summary>
        ///   Adjusts a data matrix, centering and standardizing its values
        ///   using the already computed column's means and standard deviations.
        /// </summary>
        protected double[,] Adjust(double[,] matrix, bool inPlace)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            // Prepare the data, storing it in a new matrix if needed.
            double[,] result = inPlace ? matrix : new double[rows, cols];


            // Center the data around the mean. Will have no effect if
            //  the data is already centered (the mean will be zero).
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    result[i, j] = (matrix[i, j] - columnMeans[j]);

            // Check if we also have to standardize our data (convert to Z Scores).
            if (this.analysisMethod == AnalysisMethod.Standardize)
            {
                // Yes. Divide by standard deviation
                for (int j = 0; j < cols; j++)
                {
                    if (columnStdDev[j] == 0)
                        throw new ArithmeticException("Standard deviation cannot be zero (cannot standardize the constant variable at column index " + j + ").");

                    for (int i = 0; i < rows; i++)
                        result[i, j] /= columnStdDev[j];
                }
            }

            return result;
        }

        /// <summary>
        ///   Adjusts a data matrix, centering and standardizing its values
        ///   using the already computed column's means and standard deviations.
        /// </summary>
        protected float[][] Adjust(float[][] matrix, bool inPlace)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;

            // Prepare the data, storing it in a new matrix if needed.
            float[][] result = matrix;

            if (!inPlace)
            {
                result = new float[rows][];
                for (int i = 0; i < rows; i++)
                    result[i] = new float[cols];
            }


            // Center the data around the mean. Will have no effect if
            //  the data is already centered (the mean will be zero).
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    result[i][j] = (matrix[i][j] - (float)columnMeans[i]);

            // Check if we also have to standardize our data (convert to Z Scores).
            if (this.analysisMethod == AnalysisMethod.Standardize)
            {
                // Yes. Divide by standard deviation
                for (int i = 0; i < rows; i++)
                {
                    if (columnStdDev[i] == 0)
                        throw new ArithmeticException("Standard deviation cannot be zero (cannot standardize the constant variable at column index " + i + ").");

                    for (int j = 0; j < rows; j++)
                        result[i][j] /= (float)columnStdDev[i];
                }
            }

            return result;
        }

        private static Single[][] convert(double[,] matrix)
        {
            int components = matrix.GetLength(0);
            float[][] array = new float[components][];
            for (int i = 0; i < components; i++)
            {
                array[i] = new float[components];
                for (int j = 0; j < components; j++)
                    array[i][j] = (float)matrix[j, i];
            }

            return array;
        }

        #endregion

    }


    #region Support Classes
    /// <summary>
    ///   Represents an Independent Component found in the Independent Component 
    ///   Analysis, allowing it to be directly bound to controls like the DataGridView.
    /// </summary>
    /// 
    [Serializable]
    public class IndependentComponent
    {

        private int index;
        private IndependentComponentAnalysis analysis;


        /// <summary>
        ///   Creates an independent component representation.
        /// </summary>
        /// <param name="analysis">The analysis to which this component belongs.</param>
        /// <param name="index">The component index.</param>
        internal IndependentComponent(IndependentComponentAnalysis analysis, int index)
        {
            this.index = index;
            this.analysis = analysis;
        }


        /// <summary>
        ///   Gets the Index of this component on the original component collection.
        /// </summary>
        public int Index
        {
            get { return this.index; }
        }

        /// <summary>
        ///   Returns a reference to the parent analysis object.
        /// </summary>
        public IndependentComponentAnalysis Analysis
        {
            get { return this.analysis; }
        }

        /// <summary>
        ///   Gets the mixing vector for the current independent component.
        /// </summary>
        public double[] MixingVector
        {
            get { return this.analysis.MixingMatrix.GetColumn(index); }
        }

        /// <summary>
        ///   Gets the unmixing vector for the current independent component.
        /// </summary>
        public double[] DemixingVector
        {
            get { return this.analysis.DemixingMatrix.GetColumn(index); }
        }

        /// <summary>
        ///   Gets the whitening factor for the current independent component.
        /// </summary>
        public double[] WhiteningVector
        {
            get { return this.analysis.WhiteningMatrix.GetColumn(index); }
        }

    }

    /// <summary>
    ///   Represents a Collection of Independent Components found in the
    ///   Independent Component Analysis. This class cannot be instantiated.
    /// </summary>
    /// 
    [Serializable]
    public class IndependentComponentCollection : ReadOnlyCollection<IndependentComponent>
    {
        internal IndependentComponentCollection(IndependentComponent[] components)
            : base(components)
        {
        }
    }
    #endregion



    #region Contrast functions
    namespace ContrastFunctions
    {
        /// <summary>
        ///   Common interface for contrast functions.
        /// </summary>
        /// <remarks>
        ///   Contrast functions are used as objective functions in
        ///   neg-entropy calculations.
        /// </remarks>
        /// 
        public interface IContrastFunction
        {
            /// <summary>
            ///   Contrast function.
            /// </summary>
            /// <param name="x">The vector of observations.</param>
            /// <param name="output">At method's return, this parameter
            ///   should contain the evaluation of function over the vector
            ///   of observations <paramref name="x"/>.</param>
            /// <param name="derivative">At method's return, this parameter
            ///   should contain the evaluation of function derivative over 
            ///   the vector of observations <paramref name="x"/>.</param>
            void Evaluate(double[] x, double[] output, double[] derivative);
        }

        /// <summary>
        ///   Exponential contrast function.
        /// </summary>
        /// 
        public class Exponential : IContrastFunction
        {
            double alpha = 1;

            /// <summary>
            ///   Initializes a new instance of the <see cref="Exponential"/> class.
            /// </summary>
            /// <param name="alpha">The exponential alpha constant. Default is 1.</param>
            public Exponential(double alpha)
            {
                this.alpha = alpha;
            }

            /// <summary>
            ///   Gets the exponential alpha constant.
            /// </summary>
            public double Alpha { get { return alpha; } }

            /// <summary>
            /// Initializes a new instance of the <see cref="Exponential"/> class.
            /// </summary>
            public Exponential() { }

            /// <summary>
            /// Contrast function.
            /// </summary>
            /// <param name="x">The vector of observations.</param>
            /// <param name="output">At method's return, this parameter
            /// should contain the evaluation of function over the vector
            /// of observations <paramref name="x"/>.</param>
            /// <param name="derivative">At method's return, this parameter
            /// should contain the evaluation of function derivative over
            /// the vector of observations <paramref name="x"/>.</param>
            public void Evaluate(double[] x, double[] output, double[] derivative)
            {
                for (int j = 0; j < x.Length; j++)
                {
                    double w = x[j];
                    double e = System.Math.Exp(-alpha * (w * w) / 2.0);

                    // g(w*x) = wx * exp(-(wx^2)/2)
                    output[j] = w * e;

                    // g'(w*x) = (1 - wx^2) * exp(-(wx^2)/2)
                    derivative[j] = (1.0 - alpha * w * w) * e;
                }
            }
        }

        /// <summary>
        ///   Log-cosh (Hyperbolic Tangent) contrast function.
        /// </summary>
        public class Logcosh : IContrastFunction
        {
            double alpha = 1;

            /// <summary>
            /// Initializes a new instance of the <see cref="Logcosh"/> class.
            /// </summary>
            public Logcosh() { }

            /// <summary>
            /// Initializes a new instance of the <see cref="Logcosh"/> class.
            /// </summary>
            /// <param name="alpha">The log-cosh alpha constant. Default is 1.</param>
            public Logcosh(double alpha)
            {
                this.alpha = alpha;
            }

            /// <summary>
            ///   Gets the exponential log-cosh constant.
            /// </summary>
            public double Alpha { get { return alpha; } }

            /// <summary>
            /// Contrast function.
            /// </summary>
            /// <param name="x">The vector of observations.</param>
            /// <param name="output">At method's return, this parameter
            /// should contain the evaluation of function over the vector
            /// of observations <paramref name="x"/>.</param>
            /// <param name="derivative">At method's return, this parameter
            /// should contain the evaluation of function derivative over
            /// the vector of observations <paramref name="x"/>.</param>
            public void Evaluate(double[] x, double[] output, double[] derivative)
            {
                for (int j = 0; j < x.Length; j++)
                {
                    double f;

                    // g(w*x)
                    f = output[j] = System.Math.Tanh(alpha * x[j]);

                    // g'(w*x)
                    derivative[j] = alpha * (1.0 - f * f);
                }
            }
        }

        /// <summary>
        ///   Kurtosis contrast function.
        /// </summary>
        public class Kurtosis : IContrastFunction
        {

            /// <summary>
            /// Initializes a new instance of the <see cref="Kurtosis"/> class.
            /// </summary>
            public Kurtosis() { }

            /// <summary>
            /// Contrast function.
            /// </summary>
            /// <param name="x">The vector of observations.</param>
            /// <param name="output">At method's return, this parameter
            /// should contain the evaluation of function over the vector
            /// of observations <paramref name="x"/>.</param>
            /// <param name="derivative">At method's return, this parameter
            /// should contain the evaluation of function derivative over
            /// the vector of observations <paramref name="x"/>.</param>
            public void Evaluate(double[] x, double[] output, double[] derivative)
            {
                for (int j = 0; j < x.Length; j++)
                {
                    double v = x[j];

                    // g(w*x)
                    output[j] = v * v * v;

                    // g'(w*x)
                    derivative[j] = (1.0 / 3.0) * v * v;
                }
            }
        }
    }
    #endregion


}
