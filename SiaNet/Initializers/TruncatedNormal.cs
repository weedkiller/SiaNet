﻿namespace SiaNet.Initializers
{
    using SiaNet.Engine;
    using System;

    /// <summary>
    /// Initializer that generates a truncated normal distribution. 
    /// These values are similar to values from a RandomNormal except that values more than two standard deviations from the mean are discarded and redrawn.
    /// This is the recommended initializer for neural network weights and filters.
    /// </summary>
    /// <seealso cref="SiaNet.Initializers.BaseInitializer" />
    public class TruncatedNormal : BaseInitializer
    {
        /// <summary>
        /// Mean of the random values to generate.
        /// </summary>
        /// <value>
        /// The mean value.
        /// </value>
        public float MeanVal { get; set; }

        /// <summary>
        /// Standard deviation of the random values to generate.
        /// </summary>
        /// <value>
        /// The standard dev.
        /// </value>
        public float StdDev { get; set; }

        /// <summary>
        /// Used to seed the random generator.
        /// </summary>
        /// <value>
        /// The seed.
        /// </value>
        public int? Seed { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TruncatedNormal"/> class.
        /// </summary>
        /// <param name="mean">Mean of the random values to generate.</param>
        /// <param name="stddev">Standard deviation of the random values to generate.</param>
        /// <param name="seed">Used to seed the random generator.</param>
        public TruncatedNormal(float mean = 0f, float stddev = 0.05f, int? seed = null)
            :base ("truncated_normal")
        {
            MeanVal = mean;
            StdDev = stddev;
            Seed = seed;
        }

        /// <summary>
        /// Generates a tensor with specified shape.
        /// </summary>
        /// <param name="shape">The shape of the tensor.</param>
        /// <returns></returns>
        public override Tensor Generate(params long[] shape)
        {
            float stddev = (float)Math.Sqrt(StdDev) / 0.87962566103423978f;
            return K.RandomNormal(shape, MeanVal, stddev, Seed);
        }

    }
}
