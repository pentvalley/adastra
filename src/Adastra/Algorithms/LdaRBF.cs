﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Encog.MathUtil.RBF;
using Encog.ML.Data;
using Encog.ML.Data.Basic;
using Encog.Neural.RBF;
using Encog.Util.Simple;
using Accord.Statistics.Analysis;

namespace Adastra.Algorithms
{
    /// <summary>
    /// First Linear Discriminant Analysis (LDA) computations and then Radial Basis Function (RBF) (for training) is applied.
    /// </summary>
    public class LdaRBF : AMLearning
    {
        RBFNetwork method;
        LinearDiscriminantAnalysis _lda;

        public LdaRBF()
        {
            //TODO: choose better default parameters
            method = new RBFNetwork(2, 4, 1, RBFEnum.Gaussian);
        }

        public LdaRBF(string name)
        {
            this.Name = name;
            method = new RBFNetwork(2, 4, 1, RBFEnum.Gaussian);
        }

        public override void Train(List<double[]> outputInput, int inputVectorDimensions)
        {
            double[,] inputs = new double[outputInput.Count, inputVectorDimensions];
            int[] output = new int[outputInput.Count];

            #region convert to LDA format
            for (int i = 0; i < outputInput.Count; i++)
            {
                output[i] = Convert.ToInt32((outputInput[i])[0]);

                for (int j = 1; j < inputVectorDimensions + 1; j++)
                {
                    inputs[i, j - 1] = (outputInput[i])[j];
                }
            }
            #endregion

            //output classes must be consecutive: 1,2,3 ...
            _lda = new LinearDiscriminantAnalysis(inputs, output);

            if (this.Progress != null) this.Progress(10);

            // Compute the analysis
            _lda.Compute();

            if (this.Progress != null) this.Progress(35);

            double[,] projection = _lda.Transform(inputs);

            int vector_count = projection.GetLength(0);
            int dimensions = projection.GetLength(1);
            int output_count = _lda.ClassCount.Count();

            // convert for NN format
            double[][] input2 = new double[vector_count][];
            double[][] output2 = new double[vector_count][];

            #region convert to NN format
            for (int i = 0; i < input2.Length; i++)
            {
                input2[i] = new double[projection.GetLength(1)];
                for (int j = 0; j < projection.GetLength(1); j++)
                {
                    input2[i][j] = projection[i, j];
                }

                output2[i] = new double[output_count];
                output2[i][output[i] - 1] = 1;
            }
            #endregion

            //IMLDataSet dataSet = new BasicMLDataSet(input2, output2);

            Encog.Neural.Rbf.Training.SVDTraining teacher=null;

            int ratio = 4;
            NNTrainDataIterator iter = new NNTrainDataIterator(ratio, input2, output2);

            //actual training
            while (iter.HasMore) //we do the training each time spliting the data to different 'train' and 'validate' sets 
            {
                #region get new data
                double[][] trainDataInput;
                double[][] trainDataOutput;
                double[][] validateDataInput;
                double[][] validateDataOutput;

                iter.NextData(out trainDataInput, out trainDataOutput, out validateDataInput, out validateDataOutput);

                double validationSetError;
                double trainSetError;
                double prevError = 1000000;
                #endregion

                //We do the training over the 'train' set until the error of the 'validate' set start to increase. 
                //This way we prevent overfitting.
                int count = 0;
                while (true)
                {
                    count++;

                    IMLDataSet dataSet = new BasicMLDataSet(trainDataInput, trainDataOutput);

                    if (teacher==null)
                        teacher = new Encog.Neural.Rbf.Training.SVDTraining(method, dataSet);
                    else teacher.Training = dataSet;
                    
                    teacher.Iteration();
                    trainSetError = this.ComputeError(trainDataInput, trainDataOutput);

                    if (count % 10 == 0) //we check for 'early-stop' every nth training iteration - this will help improve performance
                    {
                        validationSetError = ComputeError(validateDataInput, validateDataOutput);
                        if (double.IsNaN(validationSetError)) throw new Exception("Computation failed!");

                        if (validationSetError > prevError)
                            break;
                        prevError = validationSetError;
                    }
                }

                if (this.Progress != null) this.Progress(35 + (iter.CurrentIterationIndex) * (65 / ratio));
            }

            //now we have a model of a RBF+LDA which we can use for classification
            if (this.Progress != null) this.Progress(100);
        }

        public override int Classify(double[] input)
        {
            double[,] sample = new double[1, input.Length];

            #region convert to LDA format
            for (int i = 0; i < input.Length; i++)
            {
                sample[0, i] = input[i];
            }
            #endregion

            double[,] projectedSample = _lda.Transform(sample);

            #region convert to NN format
            double[] projectedSample2 = new double[projectedSample.GetLength(1)];
            for (int i = 0; i < projectedSample.GetLength(1); i++)
            {
                projectedSample2[i] = projectedSample[0, i];
            }
            #endregion

            IMLData set = new Encog.ML.Data.Basic.BasicMLData(projectedSample2);

            IMLData result = method.Compute(set);

            #region find winner node 
            int pos = -1;
            double max = -1;
            for (int i = 0; i < result.Count; i++)
            {
                if (result[i] > max)
                {
                    pos = i;
                    max = result[i];
                }
            }

            return pos + 1;
            #endregion
        }

        public double ComputeError(double[][] input, double[][] output)
        {
            //TODO: fill method
            throw new Exception("Unimplemented");
            return -1;
        }

        public override event ChangedValuesEventHandler Progress;
    }
}
