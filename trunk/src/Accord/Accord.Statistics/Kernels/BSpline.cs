﻿// Accord Statistics Library
// Accord.NET framework
// http://www.crsouza.com
//
// Copyright © César Souza, 2009-2010
// cesarsouza at gmail.com
//

namespace Accord.Statistics.Kernels
{
    using System;
    using Accord.Math;

    /// <summary>
    ///   B-Spline Kernel.
    /// </summary>
    /// <remarks>
    /// <para>
    ///   The B-Spline kernel is defined only in the interval [−1, 1]. It is 
    ///   also a member of the Radial Basis Functions family of kernels.</para>
    /// <para>  
    ///   References:
    ///   <list type="bullet">
    ///     <item><description>
    ///       Bart Hamers, ftp://ftp.esat.kuleuven.ac.be/pub/SISTA/hamers/PhD_bhamers.pdf
    ///     </description></item>
    ///   </list></para>
    /// </remarks>
    /// 
    [Serializable]
    public class BSpline : IKernel
    {
        private int order;

        /// <summary>
        ///   Constructs a new B-Spline Kernel.
        /// </summary>
        /// <param name="order"></param>
        public BSpline(int order)
        {
            this.order = order;
        }

        /// <summary>
        ///   B-Spline Kernel Function
        /// </summary>
        /// <param name="x">Vector x in input space.</param>
        /// <param name="y">Vector y in input space.</param>
        /// <returns>Dot product in feature (kernel) space.</returns>
        public double Function(double[] x, double[] y)
        {
            double k = 1.0;
            int n = 2 * order + 1;

            for (int p = 0; p < x.Length; p++)
                k *= Special.BSpline(n, x[p] - y[p]);

            return k;
        }

    }
}