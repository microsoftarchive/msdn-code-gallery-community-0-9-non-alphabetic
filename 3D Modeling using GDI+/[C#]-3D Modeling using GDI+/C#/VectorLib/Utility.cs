using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VectorLib
{
    public static class Utility
    {
        private static int m_decimalLinear = 6;
        private static int m_decimalAngular = 2;
        private static double m_error = 1e-6;
        public static double Domain
        {
            get { return m_error; }
        }

        public static bool IsEqual(double a, double b)
        {
            return ((a - b) <= m_error);
        }
        public static double Round(double x)
        {
            return Math.Round(x, m_decimalLinear);
        }
        public static double RoundAngular(double x)
        {
            return Math.Round(x, m_decimalAngular);
        }
    }

}
