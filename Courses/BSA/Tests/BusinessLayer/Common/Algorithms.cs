﻿namespace BusinessLayer.Common
{
    public static class Algorithms
    {
        public static string GetFullText(System.Exception e)
        {
            string text = string.Empty;
            while (e != null) 
            {
                text += e.Message;
                e = e.InnerException;
            } 
            return text;
        }
    }
}
