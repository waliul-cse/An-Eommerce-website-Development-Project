using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommonUtility
/// </summary>
public class CommonUtility
{
    public static object FilterNull(object value, Type type)
    {
        if (value == DBNull.Value)
        {
            if (type == typeof(int))
                return 0;
            else if (type == typeof(double))
                return 0.0;
            else if (type == typeof(string))
                return string.Empty;
            else if (type == typeof(DateTime))
                return null;
            else if (type == typeof(decimal))
                return 0;
            else if (type == typeof(bool))
                return false;
            else
                return value;
        }
        else
            return value;
    }
}
